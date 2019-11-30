using GraphMolWrap;

namespace RDKit
{
    public static partial class Descriptors
    {
        //
        // rdMolDescriptors
        //

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

        public static double CalcChiNn(ROMol mol, uint n, bool force = false)
            => RDKFuncs.calcChiNn(mol, n, force);

        public static double CalcChiNv(ROMol mol, uint n, bool force = false)
            => RDKFuncs.calcChiNv(mol, n, force);

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

        public static uint CalcNumAliphaticCarbocycles(ROMol mol)
            => RDKFuncs.calcNumAliphaticCarbocycles(mol);

        public static uint CalcNumAliphaticHeterocycles(ROMol mol)
            => RDKFuncs.calcNumAliphaticHeterocycles(mol);

        public static uint CalcNumAliphaticRings(ROMol mol)
            => RDKFuncs.calcNumAliphaticRings(mol);

        public static uint CalcNumAmideBonds(ROMol mol)
            => RDKFuncs.calcNumAmideBonds(mol);

        public static uint CalcNumAromaticCarbocycles(ROMol mol)
            => RDKFuncs.calcNumAromaticCarbocycles(mol);

        public static uint CalcNumAromaticHeterocycles(ROMol mol)
            => RDKFuncs.calcNumAromaticHeterocycles(mol);

        public static uint CalcNumAromaticRings(ROMol mol)
            => RDKFuncs.calcNumAromaticRings(mol);

        public static uint CalcNumAtomStereoCenters(ROMol mol)
            => RDKFuncs.numAtomStereoCenters(mol);

        public static uint CalcNumBridgeheadAtoms(ROMol mol, UInt_Vect atoms = null)
            => RDKFuncs.calcNumBridgeheadAtoms(mol, atoms);

        public static uint CalcNumHBA(ROMol mol)
            => RDKFuncs.calcNumHBA(mol);

        public static uint CalcNumHBD(ROMol mol)
            => RDKFuncs.calcNumHBD(mol);

        public static uint CalcNumHeteroatoms(ROMol mol)
            => RDKFuncs.calcNumHeteroatoms(mol);

        public static uint CalcNumHeterocycles(ROMol mol)
            => RDKFuncs.calcNumHeterocycles(mol);

        public static uint CalcNumLipinskiHBA(ROMol mol)
            => RDKFuncs.calcLipinskiHBA(mol);

        public static uint CalcNumLipinskiHBD(ROMol mol)
            => RDKFuncs.calcLipinskiHBD(mol);

        public static uint CalcNumRings(ROMol mol)
            => RDKFuncs.calcNumRings(mol);

        public static uint CalcNumRotatableBonds(ROMol mol, bool strict)
            => RDKFuncs.calcNumRotatableBonds(mol, strict);

        public static uint CalcNumRotatableBonds(ROMol mol, NumRotatableBondsOptions useStrictDefinition = NumRotatableBondsOptions.Default)
            => RDKFuncs.calcNumRotatableBonds(mol, useStrictDefinition);

        public static uint CalcNumSaturatedCarbocycles(ROMol mol)
            => RDKFuncs.calcNumSaturatedCarbocycles(mol);

        public static uint CalcNumSaturatedHeterocycles(ROMol mol)
            => RDKFuncs.calcNumSaturatedHeterocycles(mol);

        public static uint CalcNumSaturatedRings(ROMol mol)
            => RDKFuncs.calcNumSaturatedRings(mol);

        public static uint CalcNumSpiroAtoms(ROMol mol, UInt_Vect atoms = null)
            => RDKFuncs.calcNumSpiroAtoms(mol, atoms);

        public static uint CalcNumUnspecifiedAtomStereoCenters(ROMol mol)
            => RDKFuncs.numUnspecifiedAtomStereoCenters(mol);

        public static double CalcTPSA(ROMol mol, bool force = false, bool includeSandP = false)
            => RDKFuncs.calcTPSA(mol, force, includeSandP);

        public static Double_Vect CustomProp_VSA_(ROMol mol, string customPropName, Double_Vect bins, bool force = false)
            => RDKFuncs.calcCustomProp_VSA(mol, customPropName, bins, force);

        public static uint GetAtomPairCode(uint codeI, uint codeJ, uint dist, bool includeChirality)
            => RDKFuncs.getAtomPairCode(codeI, codeJ, dist, includeChirality);

