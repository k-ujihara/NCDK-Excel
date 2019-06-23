using Microsoft.VisualStudio.TestTools.UnitTesting;
using NCDKExcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCDKExcel
{
    [TestClass()]
    public class DescriptorFunctionsTests
    {
        [TestMethod()]
        public void NCDKByNameTest()
        {
            string smiles = "CCNcccccc";
            {
                var expected = DescriptorFunctions.NCDK_ECFP2(smiles);
                var actual = DescriptorFunctions.NCDKByName("ECFP2", smiles);
                Assert.AreEqual(expected, actual);
            }

            Assert.IsNull(DescriptorFunctions.NCDKByName("DummyDummy", smiles));

            {
                var expected = DescriptorFunctions.NCDK_XLogP(smiles);
                var actual = DescriptorFunctions.NCDKByName("XLogP", smiles);
                Assert.AreEqual(expected, double.Parse(actual), 0.01);
            }
        }
    }
}
