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

namespace NCDK_ExcelAddIn
{
    public partial class NCDKExcelRibbon
    {
        private void NCDKExcelRibbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void ButtonImportSDF_Click(object sender, RibbonControlEventArgs e)
        {
            ButtonImportSDF(filename => Stuff.LoadSDFToNewSheet(filename));
        }

        private void ButtonImportSDF(Action<string> loadSDFToNewSheet)
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
                        loadSDFToNewSheet(fn);
                        break;
                    default:
                        break;
                }
            }
        }

        private void ButtonGeneratePicture_Click(object sender, RibbonControlEventArgs e)
        {
            dynamic keep = Globals.ThisAddIn.Application.Selection;
            try
            {
                ChemPictureTool.AddChemicalStructures(keep);
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

        private void ButtonUnshowPicture_Click(object sender, RibbonControlEventArgs e)
        {
            ChemPictureTool.SetChemicalStructureVisible(false);
        }

        private void ButtonShowPictures_Click(object sender, RibbonControlEventArgs e)
        {
            ChemPictureTool.SetChemicalStructureVisible(true);
        }

        private void ButtonUpdatePictures_Click(object sender, RibbonControlEventArgs e)
        {
            dynamic keep = Globals.ThisAddIn.Application.Selection;
            try
            {
                ChemPictureTool.UpdatePictures();
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

        private void buttonImportSDFRDKit_Click(object sender, RibbonControlEventArgs e)
        {
            ButtonImportSDF(filename => RDKitStuff.LoadSDFToNewSheet(filename));
        }
    }
}
