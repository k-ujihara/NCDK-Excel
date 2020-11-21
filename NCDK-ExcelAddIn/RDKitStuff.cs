using GraphMolWrap;
using Parago.Windows;
using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using static NCDK_ExcelAddIn.Stuff;

namespace NCDK_ExcelAddIn
{
    public static class RDKitStuff
    {
        private static void _LoadSDFToNewSheet(string sdfName, ref object newSheet, ref int row)
        {
            var keyIndex = new Dictionary<string, int>();
            const int ColumnTitle = 1;
            const int ColumnMolBlock = 2;
            int endIndex = ColumnMolBlock + 1; // for Title:1

            using (var suppl = new SDMolSupplier(sdfName))
            {
                int numSuppliedMol = 0;

                while (!suppl.atEnd())
                {
                    using (var mol = suppl.next())
                    {
                        if (mol == null)
                            continue;

                        if (newSheet == null)
                        {
                            newSheet = Globals.ThisAddIn.Application.Sheets.Add();
                            ((dynamic)newSheet).Cells[1, ColumnTitle] = "Title";
                            ((dynamic)newSheet).Cells[1, ColumnMolBlock] = "MOL Text";
                        }
                        Excel.Range cells = ((dynamic)newSheet).Cells;
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
                        cells[row, ColumnMolBlock] = mol.MolToMolBlock();
                        row++;
                    }

                    numSuppliedMol++;
                    if (EnableProgressBar)
                        ProgressDialog.Current.ReportWithCancellationCheck($"Reading: {numSuppliedMol}");
                }
            }
        }

        /// <summary>
        /// Read molecules and their info from SD file. 
        /// </summary>
        /// <param name="sdfName">File name of the SD File.</param>
        public static void LoadSDFToNewSheet(string sdfName)
        {
            var saveScreenUpdating = Globals.ThisAddIn.Application.ScreenUpdating;
            var saveCalculation = Globals.ThisAddIn.Application.Calculation;
            try
            {
                object newSheet = null;
                int row = 2;
                try { Globals.ThisAddIn.Application.ScreenUpdating = false; } catch (Exception) { }
                try { Globals.ThisAddIn.Application.Calculation = Excel.XlCalculation.xlCalculationManual; } catch (Exception) { }
                if (EnableProgressBar)
                {
                    var result = ProgressDialog.Execute(null, "Loading SDF", () => _LoadSDFToNewSheet(sdfName, ref newSheet, ref row), ProgressDialogSettings.WithSubLabelAndCancel);
                }
                else
                    _LoadSDFToNewSheet(sdfName, ref newSheet, ref row);
                if (newSheet != null)
                {
                    var height = ((dynamic)newSheet).Rows[1].RowHeight;
                    var rows = ((dynamic)newSheet).Rows;
                    for (int i = 2; i < row; i++)
                    {
                        rows[i].RowHeight = height;
                    }
                }
            }
            finally
            {
                try { Globals.ThisAddIn.Application.Calculation = saveCalculation; } catch (Exception) { }
                try { Globals.ThisAddIn.Application.ScreenUpdating = saveScreenUpdating; } catch (Exception) { }
            }
        }
    }
}