        public static SparseIntVect32 GetAtomPairFingerprint(ROMol mol, uint minLength = 1, uint maxLength = 30, UInt_Vect fromAtoms = null, UInt_Vect ignoreAtoms = null, UInt_Vect atomInvariants = null, bool includeChirality = false, bool use2D = true, int confId = -1)
            => RDKFuncs.getAtomPairFingerprint(mol, minLength, maxLength, fromAtoms, ignoreAtoms, atomInvariants, includeChirality, use2D, confId);

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

        public static SparseIntVect32 GetHashedAtomPairFingerprint(ROMol mol, uint nBits = 2048, uint minLength = 1, uint maxLength = 30, UInt_Vect fromAtoms = null, UInt_Vect ignoreAtoms = null, UInt_Vect atomInvariants = null, bool includeChirality = false , bool use2D = true, int confId = -1)
            => RDKFuncs.getHashedAtomPairFingerprint(mol, nBits, minLength, maxLength, fromAtoms, ignoreAtoms, atomInvariants, includeChirality, use2D, confId);

        public static ExplicitBitVect GetHashedAtomPairFingerprint(ROMol mol, uint nBits = 2048, uint minLength = 1, uint maxLength = 30, UInt_Vect fromAtoms = null, UInt_Vect ignoreAtoms = null, UInt_Vect atomInvariants = null, uint nBitsPerEntry = 4, bool includeChirality = false, bool use2D = true, int confId = -1)
            => RDKFuncs.getHashedAtomPairFingerprintAsBitVect(mol, nBits, minLength, maxLength, fromAtoms, ignoreAtoms, atomInvariants, nBitsPerEntry, includeChirality, use2D, confId);

        public static SparseIntVect64 GetHashedTopologicalTorsionFingerprint(ROMol mol, uint nBits = 2048, uint targetSize = 4, UInt_Vect fromAtoms = null, UInt_Vect ignoreAtoms = null, UInt_Vect atomInvariants = null, bool includeChirality = false)
            => RDKFuncs.getHashedTopologicalTorsionFingerprint(mol, nBits, targetSize, fromAtoms, ignoreAtoms, atomInvariants, includeChirality);

        public static ExplicitBitVect GetHashedTopologicalTorsionFingerprintAsBitVect(ROMol mol, uint nBits = 2048, uint targetSize = 4, UInt_Vect fromAtoms = null, UInt_Vect ignoreAtoms = null, UInt_Vect atomInvariants = null, uint nBitsPerEntry = 4, bool includeChirality = false)
            => RDKFuncs.getHashedTopologicalTorsionFingerprintAsBitVect(mol, nBits, targetSize, fromAtoms, ignoreAtoms, atomInvariants, nBitsPerEntry, includeChirality);

        public static ExplicitBitVect GetMACCSKeysFingerprint(ROMol mol)
            => RDKFuncs.MACCSFingerprintMol(mol);

        public static SparseIntVectu32 GetMorganFingerprint(ROMol mol, uint radius, UInt_Vect invariants = null, UInt_Vect fromAtoms = null, bool useChirality = false, bool useBondTypes = true, bool onlyNonzeroInvariants = false, bool useCounts = true, BitInfoMap atomsSettingBits = null)
        {
            if (invariants == null)
                invariants = new UInt_Vect(0);
            if (fromAtoms == null)
                fromAtoms = new UInt_Vect(0);
            return RDKFuncs.MorganFingerprintMol(mol, radius, invariants, fromAtoms, useChirality, useBondTypes, useCounts, onlyNonzeroInvariants, atomsSettingBits);
        }

        public static ExplicitBitVect GetMorganFingerprintAsBitVect(ROMol mol, uint radius, uint nBits = 2048, UInt_Vect invariants = null, UInt_Vect fromAtoms = null, bool useChirality= false, bool useBondTypes = true, bool onlyNonzeroInvariants = false, BitInfoMap atomsSettingBits = null)
        {
            if (invariants == null)
                invariants = new UInt_Vect(0);
            if (fromAtoms == null)
                fromAtoms = new UInt_Vect(0);
            return RDKFuncs.getMorganFingerprintAsBitVect(mol, radius, nBits, invariants, fromAtoms, useChirality, useBondTypes, onlyNonzeroInvariants, atomsSettingBits);
        }

        public static SparseIntVect64 GetTopologicalTorsionFingerprint(ROMol mol, uint targetSize = 4, UInt_Vect fromAtoms = null, UInt_Vect ignoreAtoms = null, UInt_Vect atomInvariants = null, bool includeChirality = false)
            => RDKFuncs.getTopologicalTorsionFingerprint(mol, targetSize, fromAtoms, ignoreAtoms, atomInvariants, includeChirality);

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
