// MIT License
// 
// Copyright (c) 2019 Kazuya Ujihara
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

using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace NCDK_ExcelAddIn
{
    public partial class NCDKExcelRibbon
    {
        private void NCDKExcelRibbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void ButtonImportSDF_Click(object sender, RibbonControlEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                FilterIndex = 1,
                Filter =
                        "All supported files (*.sdf)|*.sdf|" +
                        "SD file (*.sdf)|*.sdf|" +
                        "All Files (*.*)|*.*"
            };

            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fn = openFileDialog.FileName;
                var ex = Path.GetExtension(fn);
                switch (ex)
                {
                    case ".sdf":
                        Stuff.LoadSDFToNewSheet(fn);
                        break;
                    default:
                        break;
                }
            }
        }

        private void ButtonGeneratePicture_Click(object sender, RibbonControlEventArgs e)
        {
            dynamic keep = null;
            try
            {
                keep = Globals.ThisAddIn.Application.Selection;
                AddChemicalStructures(keep);
            }
            catch (Exception)
            {
            }
            finally
            {
                if (keep != null)
                    keep.Select();
            }
        }

        const string PicturePrefix = "NCDK-Picture ";

        /// <summary>
        /// Add pictures of chemical strucure indicatied by text in each cell in range.
        /// </summary>
        /// <param name="range">The range to sweep.</param>
        private void AddChemicalStructures(dynamic range)
        {
            switch (range)
            {
                case Excel.Range cells:
                    dynamic sheet = Globals.ThisAddIn.Application.ActiveSheet;
                    Excel.Shapes shapes = sheet.Shapes;
                    var shapeNames = shapes.Cast<Excel.Shape>().Select(n => n.Name).ToList();
                    EnumerateCells(cells, cell => GenerateChemicalStructurePictureOnCell(cell, shapeNames));
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Do <paramref name="action"/> on each cell in <paramref name="range"/>.
        /// </summary>
        /// <param name="range">The range contains cells to action.</param>
        /// <param name="action">The action to do on each cell.</param>
        private static void EnumerateCells(Excel.Range range, Action<Excel.Range> action)
        {
            // Enumerate non-empty cells by Excel.Range.Find function.
            // However the first found cell is not range.Cells[1] when cell is not empty.
            // So range[1] is treated individually.

            var cellsCount = range.Count;

            Tuple<int, int> firstCellInfo, firstFoundCellInfo;
            {
                Excel.Range firstCell = range.Cells[1];
                firstCellInfo = new Tuple<int, int>(firstCell.Column, firstCell.Row);
                if (!string.IsNullOrEmpty(firstCell.Text))
                    action(firstCell);
            }

            Excel.Range foundCell = range.Find("*");
            firstFoundCellInfo = new Tuple<int, int>(foundCell.Column, foundCell.Row);
            if (foundCell == null)
                return;
            if (firstFoundCellInfo.Equals(firstCellInfo))
                return;
            action(foundCell);

            Excel.Range newfoundCell = null;
            for (int i = 0; i < cellsCount; i++)
            {
                newfoundCell = range.FindNext(foundCell);
                var cellInfo = new Tuple<int, int>(newfoundCell.Column, newfoundCell.Row);
                if (firstCellInfo.Equals(cellInfo)
                 || firstFoundCellInfo.Equals(cellInfo))
                    break;

                action(newfoundCell);
                foundCell = newfoundCell;
            }
        }

        class StructureGegerator : IDisposable      
        {
            readonly string tempPng = null;

            public StructureGegerator(string ident)
            {
                var mol = NCDKExcel.Utility.Parse(ident);
                var depict = Stuff.PictureGenerator.Depict(mol);
                tempPng = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".png");
                depict.WriteTo(tempPng);
            }

            public string FileName => tempPng;

            #region IDisposable Support
            private bool disposedValue = false;

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                   try
                    {
                        if (tempPng != null)
                            File.Delete(tempPng);
                    }
                    catch (Exception e)
                    {
                        Trace.TraceWarning(e.Message);
                    }

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
        /// Insert picture of molecule indicated by <paramref name="cell"/>.Text on <paramref name="cell"/>.
        /// Do nothing when it cause exception.
        /// </summary>
        /// <param name="cell">The cell to add picture.</param>
        private static void GenerateChemicalStructurePictureOnCell(Excel.Range cell)
        {
            try
            {
                string text = cell.Text;
                if (!string.IsNullOrEmpty(text))
                {
                    using (var structGen = new StructureGegerator(text))
                    {
                        var tempPng = structGen.FileName;
                        dynamic sheet = Globals.ThisAddIn.Application.ActiveSheet;
                        Excel.Shapes shapes = sheet.Shapes;
                        string pictureName = CreateUniqueString(
                             shapes.Cast<Excel.Shape>().
                             Select(n => n.Name), prefix: PicturePrefix);

                        var shapeToDelete = FindShape(cell);
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

        private static void GenerateChemicalStructurePictureOnCell(Excel.Range cell, IList<string> shapeNames)
        {
            try
            {
                string text = cell.Text;
                if (!string.IsNullOrEmpty(text))
                {
                    using (var structGen = new StructureGegerator(text))
                    {
                        var tempPng = structGen.FileName;
                        dynamic sheet = Globals.ThisAddIn.Application.ActiveSheet;
                        string pictureName = CreateUniqueString(shapeNames, prefix: PicturePrefix);

                        var shapeToDelete = FindShape(cell);
                        if (shapeToDelete != null)
                            shapeToDelete.Delete();
                        AddPicture(cell, tempPng, pictureName);
                        shapeNames.Add(pictureName);
                    }
                }
            }
            catch (Exception e)
            {
                Trace.TraceWarning(e.Message);
            }
        }

        private static void AddPicture(Excel.Range cell, string pictureFileName, string name)
        {
            cell.Activate();
            dynamic sheet = Globals.ThisAddIn.Application.ActiveSheet;
            Excel.Shapes shapes = sheet.Shapes;
            Excel.Shape shape = shapes.AddPicture(
                pictureFileName,
                Office.MsoTriState.msoFalse, Office.MsoTriState.msoTrue,
                cell.Left, cell.Top, cell.Width, cell.Height);
            shape.Placement = Excel.XlPlacement.xlMoveAndSize;
            shape.Name = name;

            // if we want to add original size picture, add the following lines.
            // shape.ScaleHeight(1, Office.MsoTriState.msoTrue);
            // shape.ScaleWidth(1, Office.MsoTriState.msoTrue);
        }

        /// <summary>
        /// Create unique string.
        /// </summary>
        /// <param name="prefix">The prefix of returned name.</param>
        /// <param name="suffix">The suffix of returned name.</param>
        /// <param name="existingNames">Strings can not be crashed.</param>
        /// <returns>The unique string.</returns>
        /// <threadsafety static="false" />
        private static string CreateUniqueString(IEnumerable<string> existingNames, string prefix = null, string suffix = null)
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

        private static bool IsChemicalStructure(Excel.Shape shape)
        {
            return shape.Name.StartsWith(PicturePrefix);
        }

        private static void SetChemicalStructureVisible(bool isVisible)
        {
            dynamic sheet = Globals.ThisAddIn.Application.ActiveSheet;
            Excel.Shapes shapes = sheet.Shapes;
            var flag = isVisible ? Office.MsoTriState.msoTrue : Office.MsoTriState.msoFalse;
            foreach (var shape in shapes.Cast<Excel.Shape>().Where(n => IsChemicalStructure(n)))
            {
                shape.Visible = flag;
            }
        }

        private void ButtonUnshowPicture_Click(object sender, RibbonControlEventArgs e)
        {
            SetChemicalStructureVisible(false);
        }

        private void ButtonShowPictures_Click(object sender, RibbonControlEventArgs e)
        {
            SetChemicalStructureVisible(true);
        }

        /// <summary>
        /// Find shape on <paramref name="cell"/>.
        /// </summary>
        /// <param name="cell">The cell to find shape.</param>
        /// <returns>The shape on <paramref name="cell"/>. 
        /// <see langword="null"/> if no shape on <paramref name="cell"/>.</returns>
        private static Excel.Shape FindShape(Excel.Range cell)
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

        private void ButtonUpdatePictures_Click(object sender, RibbonControlEventArgs e)
        {
            dynamic keep = null;
            try
            {
                keep = Globals.ThisAddIn.Application.Selection;

                dynamic sheet = Globals.ThisAddIn.Application.ActiveSheet;
                Excel.Shapes shapes = sheet.Shapes;
                var shapeList = new List<Tuple<Excel.Shape, int, int>>();
                foreach (var shape in shapes.Cast<Excel.Shape>().Where(n => IsChemicalStructure(n)))
                {
                    var cell = shape.TopLeftCell;
                    shapeList.Add(new Tuple<Excel.Shape, int, int>(shape, cell.Row, cell.Column));
                }
                foreach (var shapeInfo in shapeList)
                {
                    var shape = shapeInfo.Item1;
                    Excel.Range cell = sheet.Cells[shapeInfo.Item2, shapeInfo.Item3];
                    var pictureName = shape.Name;
                    shape.Delete();
                    using (var sg = new StructureGegerator(cell.Text))
                    {
                        try
                        {
                            AddPicture(cell, sg.FileName, pictureName);
                        }
                        catch (Exception ex)
                        {
                            Trace.TraceInformation(ex.Message);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                if (keep != null)
                    keep.Select();
            }
        }
    }
}
