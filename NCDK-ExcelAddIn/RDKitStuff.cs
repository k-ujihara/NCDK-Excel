using GraphMolWrap;
using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace NCDK_ExcelAddIn
{
    public static class RDKitStuff
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
            const int ColumnTitle = 1;
            int endIndex = ColumnTitle + 1; // for Title:1

            var saveScreenUpdating = Globals.ThisAddIn.Application.ScreenUpdating;
            var saveCalculation = Globals.ThisAddIn.Application.Calculation;
            try
            {
                Globals.ThisAddIn.Application.ScreenUpdating = false;
                Globals.ThisAddIn.Application.Calculation = Excel.XlCalculation.xlCalculationManual;

                using (var suppl = new SDMolSupplier(sdfName))
                {
                    while (!suppl.atEnd())
                    {
                        using (var mol = suppl.next())
                        {
                            if (mol == null)
                                continue;

                            if (newSheet == null)
                            {
                                newSheet = Globals.ThisAddIn.Application.Sheets.Add();
                                newSheet.Cells[1, ColumnTitle] = "Title";
                            }
                            Excel.Range cells = newSheet.Cells;
                            try
                            {
                                using (var keys = mol.getPropList())
                                {
                                    foreach (var key in keys)
                                    {
                                        switch (key)
                                        {
                                            case "_Name":
                                                cells[row, ColumnTitle] = mol.getProp(key);
                                                break;
                                            default:
                                                if (key.StartsWith("_", StringComparison.Ordinal))
                                                    break;
                                                if (!keyIndex.TryGetValue(key, out int index))
                                                {
                                                    keyIndex[key] = (index = endIndex++);
                                                    cells[1, index] = key;
                                                }
                                                var prop = mol.getProp(key);
                                                cells[row, index] = prop;
                                                break;
                                        }
                                    }
                                }
                            }
                            catch (Exception exception)
                            {
                                cells[row, ColumnTitle] = exception.Message;
                            }
                            row++;
                        }
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
