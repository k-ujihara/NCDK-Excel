using GraphMolWrap;

namespace RDKit
{
    public static partial class GraphMolWrapTools
    {
        public static Match_Vect_Vect GetSubstructMatches(this ROMol mol, ROMol pattern)
        {
            return mol.getSubstructMatches(pattern);
        }

        public static bool HasSubstructMatch(this ROMol mol, ROMol query)
        {
            return mol.hasSubstructMatch(query);
        }

        public static ROMol DeleteSubstructs(this ROMol mol, ROMol query, bool replaceAll = false)
        {
            return mol.deleteSubstructs(query, replaceAll);
        }

        public static ROMol AddHs(this ROMol mol, bool explicitOnly = false, bool addCoords = false)
        {
            return mol.addHs(explicitOnly, addCoords);
        }

        public static ROMol RemoveHs(this ROMol mol, bool implicitOnly = false,
            bool updateExplicitCount = false, bool sanitize = true)
        {
            return mol.removeHs(implicitOnly, updateExplicitCount, sanitize);
        }

        public static int Count(this BitVect bv)
            => (int)bv.size();

        public static void ClearBits(this BitVect bv)
            => bv.clearBits();

        public static bool GetBit(this BitVect bv, int which)
            => bv.getBit((uint)which);

        public static bool SetBit(this BitVect bv, int which)
            => bv.setBit((uint)which);

        public static bool UnsetBit(this BitVect bv, int which)
            => bv.unsetBit((uint)which);

        public static int GetNumBits(this BitVect bv)
            => (int)bv.getNumBits();

        public static int GetNumOffBits(this BitVect bv)
            => (int)bv.getNumOffBits();

        public static int GetNumOnBits(this BitVect bv)
            => (int)bv.getNumOnBits();

        public static void GetOnBits(this BitVect bv, Int_Vect v)
            => bv.getOnBits(v);

        public static int Count(this SparseIntVect32 v)
            => (int)v.size();

        public static Match_Vect GetNonzero(this SparseIntVect32 v)
            => v.getNonzero();


        public static int Count(this SparseIntVectu32 v)
            => (int)v.size();

        public static UInt_Pair_Vect GetNonzero(this SparseIntVectu32 v)
            => v.getNonzero();

        public static int Count(this SparseIntVect64 v)
            => (int)v.size();

        public static Long_Pair_Vect GetNonzero(this SparseIntVect64 v)
            => v.getNonzero();
    }
}
