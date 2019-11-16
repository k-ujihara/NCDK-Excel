using GraphMolWrap;

namespace RDKit
{
    public static partial class Chem
    {
        public static partial class Crippen
        {
            public static double MolLogP(ROMol mol)
            {
                return RDKFuncs.calcMolLogP(mol);
            }

            public static double MolMR(ROMol mol)
            {
                return RDKFuncs.calcMolMR(mol);
            }
        }
    }
}
