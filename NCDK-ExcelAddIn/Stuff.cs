using Parago.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCDK_ExcelAddIn
{
    public static class Stuff
    {
        public static bool EnableProgressBar { get; } = false;

        private static void AddChemicalStructuresCheckCancel()
        {
            if (EnableProgressBar)
                ProgressDialog.Current.ReportWithCancellationCheck("");
        }

        public static void AddChemicalStructures(dynamic range, IPictureGegerator pictureGenerator)
        {
            var result = ProgressDialog.Execute(
                null,
                "Converting to image",
                (Action)(() => ChemPictureTool.AddChemicalStructures(range, pictureGenerator, (Action)AddChemicalStructuresCheckCancel)),
                ProgressDialogSettings.WithSubLabelAndCancel);
        }
    }
}
