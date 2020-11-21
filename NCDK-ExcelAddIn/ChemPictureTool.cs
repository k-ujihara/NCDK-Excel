// MIT License
// 
// Copyright (c) 2020 Kazuya Ujihara
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace NCDK_ExcelAddIn
{
    public class TempFile : IDisposable
    {
        public TempFile()
            : this(null) 
        {
        }

        public TempFile(string extension)
        {
            FileName = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + extension??"");
        }

        public string FileName { get; private set; } = null;

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (FileName != null && File.Exists(FileName))
                    {
                        try
                        {
                            File.Delete(FileName);
                        }
                        catch (Exception)
                        {
                            // ignore
                        }                        
                    }
                }
                FileName = null;

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }

    /// <summary>
    /// Picture generator from text express of molecule.
    /// </summary>
    public interface IPictureGegerator
    {
        /// <summary>
        /// Generate picture of molecule specified as text format.
        /// </summary>
        /// <param name="text">Identifier to convert, typically SMILES, MOLBlock etc.</param>
        /// <returns><see cref="TempFile"/> object of the genrated picture.</returns>
        TempFile GenerateTemporary(string text);
    }

    public static class ChemPictureTool
    {
        /// <summary>
        /// Add pictures of chemical strucure indicatied by text in each cell in range.
        /// </summary>
        /// <param name="range">The range to sweep.</param>
        /// <param name="callback">Callback function before visiting cell.</param>
        public static void AddChemicalStructures(dynamic range, Action callback = null)
        {
            switch (range)
            {
                case Excel.Range cells:
                    dynamic sheet = Globals.ThisAddIn.Application.ActiveSheet;
                    Excel.Shapes shapes = sheet.Shapes;

                    var saveScreenUpdating = Globals.ThisAddIn.Application.ScreenUpdating;
                    var saveCalculation = Globals.ThisAddIn.Application.Calculation;
                    try
                    {
                        Globals.ThisAddIn.Application.ScreenUpdating = false;
                        Globals.ThisAddIn.Application.Calculation = Excel.XlCalculation.xlCalculationManual;

                        var shapeNames = shapes.Cast<Excel.Shape>().Select(n => n.Name).ToList();
                        ExcelTool.EnumerateCells(cells, cell => GenerateChemicalStructurePictureOnCell(cell, shapeNames), callback);
                    }
                    finally
                    {
                        Globals.ThisAddIn.Application.Calculation = saveCalculation;
                        Globals.ThisAddIn.Application.ScreenUpdating = saveScreenUpdating;
                    }
                    break;
                default:
                    break;
            }
        }

        const string PicturePrefix = "NCDK-Picture ";
        private static NCDKPictureGegerator pictureGenerator = new NCDKPictureGegerator();

        private static void GenerateChemicalStructurePictureOnCell(Excel.Range cell, ICollection<string> shapeNames)
        {
            try
            {
                var text = (string)cell.Text;
                if (!string.IsNullOrEmpty(text))
                {
                    using (var structGen = pictureGenerator.GenerateTemporary(text))
                    {
                        var tempPng = structGen.FileName;
                        dynamic sheet = Globals.ThisAddIn.Application.ActiveSheet;
                        string pictureName = CreateUniqueString(shapeNames, prefix: PicturePrefix);

                        var shapeToDelete = FindChemShape(cell);
                        if (shapeToDelete != null)
                            shapeToDelete.Delete();
                        AddPicture(cell, tempPng, pictureName);
                    }
                }
            }
            catch (Exception e)
            {
                Trace.TraceWarning(e.Message);
            }
        }

        /// <summary>
        /// Add a picture file named <paramref name="pictureFileName"/> on <paramref name="cell"/> and name <paramref name="name"/>.
        /// </summary>
        /// <param name="cell">The cell to add a picture.</param>
        /// <param name="pictureFileName">File name of the picture.</param>
        /// <param name="name">Excel name of the picture.</param>
        public static void AddPicture(Excel.Range cell, string pictureFileName, string name)
        {
            cell.Activate();
            dynamic sheet = Globals.ThisAddIn.Application.ActiveSheet;
            Excel.Shapes shapes = sheet.Shapes;
            Excel.Shape shape = shapes.AddPicture(
                pictureFileName,
                Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue,
                (float)cell.Left, (float)cell.Top, (float)cell.Width, (float)cell.Height);
            shape.Placement = Excel.XlPlacement.xlMove;
            shape.Name = name;

            // if you want to fit pictures with each cell, delte the following lines.
            shape.ScaleHeight(1, Office.MsoTriState.msoTrue);
            shape.ScaleWidth(1, Office.MsoTriState.msoTrue);

            var xyRatioCell = (float)cell.Width / (float)cell.Height;
            var xyRatioShape = shape.Width / shape.Height;
            float scale = 1;
            if (xyRatioCell > xyRatioShape)
            {
                // fit to cell.Height
                scale = (float)cell.Height / shape.Height;
            }
            else
            {
                // fit to cell.Width;
                scale = (float)cell.Width / shape.Width;
            }

            shape.ScaleHeight(scale, Office.MsoTriState.msoTrue);
            shape.ScaleWidth(scale, Office.MsoTriState.msoTrue);
            shape.LockAspectRatio = Office.MsoTriState.msoTrue;
        }

        public static void UpdatePictures()
        {
            dynamic sheet = Globals.ThisAddIn.Application.ActiveSheet;
            Excel.Shapes shapes = sheet.Shapes;
            var shapeList = new List<Tuple<Excel.Shape, int, int>>();
            foreach (var shape in shapes.Cast<Excel.Shape>().Where(n => IsChemicalStructure(n)))
            {
                var cell = shape.TopLeftCell;
                shapeList.Add(new Tuple<Excel.Shape, int, int>(shape, cell.Row, cell.Column));
            }

            var saveScreenUpdating = Globals.ThisAddIn.Application.ScreenUpdating;
            var saveCalculation = Globals.ThisAddIn.Application.Calculation;
            try
            {
                Globals.ThisAddIn.Application.ScreenUpdating = false;
                Globals.ThisAddIn.Application.Calculation = Excel.XlCalculation.xlCalculationManual;

                foreach (var shapeInfo in shapeList)
                {
                    var shape = shapeInfo.Item1;
                    Excel.Range cell = sheet.Cells[shapeInfo.Item2, shapeInfo.Item3];
                    var pictureName = shape.Name;
                    shape.Delete();
                    using (var sg = pictureGenerator.GenerateTemporary((string)cell.Text))
                    {
                        try
                        {
                            var filename = sg.FileName;
                            AddPicture(cell, filename, pictureName);
                        }
                        catch (Exception ex)
                        {
                            Trace.TraceInformation(ex.Message);
                        }
                    }
                }
            }
            finally
            {
                Globals.ThisAddIn.Application.Calculation = saveCalculation;
                Globals.ThisAddIn.Application.ScreenUpdating = saveScreenUpdating;
            }
        }

        /// <summary>
        /// Create unique string.
        /// </summary>
        /// <param name="prefix">The prefix of returned name.</param>
        /// <param name="suffix">The suffix of returned name.</param>
        /// <param name="existingNames">Strings can not be crashed.</param>
        /// <returns>The unique string.</returns>
        /// <threadsafety static="false" />
        public static string CreateUniqueString(IEnumerable<string> existingNames, string prefix = null, string suffix = null)
        {
            for (int i = 1; ; i++)
            {
                string candidate = $"{prefix ?? ""}{i}{suffix ?? ""}";
                foreach (var existingName in existingNames)
                {
                    if (candidate.Equals(existingName, StringComparison.Ordinal))
                    {
                        // crashed 
                        goto L10;
                    }
                }
                // Found that newNameCandidate is proper for shape name. 
                return candidate;
            L10:
                ;
            }
        }

        public static bool IsChemicalStructure(string shapeName)
        {
            return shapeName.StartsWith(PicturePrefix);
        }

        public static bool IsChemicalStructure(Excel.Shape shape)
        {
            return IsChemicalStructure(shape.Name);
        }

        public static void SetChemicalStructureVisible(bool isVisible)
        {
            dynamic sheet = Globals.ThisAddIn.Application.ActiveSheet;
            Excel.Shapes shapes = sheet.Shapes;
            var flag = isVisible ? Office.MsoTriState.msoTrue : Office.MsoTriState.msoFalse;
            foreach (var shape in shapes.Cast<Excel.Shape>().Where(n => IsChemicalStructure(n)))
            {
                shape.Visible = flag;
            }
        }

        /// <summary>
        /// Find shape on <paramref name="cell"/>.
        /// </summary>
        /// <param name="cell">The cell to find shape.</param>
        /// <returns>The shape on <paramref name="cell"/>. 
        /// <see langword="null"/> if no shape on <paramref name="cell"/>.</returns>
        public static Excel.Shape FindChemShape(Excel.Range cell)
        {
            dynamic sheet = Globals.ThisAddIn.Application.ActiveSheet;
            Excel.Shapes shapes = sheet.Shapes;
            foreach (var shape in shapes.Cast<Excel.Shape>().Where(n => IsChemicalStructure(n)))
            {
                var cellShape = shape.TopLeftCell;
                if (cell.Row.Equals(cellShape.Row)
                 && cell.Column.Equals(cellShape.Column))
                {
                    return shape;
                }
            }
            return null;
        }
    }
}
