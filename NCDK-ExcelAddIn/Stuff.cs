using NCDK;
using NCDK.Depict;
using NCDK.IO;
using NCDK.Renderers.Colors;
using System;
using System.Collections.Generic;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace NCDK_ExcelAddIn
{
    public static class Stuff
    {
        private readonly static object syncLock = new object();

        private static DepictionGenerator pictureGenerator;
        public static DepictionGenerator PictureGenerator
        {
            get
            {
                if (pictureGenerator == null)
                    lock (syncLock)
                    {
                        if (pictureGenerator == null)
                            pictureGenerator = new DepictionGenerator
                            {
                                AtomColorer = new CDK2DAtomColors(),
                                BackgroundColor = System.Windows.Media.Colors.Transparent,
                            };
                    }
                return pictureGenerator;
            }
        }

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
