// MIT License
// 
// Copyright (c) 2020-2021 Kazuya Ujihara
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

using Parago.Windows;
using System;

namespace NCDK_ExcelAddIn
{
    public static class Stuff
    {
        public static bool EnableProgressBar { get; } =
#if DEBUG && !FORCE_ENABLE_PROGRESS_BAR
            false
#else
            true
#endif
            ;

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
