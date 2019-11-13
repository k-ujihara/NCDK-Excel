using GraphMolWrap;

namespace NCDKExcel
{
    public static class Chem
    {
        public static Match_Vect_Vect GetSubstructMatches(this ROMol mol, ROMol pattern)
        {
            return mol.getSubstructMatches(pattern);
        }

        public static bool HasSubstructMatch(this ROMol mol, ROMol query)
        {
            return mol.hasSubstructMatch(query);
        }

        public static ROMol DeleteSubstructs(ROMol mol, ROMol query, bool replaceAll = true)
        {
            return mol.deleteSubstructs(query, replaceAll);
        }

        public static RWMol MolFromSmiles(string smiles, bool sanitize = true)
        {
            return RWMol.MolFromSmiles(smiles, 0, sanitize);
        }

        public static RWMol MolFromSmarts(string smiles, bool mergeHs = false)
        {
            return RWMol.MolFromSmarts(smiles, 0, mergeHs);
        }

        public static ROMol AddHs(this ROMol mol, bool explicitOnly = false, bool addCoords = false)
        {
            return mol.addHs(explicitOnly, addCoords);
        }

        public static ROMol RemoveHs(this ROMol mol, bool implicitOnly = false, bool updateExplicitCount = false, bool sanitize = true)
        {
            return mol.removeHs(implicitOnly, updateExplicitCount, sanitize);
        }

        public static int GetSSSR(ROMol mol)
        {
            return RDKFuncs.findSSSR(mol);
        }

        public static RWMol Mol(ROMol mol)
        {
            return new RWMol(mol);
        }
    }
}
