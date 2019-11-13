using GraphMolWrap;

namespace NCDKExcel
{
    public static partial class Descriptors
    {
        public static double MolWt(ROMol mol, bool onlyHeavy = false)
        {
            return RDKFuncs.calcAMW(mol, onlyHeavy);
        }

        public static double ExactMolWt(ROMol mol, bool onlyHeavy = false)
        {
            return RDKFuncs.calcExactMW(mol, onlyHeavy);
        }

        public static int CalcNumHBA(ROMol mol)
        {
            return (int)RDKFuncs.calcNumHBA(mol);
        }

        public static int CalcNumHBD(ROMol mol)
        {
            return (int)RDKFuncs.calcNumHBD(mol);
        }

        public static int CalcLipinskiHBA(ROMol mol)
        {
            return (int)RDKFuncs.calcLipinskiHBA(mol);
        }

        public static int CalcLipinskiHBD(ROMol mol)
        {
            return (int)RDKFuncs.calcLipinskiHBD(mol);
        }

        public static int CalcNumRotatableBonds(ROMol mol, NumRotatableBondsOptions strict = NumRotatableBondsOptions.Default)
        {
            return (int)RDKFuncs.calcNumRotatableBonds(mol, strict);
        }

        public static double CalcTPSA(ROMol mol, bool force = false, bool includeSandP = false)
        {
            return RDKFuncs.calcTPSA(mol, force, includeSandP);
        }
    }
}