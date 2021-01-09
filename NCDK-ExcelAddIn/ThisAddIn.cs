// MIT License
// 
// Copyright (c) 2018-2021 Kazuya Ujihara
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

// To run on debugger,
// set proper values to "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Office\Excel\Addins\NCDK-ExcelAddIn"
// or "HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Office\Excel\Addins\NCDK-ExcelAddIn" entry.
// See setup projects.

using System;
using System.IO;

namespace NCDK_ExcelAddIn
{
    public partial class ThisAddIn
    {
        private string addinPath;

        private void RegisterXLL()
        {
            const string xllName32 = "NCDK-Excel-AddIn.xll";
            const string xllName64 = "NCDK-Excel-AddIn64.xll";
            var asm = System.Reflection.Assembly.GetExecutingAssembly();
            string currPath = Path.GetDirectoryName(asm.Location);
            string filename;
            if (Environment.Is64BitProcess)
            {
                filename = xllName64;
            }
            else
            {
                filename = xllName32;
            }

            string path;

            path = Path.Combine(currPath, filename);
            if (!File.Exists(path))
            {
                path = new FileInfo(new Uri(asm.CodeBase).LocalPath).DirectoryName;
                path = Path.Combine(path, filename);
            }

            if (!File.Exists(path))
                path = path.Replace(@"\NCDK-ExcelAddIn\", @"\NCDK-Excel\");

            if (!File.Exists(path))
                throw new Exception($"'{path}' is not found.");

            addinPath = path;
            Application.RegisterXLL(addinPath);
        }

        private void UnregisterXLL()
        {
#if false
            // following code is not required if this xll is resisted by Application.RegisterXLL method.
            // but it can be effective when it shuted down abnormally on previous session.
            var reOpenDD = new System.Text.RegularExpressions.Regex("^OPEN(\\d*)$", System.Text.RegularExpressions.RegexOptions.Compiled);
            var key = Microsoft.Win32.Registry.CurrentUser
                .OpenSubKey("Software")
                .OpenSubKey("Microsoft")
                .OpenSubKey("Office")
                .OpenSubKey(Application.Version)
                .OpenSubKey("Excel")
                .OpenSubKey("Options");
            foreach (var name in key.GetValueNames())
            {
                if (reOpenDD.IsMatch(name))
                {
                    var val = key.GetValue(name) as string;
                    if (val == null)
                        continue;

                    if (val.EndsWith("\"" + addinPath + "\""))
                    {
                        key.DeleteValue(name);
                        break;
                    }
                }
            }
#endif
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            RegisterXLL();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            UnregisterXLL();
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        #endregion
    }
}
