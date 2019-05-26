using Microsoft.Office.Tools.Ribbon;
using NCDK;
using NCDK.IO;
using System;
using System.Collections.Generic;
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
                dynamic newSheet = null;
                int row = 2;
                var keyIndex = new Dictionary<string, int>();
                const int ColumnMol = 1;
                const int ColumnTitle = 2;
                int endIndex = ColumnTitle + 1; // for mol:1, Title:2

                var fn = openFileDialog.FileName;
                var ex = Path.GetExtension(fn);
                switch (ex)
                {
                    case ".sdf":
                        using (var suppl = Chem.ForwardSDMolSupplier(new FileStream(fn, FileMode.Open)))
                        {
                            foreach (var mol in suppl)
                            {
                                if (mol == null)
                                    continue;
                                
                                if (newSheet == null)
                                {
                                    newSheet = Globals.ThisAddIn.Application.Sheets.Add();
                                    newSheet.Cells[1, ColumnMol] = "Molecular";
                                    newSheet.Cells[1, ColumnTitle] = "Title";
                                }
                                using (var sr = new StringWriter())
                                {
                                    try
                                    {
                                        using (var w = new MDLV2000Writer(sr))
                                        {
                                            w.WriteMolecule(mol);
                                        }
                                        newSheet.Cells[row, ColumnMol] = sr.ToString();
                                        newSheet.Cells[row, ColumnTitle] = mol.Title;
                                        foreach (var prop in mol.GetProperties())
                                        {
                                            switch (prop.Key)
                                            {
                                                case string key:
                                                    if (key.Equals(CDKPropertyName.Title, StringComparison.Ordinal))
                                                        break;
                                                    if (!keyIndex.TryGetValue(key, out int index))
                                                    {
                                                        keyIndex[key] = (index = endIndex++);
                                                        newSheet.Cells[1, index] = key;
                                                    }
                                                    newSheet.Cells[row, index] = prop.Value.ToString();
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                    }
                                    catch (CDKException exception)
                                    {
                                        newSheet.Cells[row, ColumnMol] = exception.Message;
                                    }
                                }
                                newSheet.Rows[row].RowHeight = newSheet.Rows[1].RowHeight;
                                row++;
                           }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
