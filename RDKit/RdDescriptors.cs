using GraphMolWrap;

namespace RDKit
{
    public static partial class Chem
    {
        //
        // rdMolDescriptors
        //

        // MakePropertyRangeQuery

        public static double CalcChi0n(ROMol mol, bool force = false)
            => RDKFuncs.calcChi0n(mol, force);

        public static double CalcChi0v(ROMol mol, bool force = false)
            => RDKFuncs.calcChi0v(mol, force);

        public static double CalcChi1n(ROMol mol, bool force = false)
            => RDKFuncs.calcChi1n(mol, force);

        public static double CalcChi1v(ROMol mol, bool force = false)
            => RDKFuncs.calcChi1v(mol, force);

        public static double CalcChi2n(ROMol mol, bool force = false)
            => RDKFuncs.calcChi2n(mol, force);

        public static double CalcChi2v(ROMol mol, bool force = false)
            => RDKFuncs.calcChi2v(mol, force);

        public static double CalcChi3n(ROMol mol, bool force = false)
            => RDKFuncs.calcChi3n(mol, force);

        public static double CalcChi3v(ROMol mol, bool force = false)
            => RDKFuncs.calcChi3v(mol, force);

        public static double CalcChi4n(ROMol mol, bool force = false)
            => RDKFuncs.calcChi4n(mol, force);

        public static double CalcChi4v(ROMol mol, bool force = false)
            => RDKFuncs.calcChi4v(mol, force);

        public static double CalcChiNn(ROMol mol, int n, bool force = false)
            => RDKFuncs.calcChiNn(mol, (uint)n, force);

        public static double CalcChiNv(ROMol mol, int n, bool force = false)
            => RDKFuncs.calcChiNv(mol, (uint)n, force);

        public static Double_Pair CalcCrippenDescriptors(ROMol mol, bool includeHs = true, bool force = false)
            => RDKFuncs.calcCrippenDescriptors(mol, includeHs, force);

        public static double CalcExactMolWt(ROMol mol, bool onlyHeavy = false)
            => RDKFuncs.calcExactMW(mol, onlyHeavy);

        public static double CalcFractionCSP3(ROMol mol)
            => RDKFuncs.calcFractionCSP3(mol);

        public static double CalcHallKierAlpha(ROMol mol, Double_Vect atomContribs = null)
            => RDKFuncs.calcHallKierAlpha(mol, atomContribs);

        public static double CalcKappa1(ROMol mol)
            => RDKFuncs.calcKappa1(mol);

        public static double CalcKappa2(ROMol mol)
            => RDKFuncs.calcKappa2(mol);

        public static double CalcKappa3(ROMol mol)
            => RDKFuncs.calcKappa3(mol);

        public static double CalcLabuteASA(ROMol mol, bool includeHs = true, bool force = false)
            => RDKFuncs.calcLabuteASA(mol, includeHs, force);

        public static string CalcMolFormula(ROMol mol, bool separateIsotopes = false, bool abbreviateHIsotopes = true)
            => RDKFuncs.calcMolFormula(mol, separateIsotopes, abbreviateHIsotopes);

        public static int CalcNumAliphaticCarbocycles(ROMol mol)
            => (int)RDKFuncs.calcNumAliphaticCarbocycles(mol);

        public static int CalcNumAliphaticHeterocycles(ROMol mol)
            => (int)RDKFuncs.calcNumAliphaticHeterocycles(mol);

        public static int CalcNumAliphaticRings(ROMol mol)
            => (int)RDKFuncs.calcNumAliphaticRings(mol);

        public static int CalcNumAmideBonds(ROMol mol)
            => (int)RDKFuncs.calcNumAmideBonds(mol);

        public static int CalcNumAromaticCarbocycles(ROMol mol)
            => (int)RDKFuncs.calcNumAromaticCarbocycles(mol);

        public static int CalcNumAromaticHeterocycles(ROMol mol)
            => (int)RDKFuncs.calcNumAromaticHeterocycles(mol);

        public static int CalcNumAromaticRings(ROMol mol)
            => (int)RDKFuncs.calcNumAromaticRings(mol);

        public static int CalcNumAtomStereoCenters(ROMol mol)
            => (int)RDKFuncs.numAtomStereoCenters(mol);

        public static int CalcNumBridgeheadAtoms(ROMol mol, UInt_Vect atoms = null)
            => (int)RDKFuncs.calcNumBridgeheadAtoms(mol, atoms);

