using GraphMolWrap;

namespace RDKit
{
    public static partial class Chem
    {
        /// <summary>
        /// rdkit.Chem.Crippen module
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "<Pending>")]
        public static class Crippen
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
