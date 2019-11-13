using Microsoft.VisualStudio.TestTools.UnitTesting;
using static NCDKExcel.QED.QEDParameterTypes;

namespace NCDKExcel
{
    [TestClass()]
    public class QEDTests
    {
        [TestMethod()]
        public void PropertiesTest()
        {
            var m = Chem.MolFromSmiles("N=C(CCSCc1csc(N=C(N)N)n1)NS(N)(=O)=O");
            var p = QED.CreateProperties(m);
            Assert.AreEqual(337.456, p[MW], 0.01);
            Assert.AreEqual(-0.55833, p[ALOGP], 0.01);
            Assert.AreEqual(6, p[HBA]);
            Assert.AreEqual(5, p[HBD]);
            Assert.AreEqual(173.33, p[PSA], 0.01);
            Assert.AreEqual(7, p[ROTB]);
            Assert.AreEqual(1, p[AROM]);
            Assert.AreEqual(3, p[ALERTS]);

            p = QED.CreateProperties(Chem.AddHs(m));
            Assert.AreEqual(337.456, p[MW], 0.01);
            Assert.AreEqual(-0.55833, p[ALOGP], 0.01);
            Assert.AreEqual(6, p[HBA]);
            Assert.AreEqual(5, p[HBD]);
            Assert.AreEqual(173.33, p[PSA], 0.01);
            Assert.AreEqual(7, p[ROTB]);
            Assert.AreEqual(1, p[AROM]);
            Assert.AreEqual(3, p[ALERTS]);
        }
    }
}