        public static int CalcNumHBA(ROMol mol)
            => (int)RDKFuncs.calcNumHBA(mol);

        public static int CalcNumHBD(ROMol mol)
            => (int)RDKFuncs.calcNumHBD(mol);

        public static int CalcNumHeteroatoms(ROMol mol)
            => (int)RDKFuncs.calcNumHeteroatoms(mol);

        public static int CalcNumHeterocycles(ROMol mol)
            => (int)RDKFuncs.calcNumHeterocycles(mol);

        public static int CalcNumLipinskiHBA(ROMol mol)
            => (int)RDKFuncs.calcLipinskiHBA(mol);

        public static int CalcNumLipinskiHBD(ROMol mol)
            => (int)RDKFuncs.calcLipinskiHBD(mol);

        public static int CalcNumRings(ROMol mol)
            => (int)RDKFuncs.calcNumRings(mol);

        public static int CalcNumRotatableBonds(ROMol mol, bool strict)
            => (int)RDKFuncs.calcNumRotatableBonds(mol, strict);

        public static int CalcNumRotatableBonds(ROMol mol, NumRotatableBondsOptions useStrictDefinition = NumRotatableBondsOptions.Default)
            => (int)RDKFuncs.calcNumRotatableBonds(mol, useStrictDefinition);

        public static int CalcNumSaturatedCarbocycles(ROMol mol)
            => (int)RDKFuncs.calcNumSaturatedCarbocycles(mol);

        public static int CalcNumSaturatedHeterocycles(ROMol mol)
            => (int)RDKFuncs.calcNumSaturatedHeterocycles(mol);

        public static int CalcNumSaturatedRings(ROMol mol)
            => (int)RDKFuncs.calcNumSaturatedRings(mol);

        public static int CalcNumSpiroAtoms(ROMol mol, UInt_Vect atoms = null)
            => (int)RDKFuncs.calcNumSpiroAtoms(mol, atoms);

        public static int CalcNumUnspecifiedAtomStereoCenters(ROMol mol)
            => (int)RDKFuncs.numUnspecifiedAtomStereoCenters(mol);

        public static double CalcTPSA(ROMol mol, bool force = false, bool includeSandP = false)
            => RDKFuncs.calcTPSA(mol, force, includeSandP);

        public static Double_Vect CustomProp_VSA_(ROMol mol, string customPropName, Double_Vect bins, bool force = false)
            => RDKFuncs.calcCustomProp_VSA(mol, customPropName, bins, force);

        public static int GetAtomPairCode(int codeI, int codeJ, int dist, bool includeChirality)
            => (int)RDKFuncs.getAtomPairCode((uint)codeI, (uint)codeJ, (uint)dist, includeChirality);

        public static SparseIntVect32 GetAtomPairFingerprint(ROMol mol, int minLength = 1, int maxLength = 30, UInt_Vect fromAtoms = null, UInt_Vect ignoreAtoms = null, UInt_Vect atomInvariants = null, bool includeChirality = false, bool use2D = true, int confId = -1)
            => RDKFuncs.getAtomPairFingerprint(mol, (uint)minLength, (uint)maxLength, fromAtoms, ignoreAtoms, atomInvariants, includeChirality, use2D, confId);

        public static UInt_Vect GetConnectivityInvariants(ROMol mol, bool includeRingMembership)
        {
            var invars = new UInt_Vect((int)mol.getNumAtoms());
            RDKFuncs.getConnectivityInvariants(mol, invars, includeRingMembership);
            return invars;
        }

        public static UInt_Vect GetFeatureInvariants(ROMol mol)
        {
            var invars = new UInt_Vect((int)mol.getNumAtoms());
            RDKFuncs.getFeatureInvariants(mol, invars);
            return invars;
        }

        public static SparseIntVect32 GetHashedAtomPairFingerprint(ROMol mol, int nBits = 2048, int minLength = 1, int maxLength = 30, UInt_Vect fromAtoms = null, UInt_Vect ignoreAtoms = null, UInt_Vect atomInvariants = null, bool includeChirality = false , bool use2D = true, int confId = -1)
            => RDKFuncs.getHashedAtomPairFingerprint(mol, (uint)nBits, (uint)minLength, (uint)maxLength, fromAtoms, ignoreAtoms, atomInvariants, includeChirality, use2D, confId);

