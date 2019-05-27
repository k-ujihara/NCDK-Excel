using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCDK.Fingerprints;
using System.Collections;

namespace NCDKExcel
{
    [TestClass()]
    public class UtilityTests
    {
        [TestMethod()]
        public void ToExcelStringObjectTest()
        {
            Assert.AreEqual("#N/A", Utility.ToExcelString(double.NaN));
            Assert.AreEqual("#NUM!", Utility.ToExcelString(double.NegativeInfinity));
            Assert.AreEqual("#NUM!", Utility.ToExcelString(double.PositiveInfinity));
        }

        [TestMethod()]
        public void ToExcelStringIBitFingerprintTest()
        {
            IBitFingerprint fp;
            fp = new BitSetFingerprint(4);
            Assert.AreEqual("0000", Utility.ToExcelString(fp));
            fp = new BitSetFingerprint(new BitArray(new bool[] { true, false, true }));
            Assert.AreEqual("101", Utility.ToExcelString(fp));
        }

        [TestMethod()]
        public void ParseTest()
        {
            Assert.IsNotNull(Utility.Parse("C"));
            Assert.IsNull(Utility.Parse("qwertyuop"));
        }
    }
}