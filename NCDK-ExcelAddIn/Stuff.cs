using Parago.Windows;
using System;

namespace NCDK_ExcelAddIn
{
    public static class Stuff
    {
        public static bool EnableProgressBar { get; } = true;

        private static void AddChemicalStructuresCheckCancel()
        {
            if (EnableProgressBar)
                ProgressDialog.Current.ReportWithCancellationCheck("");
        }

        private class AddChemicalStructuresExecuter
        {
            readonly dynamic range;
            readonly IPictureGegerator pictureGenerator;

            public AddChemicalStructuresExecuter(dynamic range, IPictureGegerator pictureGenerator)
            {
                this.range = range;
                this.pictureGenerator = pictureGenerator;
            }

            public void Run()
            {
                ChemPictureTool.AddChemicalStructures(range, pictureGenerator, (Action)AddChemicalStructuresCheckCancel);
            }
        }

        public static void AddChemicalStructures(dynamic range, IPictureGegerator pictureGenerator)
        {
            var executer = new AddChemicalStructuresExecuter(range, pictureGenerator);

            if (EnableProgressBar)
            {
                var result = ProgressDialog.Execute(
                null,
                "Converting to image",
                (Action)executer.Run,
                ProgressDialogSettings.WithSubLabelAndCancel);
            }
            else
            {
                executer.Run();
            }
        }
    }
}
