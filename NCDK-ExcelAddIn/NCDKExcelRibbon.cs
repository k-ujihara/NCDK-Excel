// MIT License
// 
// Copyright (c) 2019-2021 Kazuya Ujihara
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
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace NCDK_ExcelAddIn
{
    public partial class NCDKExcelRibbon
    {
        private void NCDKExcelRibbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void AddChemicalStructures(IPictureGegerator pictureGenerator)
        {
            dynamic keep = Globals.ThisAddIn.Application.Selection;
            try
            {
                Stuff.AddChemicalStructures(keep, pictureGenerator);
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

        private IPictureGegerator CreatePictureGegerator()
        {
            switch (Config.Toolkit)
            {
                case Toolkits.RDKit:
                    return new RDKitPictureGenerator();
                case Toolkits.NCDK:
                    return new NCDKPictureGenerator();
                default:
                    return new RDKitPictureGenerator();
            }
        }

        private void ButtonGeneratePicture_Click(object sender, RibbonControlEventArgs e)
        {
            AddChemicalStructures(CreatePictureGegerator());
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
                ChemPictureTool.UpdatePictures(CreatePictureGegerator());
            }
            catch (Exception)
            {
            }
            finally
            {
                if (keep != null)
                    try
                    {
                        keep.Select();
                    }
                    catch (Exception)
                    {
                    }
            }
        }

        private void ButtonImportSDFRDKit_Click(object sender, RibbonControlEventArgs e)
        {
            switch (Config.Toolkit)
            {
                case Toolkits.NCDK:
                    ButtonImportSDF(filename => NCDKStuff.LoadSDFToNewSheet(filename));
                    break;
                case Toolkits.RDKit:
                    ButtonImportSDF(filename => RDKitStuff.LoadSDFToNewSheet(filename));
                    break;
            }
        }

        private void ButtonPreferenceDialog_Click(object sender, RibbonControlEventArgs e)
        {
            var dlg = new PrefDialog();
            dlg.comboToolkit.Text = Config.Toolkit;
            dlg.comboColoring.Text = Config.ColoringStyle;
            dlg.comboImageType.Text = Config.ImageType.ToUpperInvariant();
            dlg.textMinimumPixels.Text = Config.MinimumEdgePixels.ToString(CultureInfo.InvariantCulture);

            var result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                Config.Toolkit = dlg.comboToolkit.Text;
                Config.ColoringStyle = dlg.comboColoring.Text;
                Config.ImageType = dlg.comboImageType.Text;
                if (int.TryParse(dlg.textMinimumPixels.Text, out int value))
                {
                    Config.MinimumEdgePixels = value;
                }
            }
        }
    }
}
