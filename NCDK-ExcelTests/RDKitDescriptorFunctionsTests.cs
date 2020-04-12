using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NCDKExcel
{
    [TestClass()]
    public class RDKitDescriptorFunctionsTests
    {
        [TestMethod()]
        public void ParseTest()
        {
            Assert.IsNotNull(RDKitMol.Parse("C"));
            const string InvalidValue = "qwertyuop";
            Assert.IsNull(RDKitMol.Parse(InvalidValue));
        }
    }
}
