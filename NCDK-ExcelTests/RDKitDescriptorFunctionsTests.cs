using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NCDKExcel
{
    [TestClass()]
    public class RDKitDescriptorFunctionsTests
    {
        [TestMethod()]
        public void ParseTest()
        {
            Assert.IsNotNull(RDKitUtility.Parse("C"));
            const string InvalidValue = "qwertyuop";
            Assert.IsNull(RDKitUtility.Parse(InvalidValue));
        }
    }
}
