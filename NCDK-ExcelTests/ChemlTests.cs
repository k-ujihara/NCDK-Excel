using Microsoft.VisualStudio.TestTools.UnitTesting;
using RDKit;

namespace NCDKExcel
{
    [TestClass()]
    public class ChemTests
    {
        [TestMethod()]
        public void KekulizeTest()
        {
            {
                var mol = Chem.MolFromSmiles("c1ccccc1");
                Chem.Kekulize(mol);
                Assert.IsTrue(mol.getAtomWithIdx(0).getIsAromatic());
            }
            {
                var mol = Chem.MolFromSmiles("c1ccccc1");
                Chem.Kekulize(mol, clearAromaticFlags: true);
                Assert.IsFalse(mol.getAtomWithIdx(0).getIsAromatic());
            }
        }
    }
}
