using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCDK.Fingerprints;
using System.Collections;
using NCDK;
using NCDK_ExcelAddIn;
using System.Linq;

namespace NCDKExcel
{
    [TestClass()]
    public class ChemPictureToolTests
    {
        [TestMethod()]
        public void ToExcelStringObjectTest()
        {
            var prefix = "Prefix ";
            int number = 100;
            var list = Enumerable.Range(0, number).Select(n => $"{prefix}{n}").ToList();
            Assert.AreEqual($"{prefix}{number}", ChemPictureTool.CreateUniqueString(list, prefix));
            int removeNum = 50;
            list.RemoveAt(removeNum);
            Assert.AreEqual($"{prefix}{removeNum}", ChemPictureTool.CreateUniqueString(list, prefix));
        }
    }
}
