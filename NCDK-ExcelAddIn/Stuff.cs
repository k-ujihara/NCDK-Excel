using NCDK;
using NCDK.IO;
using System;
using System.Collections.Generic;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace NCDK_ExcelAddIn
{
    public static class Stuff
    {
        /// <summary>
        /// Read molecules and their info from SD file. 
        /// </summary>
        /// <param name="sdfName">File name of the SD File.</param>
        public static void LoadSDFToNewSheet(string sdfName)
        {
            dynamic newSheet = null;
            int row = 2;
            var keyIndex = new Dictionary<string, int>();
            const int ColumnMol = 1;
            const int ColumnTitle = 2;
            int endIndex = ColumnTitle + 1; // for mol:1, Title:2

            var saveScreenUpdating = Globals.ThisAddIn.Application.ScreenUpdating;
            var saveCalculation = Globals.ThisAddIn.Application.Calculation;
            try
            {
                Globals.ThisAddIn.Application.ScreenUpdating = false;
                Globals.ThisAddIn.Application.Calculation = Excel.XlCalculation.xlCalculationManual;

                using (var suppl = Chem.ForwardSDMolSupplier(new FileStream(sdfName, FileMode.Open)))
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
                            Excel.Range cells = newSheet.Cells;
                            try
                            {
                                using (var w = new MDLV2000Writer(sr))
                                {
                                    w.WriteMolecule(mol);
                                }
                                cells[row, ColumnMol] = sr.ToString();
                                cells[row, ColumnTitle] = mol.Title;
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
                                                cells[1, index] = key;
                                            }
                                            cells[row, index] = prop.Value.ToString();
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            catch (CDKException exception)
                            {
                                cells[row, ColumnMol] = exception.Message;
                            }
                        }
                        row++;
                    }
                }

                {
                    var height = newSheet.Rows[1].RowHeight;
                    var rows = newSheet.Rows;
                    for (int i = 2; i < row; i++)
                    {
                        rows[i].RowHeight = height;
                    }
                }
            }
            finally
            {
                Globals.ThisAddIn.Application.Calculation = saveCalculation;
                Globals.ThisAddIn.Application.ScreenUpdating = saveScreenUpdating;
            }
        }
    }
}
