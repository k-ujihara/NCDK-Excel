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
            }
            finally
            {
                Globals.ThisAddIn.Application.Calculation = saveCalculation;
                Globals.ThisAddIn.Application.ScreenUpdating = saveScreenUpdating;
            }
        }
    }
}
