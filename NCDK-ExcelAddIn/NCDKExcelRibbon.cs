using Microsoft.Office.Tools.Ribbon;
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
                var fn = openFileDialog.FileName;
                var ex = Path.GetExtension(fn);
                switch (ex)
                {
                    case ".sdf":
                        Stuff.LoadSDFToNewSheet(fn);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

