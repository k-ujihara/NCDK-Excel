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
using System.IO;
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
                FormatThem(keep);
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

        private void FormatThem(dynamic range)
        {
            switch (range)
            {
                case Excel.Range cells:
                    var cellsCount = cells.Count;

                    Excel.Range firstCell = cells.Cells[1];
                    var firstCellInfo = new Tuple<int, int>(firstCell.Column, firstCell.Row);
                    GeneratePictureOnCell(firstCell);

                    Excel.Range foundCell = cells.Find("*");
                    var firstFoundCellInfo = new Tuple<int, int>(foundCell.Column, foundCell.Row);
                    if (foundCell == null)
                        break;
                    if (firstFoundCellInfo.Equals(firstCellInfo))
                        break;
                    GeneratePictureOnCell(foundCell);

                    for (int i = 0; i < cellsCount; i++)
                    {
                        foundCell = cells.FindNext(foundCell);
                        var cellInfo = new Tuple<int, int>(foundCell.Column, foundCell.Row);
                        if (firstCellInfo.Equals(cellInfo)
                         || firstFoundCellInfo.Equals(cellInfo))
                            break;

                        GeneratePictureOnCell(foundCell);
                    }
                    break;
                case Office.TextRange2 textRange:
                    break;
                case Excel.Shape shape:
                    break;
                case Excel.ShapeRange shapeRange:
                    break;
                case Excel.ChartArea chartArea:
                    break;
                case Excel.Chart chart:
                    break;
                case Excel.ChartTitle chartTitle:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Insert picture of molecule indicated by <paramref name="cell"/>.Text on <paramref name="cell"/>.
        /// Do nothing when it cause exception.
        /// </summary>
        /// <param name="cell"></param>
        private static void GeneratePictureOnCell(Excel.Range cell)
        {
            try
            {
                string text = cell.Text;
                if (!string.IsNullOrEmpty(text))
                {
                    cell.Activate();
                    var mol = NCDKExcel.Utility.Parse(text);
                    var depict = Stuff.PictureGenerator.Depict(mol);
                    var tempPng = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".png");
                    depict.WriteTo(tempPng);
                    try
                    {
                        dynamic sheet = Globals.ThisAddIn.Application.ActiveSheet;
                        sheet.Pictures.Insert(tempPng);
                    }
                    catch (Exception)
                    { }
                    finally
                    {
                        File.Delete(tempPng);
                    }
                }
            }
            catch (Exception)
            { }
        }
    }
}