        public static ExplicitBitVect GetHashedAtomPairFingerprintAsBitVect(ROMol mol, int nBits = 2048, int minLength = 1, int maxLength = 30, UInt_Vect fromAtoms = null, UInt_Vect ignoreAtoms = null, UInt_Vect atomInvariants = null, int nBitsPerEntry = 4, bool includeChirality = false, bool use2D = true, int confId = -1)
            => RDKFuncs.getHashedAtomPairFingerprintAsBitVect(mol, (uint)nBits, (uint)minLength, (uint)maxLength, fromAtoms, ignoreAtoms, atomInvariants, (uint)nBitsPerEntry, includeChirality, use2D, confId);

        public static SparseIntVect64 GetHashedTopologicalTorsionFingerprint(ROMol mol, int nBits = 2048, int targetSize = 4, UInt_Vect fromAtoms = null, UInt_Vect ignoreAtoms = null, UInt_Vect atomInvariants = null, bool includeChirality = false)
            => RDKFuncs.getHashedTopologicalTorsionFingerprint(mol, (uint)nBits, (uint)targetSize, fromAtoms, ignoreAtoms, atomInvariants, includeChirality);

        public static ExplicitBitVect GetHashedTopologicalTorsionFingerprintAsBitVect(ROMol mol, int nBits = 2048, int targetSize = 4, UInt_Vect fromAtoms = null, UInt_Vect ignoreAtoms = null, UInt_Vect atomInvariants = null, int nBitsPerEntry = 4, bool includeChirality = false)
            => RDKFuncs.getHashedTopologicalTorsionFingerprintAsBitVect(mol, (uint)nBits, (uint)targetSize, fromAtoms, ignoreAtoms, atomInvariants, (uint)nBitsPerEntry, includeChirality);

        public static ExplicitBitVect GetMACCSKeysFingerprint(ROMol mol)
            => RDKFuncs.MACCSFingerprintMol(mol);

        public static SparseIntVectu32 GetMorganFingerprint(ROMol mol, int radius, UInt_Vect invariants = null, UInt_Vect fromAtoms = null, bool useChirality = false, bool useBondTypes = true, bool onlyNonzeroInvariants = false, bool useCounts = true, BitInfoMap atomsSettingBits = null)
        {
            if (invariants == null)
                invariants = new UInt_Vect(0);
            if (fromAtoms == null)
                fromAtoms = new UInt_Vect(0);
            return RDKFuncs.MorganFingerprintMol(mol, (uint)radius, invariants, fromAtoms, useChirality, useBondTypes, useCounts, onlyNonzeroInvariants, atomsSettingBits);
        }

        public static ExplicitBitVect GetMorganFingerprintAsBitVect(ROMol mol, int radius, int nBits = 2048, UInt_Vect invariants = null, UInt_Vect fromAtoms = null, bool useChirality= false, bool useBondTypes = true, bool onlyNonzeroInvariants = false, BitInfoMap atomsSettingBits = null)
        {
            if (invariants == null)
                invariants = new UInt_Vect(0);
            if (fromAtoms == null)
                fromAtoms = new UInt_Vect(0);
            return RDKFuncs.getMorganFingerprintAsBitVect(mol, (uint)radius, (uint)nBits, invariants, fromAtoms, useChirality, useBondTypes, onlyNonzeroInvariants, atomsSettingBits);
        }

        public static SparseIntVect64 GetTopologicalTorsionFingerprint(ROMol mol, int targetSize = 4, UInt_Vect fromAtoms = null, UInt_Vect ignoreAtoms = null, UInt_Vect atomInvariants = null, bool includeChirality = false)
            => RDKFuncs.getTopologicalTorsionFingerprint(mol, (uint)targetSize, fromAtoms, ignoreAtoms, atomInvariants, includeChirality);

        public static UInt_Vect MQNs_(ROMol mol, bool force = false)
            => RDKFuncs.calcMQNs(mol, force);

        public static Double_Vect PEOE_VSA_(ROMol mol, Double_Vect bins = null, bool force = false)
        {
            if (bins == null)
                bins = new Double_Vect(0);
            return RDKFuncs.calcPEOE_VSA(mol, bins, force);
        }

        public static Double_Vect SMR_VSA_(ROMol mol, Double_Vect bins = null, bool force = false)
        {
            if (bins == null)
                bins = new Double_Vect(0);
            return RDKFuncs.calcSMR_VSA(mol, bins, force);
        }

        public static Double_Vect SlogP_VSA_(ROMol mol, Double_Vect bins = null, bool force = false)
        {
            if (bins == null)
                bins = new Double_Vect(0);
            return RDKFuncs.calcSlogP_VSA(mol, bins, force);
        }
    }
}
