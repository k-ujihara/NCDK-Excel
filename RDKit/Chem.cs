using GraphMolWrap;
using System;

namespace RDKit
{
    public static partial class Chem
    {
        public enum SequenceFlavor
        {
            LAminoAcid = 0,
            DAminoAcid = 1,
            RNA_no_cap = 2,
            RNA_5_cap = 3,
            RNA_3_cap = 4,
            RNA_bath_cap = 5,
            DNA_no_cap = 6,
            DNA_5_cap = 7,
            DNA_3_cap = 8,
            DNA_bath_cap = 9,
            Default = LAminoAcid,
        }

        [Flags]
        public enum PDBFlavors
        {
            /// <summary>Write MODEL/ENDMDL lines around each record</summary>
            WriteMODEL = 1,
            /// <summary>Don't write any CONECT records</summary>
            DontWriteCONECT = 2,
            /// <summary>Write CONECT records in both directions</summary>
            WriteCONECTBoth = 4,
            /// <summary>Don't use multiple CONECTs to encode bond order</summary>
            DontUseMultipleCONECT = 8,
            /// <summary>Write MASTER record</summary>
            WriteMASTER = 16,
            /// <summary>Write TER record</summary>
            WriteTER = 32,
        }

        public static RWMol Mol()
        {
            return new RWMol();
        }

        public static RWMol Mol(ROMol mol)
        {
            return new RWMol(mol);
        }

        //
        // rdmolops 
        //

        public static void AddHs(RWMol mol, bool explicitOnly = false, bool addCoords = false,
            UInt_Vect onlyOnAtoms = null, bool addResidueInfo = false)
        {
            RDKFuncs.addHs(mol, explicitOnly, addCoords, onlyOnAtoms, addResidueInfo);
        }

        public static void AddRecursiveQueries(ROMol mol, StringMolMap queries, string propName)
        {
            RDKFuncs.addRecursiveQueries(mol, queries, propName);
        }

        public static void AssignChiralTypesFromBondDirs(ROMol mol, int confId = -1, bool replaceExistingTags = true)
        {
            RDKFuncs.assignChiralTypesFromBondDirs(mol, confId, replaceExistingTags);
        }

        public static void AssignRadicals(RWMol mol)
        {
            RDKFuncs.assignRadicals(mol);
        }

        public static void AssignStereochemistry(ROMol mol,
            bool cleanIt = false, bool force = false, bool flagPossibleStereoCenters = false)
        {
            RDKFuncs.assignStereochemistry(mol, cleanIt, force, flagPossibleStereoCenters);
        }

        public static void CleanUp(RWMol mol)
        {
            RDKFuncs.cleanUp(mol);
        }

        public static ROMol DeleteSubstructs(ROMol mol, ROMol query, bool onlyFrags = false, bool useChirality = false)
        {
            return RDKFuncs.deleteSubstructs(mol, query, onlyFrags, useChirality);
        }

        public static void DetectBondStereochemistry(ROMol mol, int confId = -1)
        {
            RDKFuncs.detectBondStereochemistry(mol, confId);
        }

        public static MolSanitizeException_Vect DetectChemistryProblems(ROMol mol, SanitizeFlags sanitizeOps = SanitizeFlags.SANITIZE_ALL)
        {
            return RDKFuncs.detectChemistryProblems(mol, (int)sanitizeOps);
        }

        public static Int_Vect_List FindAllPathsOfLengthN(ROMol mol, int targetLen,
            bool useBonds = true, bool useHs = false, int rootedAtAtom = -1)
        {
            return RDKFuncs.findAllPathsOfLengthN(mol, (uint)targetLen, useBonds, useHs, rootedAtAtom);
        }

        public static Int_Int_Vect_List_Map FindAllSubgraphsOfLengthMToN(ROMol mol, int lowerLen, int upperLen,
            bool useHs = false, int rootedAtAtom = -1)
        {
            return RDKFuncs.findAllSubgraphsOfLengthsMtoN(mol, (uint)lowerLen, (uint)upperLen, useHs, rootedAtAtom);
        }

        public static Int_Vect_List FindAllSubgraphsOfLengthN(ROMol mol, int targetLen,
            bool useHs = false, int rootedAtAtom = -1)
        {
            return RDKFuncs.findAllSubgraphsOfLengthN(mol, (uint)targetLen, useHs, rootedAtAtom);
        }

        public static Int_Vect FindAtomEnvironmentOfRadiusN(ROMol mol, int radius, int rootedAtAtom, bool useHs = false)
        {
            return RDKFuncs.findAtomEnvironmentOfRadiusN(mol, (uint)radius, (uint)rootedAtAtom, useHs);
        }

        public static void FindPotentialStereoBonds(ROMol mol, bool cleanIt = false)
        {
            RDKFuncs.findPotentialStereoBonds(mol, cleanIt);
        }

        public static Int_Vect_List FindUniqueSubgraphsOfLengthNfindUniqueSubgraphsOfLengthN(ROMol mol, int targetLen,
            bool useHs = false, bool useBO = true, int rootedAtAtom = -1)
        {
            return RDKFuncs.findUniqueSubgraphsOfLengthN(mol, (uint)targetLen, useHs, useBO, rootedAtAtom);
        }

        public static ROMol FragmentOnBRICSBonds(ROMol mol)
        {
            return RDKFuncs.fragmentOnBRICSBonds(mol);
        }

        public static SWIGTYPE_p_double Get3DDistanceMatrix(ROMol mol,
            int confId = -1, bool useAtomWts = false, bool force = false, string propNamePrefix = "")
        {
            return RDKFuncs.get3DDistanceMat(mol, confId, useAtomWts, force, propNamePrefix);
        }

        public static SWIGTYPE_p_double GetAdjacencyMatrix(ROMol mol,
            bool useBO = false, int emptyVal = 0, bool force = false, string propNamePrefix = "")
        {
            return RDKFuncs.getAdjacencyMatrix(mol, useBO, emptyVal, force, propNamePrefix);
        }

        public static SWIGTYPE_p_double GetDistanceMatrix(ROMol mol,
            bool useBO = false, bool useAtomWts = false, bool force = false, string propNamePrefix = "")
        {
            return RDKFuncs.getDistanceMat(mol, useBO, useAtomWts, force, propNamePrefix);
        }

        public static int GetFormalCharge(ROMol mol)
        {
            return RDKFuncs.getFormalCharge(mol);
        }

        public static ROMol_Vect GetMolFrags(ROMol mol,
            bool sanitizeFrags = false, Int_Vect frags = null, Int_Vect_Vect fragsMolAtomMapping = null)
        {
            return RDKFuncs.getMolFrags(mol, sanitizeFrags, frags, fragsMolAtomMapping);
        }

        public static int GetSSSR(ROMol mol)
        {
            return RDKFuncs.findSSSR(mol);
        }

        public static Int_List GetShortestPath(ROMol mol, int aid1, int aid2)
        {
            return RDKFuncs.getShortestPath(mol, aid1, aid2);
        }

        public static int GetSymmSSSR(ROMol mol)
        {
            return RDKFuncs.symmetrizeSSSR(mol);
        }

        [Flags]
        public enum LayerFlags
        {
            PureTopology = 0x1,
            BondOrder = 0x2,
            AtomTypes = 0x4,
            PresenceOfRings = 0x8,
            RingSize = 0x10,
            Aromaticity = 0x20,
        }

        public static void Kekulize(RWMol mol, bool clearAromaticFlags = false)
        {
            RDKFuncs.Kekulize(mol, clearAromaticFlags);
        }

        public static ExplicitBitVect LayeredFingerprint(ROMol mol,
            LayerFlags layerFlags = (LayerFlags)(-1), int minPath = 1, int maxPath = 7, int fpSize = 2048,
            UInt_Vect atomCounts = null, ExplicitBitVect setOnlyBits = null, bool branchedPaths = true, UInt_Vect fromAtoms = null)
        {
            return RDKFuncs.LayeredFingerprintMol(mol, (uint)layerFlags, (uint)minPath, (uint)maxPath, (uint)fpSize, atomCounts, setOnlyBits, branchedPaths, fromAtoms);
        }

        public static ROMol MergeQueryHs(ROMol mol, bool mergeUnmappedOnly = false)
        {
            return RDKFuncs.mergeQueryHs(mol, mergeUnmappedOnly);
        }

        public static void MolAddRecursiveQueries(ROMol mol, StringMolMap queries, string propName)
        {
            RDKFuncs.addRecursiveQueries(mol, queries, propName);
        }

        public static string MolToSVG(ROMol mol, int width = 300, int height = 300,
            Int_Vect highlightAtoms = null, bool kekulize = true, int lineWidthMult = 1, int fontSize = 12,
            bool includeAtomCircles = true, int confId = -1)
        {
            // See Code\GraphMol\Wrap\MolOps.cpp
            var drawer = new MolDraw2DSVG(width, height);
            drawer.setFontSize(fontSize / 24.0);
            drawer.setLineWidth(drawer.lineWidth() * lineWidthMult);
            drawer.drawOptions().circleAtoms = includeAtomCircles;
            drawer.drawMolecule(mol, highlightAtoms, null, null, confId);
            drawer.finishDrawing();
            return drawer.getDrawingText();
        }

        public static ROMol MurckoDecompose(ROMol mol)
        {
            return RDKFuncs.MurckoDecompose(mol);
        }

        public static StringMolMap ParseMolQueryDefFile(string filename,
            bool standardize = true, string delimiter = "\t", string comment = "//",
            int nameColumn = 0, int smartsColumn = 1)
        {
            var queryDefs = new StringMolMap();
            RDKFuncs.parseQueryDefFile(filename, queryDefs, standardize, delimiter, comment, (uint)nameColumn, (uint)smartsColumn);
            return queryDefs;
        }

        public static ROMol PathToSubmol(ROMol mol, Int_Vect path, bool useQuery = false, Int_Int_Map atomIdxMap = null)
        {
            return RDKFuncs.pathToSubmol(mol, path, useQuery, atomIdxMap);
        }

        public static ExplicitBitVect PatternFingerprint(ROMol mol,
            int fpSize = 2048, UInt_Vect atomCounts = null, ExplicitBitVect setOnlyBits = null)
        {
            return RDKFuncs.PatternFingerprintMol(mol, (uint)fpSize, atomCounts, setOnlyBits);
        }

        public static ExplicitBitVect RDKFingerprint(ROMol mol,
            int minPath = 1, int maxPath = 7, int fpSize = 2048, int nBitsPerHash = 2,
            bool useHs = true, double tgtDensity = 0, int minSize = 128, bool branchedPaths = true,
            bool useBondOrder = true, UInt_Vect atomInvariants = null, UInt_Vect fromAtoms = null,
            SWIGTYPE_p_std__vectorT_std__vectorT_uint32_t_t_t atomBits = null,
            SWIGTYPE_p_std__mapT_unsigned_int_std__vectorT_std__vectorT_int_t_t_std__lessT_unsigned_int_t_t bitInfo = null)
        {
            return RDKFuncs.RDKFingerprintMol(mol, (uint)minPath, (uint)maxPath, (uint)fpSize, (uint)nBitsPerHash, useHs, tgtDensity, (uint)minSize, branchedPaths, useBondOrder, atomInvariants, fromAtoms, atomBits, bitInfo);
        }

        public static ROMol RemoveHs(ROMol mol,
            bool implicitOnly = false, bool updateExplicitCount = false, bool sanitize = true)
        {
            return RDKFuncs.removeHs(mol, implicitOnly, updateExplicitCount, sanitize);
        }

        public static void RemoveStereochemistry(ROMol mol)
        {
            RDKFuncs.removeStereochemistry(mol);
        }

        public static ROMol RenumberAtoms(ROMol mol, UInt_Vect newOrder)
        {
            return RDKFuncs.renumberAtoms(mol, newOrder);
        }

        public static ROMol ReplaceCore(ROMol mol, ROMol coreQuery,
            bool replaceDummies = true, bool labelByIndex = false, bool requireDummyMatch = false, bool useChirality = false)
        {
            return RDKFuncs.replaceCore(mol, coreQuery, replaceDummies, labelByIndex, requireDummyMatch, useChirality);
        }

        public static ROMol ReplaceSidechains(ROMol mol, ROMol coreQuery, bool useChirality = false)
        {
            return RDKFuncs.replaceSidechains(mol, coreQuery, useChirality);
        }

        public static ROMol_Vect ReplaceSubstructs(ROMol mol, ROMol query, ROMol replacement, bool replaceAll = false, int replacementConnectionPoint = 0, bool useChirality = false)
        {
            return RDKFuncs.replaceSubstructs(mol, query, replacement, replaceAll, (uint)replacementConnectionPoint, useChirality);
        }

        public static SanitizeFlags SanitizeMol(RWMol mol, SanitizeFlags sanitizeOps = SanitizeFlags.SANITIZE_ALL)
        {
            return (SanitizeFlags)RDKFuncs.sanitizeMol(mol, (int)sanitizeOps);
        }

        public static void SetAromaticity(RWMol mol, AromaticityModel model = AromaticityModel.AROMATICITY_DEFAULT)
        {
             RDKFuncs.setAromaticity(mol, model);
        }

        public static void SetBondStereoFromDirections(ROMol mol)
        {
            RDKFuncs.setBondStereoFromDirections(mol);
        }

        public static void SetConjugation(ROMol mol)
        {
            RDKFuncs.setConjugation(mol);
        }

        public static void SetDoubleBondNeighborDirections(ROMol mol, Conformer conf = null)
        {
            RDKFuncs.setDoubleBondNeighborDirections(mol, conf);
        }

        public static void SetHybridization(ROMol mol)
        {
            RDKFuncs.setHybridization(mol);
        }

        public static void WedgeMolBonds(ROMol mol, Conformer conf)
        {
            mol.WedgeMolBonds(conf);
        }

        //
        // rdmolfiles 
        //

        public static ForwardSDMolSupplier ForwardSDMolSupplier(string filename, 
            bool sanitize = true, bool removeHs = true, bool strictParsing = true)
        {
            return new ForwardSDMolSupplier(new gzstream(filename), sanitize, removeHs, strictParsing);
        }

        public static SDMolSupplier SDMolSupplier(string fileName, 
            bool sanitize = true, bool removeHs = true, bool strictParsing = true)
        {
            return new SDMolSupplier(fileName, sanitize, removeHs, strictParsing);
        }

        public static SmilesMolSupplier SmilesMolSupplier(string fileName)
        {
            return new SmilesMolSupplier(fileName);
        }

        public static TDTMolSupplier TDTMolSupplier(string fileName)
        {
            return new TDTMolSupplier(fileName);
        }

        public static TDTWriter TDTWriter(string fileName)
        {
            return new TDTWriter(fileName);
        }

        public static PDBWriter PDBWriter(string fileName, PDBFlavors flavor)
        {
            return new PDBWriter(fileName, (uint)flavor);
        }

        public static string MolFragmentToCXSmiles(ROMol mol, Int_Vect atomsToUse, Int_Vect bondsToUse = null,
            Str_Vect atomSymbols = null, Str_Vect bondSymbols = null,
            bool isomericSmiles = true, bool kekuleSmiles = false, int rootedAtAtom = -1, bool canonical = true,
            bool allBondsExplicit = false, bool allHsExplicit = false)
        {
            return RDKFuncs.MolFragmentToCXSmiles(mol, atomsToUse, bondsToUse, atomSymbols, bondSymbols, isomericSmiles, kekuleSmiles, rootedAtAtom, canonical);
        }

        public static string MolFragmentToSmarts(ROMol mol, Int_Vect atomsToUse, Int_Vect bondsToUse = null, bool isomericSmiles = true)
        {
            return RDKFuncs.MolFragmentToSmarts(mol, atomsToUse, bondsToUse, isomericSmiles);
        }

        public static string MolFragmentToSmiles(ROMol mol, Int_Vect atomsToUse, Int_Vect bondsToUse = null,
            Str_Vect atomSymbols = null, Str_Vect bondSymbols = null,
            bool isomericSmiles = true, bool kekuleSmiles = false, int rootedAtAtom = -1, bool canonical = true,
            bool allBondsExplicit = false, bool allHsExplicit = false)
        {
            return RDKFuncs.MolFragmentToSmiles(mol, atomsToUse, bondsToUse, atomSymbols, bondSymbols, isomericSmiles, kekuleSmiles, rootedAtAtom, canonical);
        }

        public static RWMol MolFromHELM(string text, bool sanitize = true)
        {
            return RWMol.MolFromHELM(text, sanitize);
        }

        public static RWMol MolFromMol2Block(string molBlock, bool sanitize = true, bool removeHs = true, bool cleanupSubstructures = true)
        {
            return RWMol.MolFromMol2Block(molBlock, sanitize, removeHs, Mol2Type.CORINA, cleanupSubstructures);
        }

        public static RWMol MolFromMol2File(string molFileName, bool sanitize = true, bool removeHs = true, bool cleanupSubstructures = true)
        {
            return RWMol.MolFromMol2File(molFileName, sanitize, removeHs, Mol2Type.CORINA, cleanupSubstructures);
        }

        // TODO: Add strictParsing
        public static RWMol MolFromMolBlock(string molBlock, bool sanitize = true, bool removeHs = true)
        {
            return RWMol.MolFromMolBlock(molBlock, sanitize, removeHs);
        }

        // TODO: Add strictParsing
        public static RWMol MolFromMolFile(string molFileName, bool sanitize = true, bool removeHs = true)
        {
            return RWMol.MolFromMolFile(molFileName, sanitize, removeHs);
        }

        public static RWMol MolFromPDBFile(string molFileName, bool sanitize = true,
            bool removeHs = true, PDBFlavors flavor = 0, bool proximityBonding = true)
        {
            return RWMol.MolFromPDBBlock(molFileName, sanitize, removeHs, (uint)flavor, proximityBonding);
        }

        public static RWMol MolFromSequence(string svg, bool sanitize = true, bool removeHs = true)
        {
            return RDKFuncs.RDKitSVGToMol(svg, sanitize, removeHs);
        }

        public static RWMol MolFromSequence(string text, bool sanitize = true, SequenceFlavor flavor = 0)
        {
            return RWMol.MolFromSequence(text, sanitize, (int)flavor);
        }

        public static RWMol MolFromSmiles(string smiles, bool sanitize = true)
        {
            return RWMol.MolFromSmiles(smiles, 0, sanitize);
        }

        public static RWMol MolFromSmarts(string smiles, bool mergeHs = false)
        {
            return RWMol.MolFromSmarts(smiles, 0, mergeHs);
        }

        public static string MolToSmarts(ROMol mol, bool isomericSmiles = true)
        {
            return RDKFuncs.MolToSmarts(mol, isomericSmiles);
        }

        public static string MolToSmiles(ROMol mol, bool isomericSmiles = true,
            bool kekuleSmiles = false, int rootedAtAtom = -1, bool canonical = true,
            bool allBondsExplicit = false, bool allHsExplicit = false, bool doRandom = false)
        {
            return RDKFuncs.MolToSmiles(mol, isomericSmiles, kekuleSmiles, rootedAtAtom, canonical, allBondsExplicit, allHsExplicit, doRandom);
        }

        public static string MolToTPLBlock(ROMol mol, string partialChargeProp = "_GasteigerCharge", bool writeFirstConfTwice = false)
        {
            return RDKFuncs.MolToTPLText(mol, partialChargeProp, writeFirstConfTwice);
        }

        public static void MolToTPLFile(ROMol mol, string filename, string partialChargeProp = "_GasteigerCharge", bool writeFirstConfTwice = false)
        {
            RDKFuncs.MolToTPLFile(mol, filename, partialChargeProp, writeFirstConfTwice);
        }

        public static string MolToMolBlock(ROMol mol, bool includeStereo = true,
            int confId = -1, bool kekulize = true, bool forceV3000 = false)
        {
            return RDKFuncs.MolToMolBlock(mol, includeStereo, confId, kekulize, forceV3000);
        }

        public static void MolToMolFile(ROMol mol, string filename, bool includeStereo = true,
            int confId = -1, bool kekulize = true, bool forceV3000 = false)
        {
            RDKFuncs.MolToMolFile(mol, filename, includeStereo, confId, kekulize, forceV3000);
        }

        public static string MolToPDBBlock(ROMol mol, int confId = -1, PDBFlavors flavor = 0)
        {
            return RDKFuncs.MolToPDBBlock(mol, confId, (uint)flavor);
        }

        public static void MolToPDBFile(ROMol mol, string filename, int confId = -1, PDBFlavors flavor = 0)
        {
            RDKFuncs.MolToPDBFile(mol, filename, confId, (uint)flavor);
        }

        public static string MolToXYZBlock(ROMol mol, int confId = -1)
        {
            return RDKFuncs.MolToXYZBlock(mol, confId);
        }

        public static void MolToXYZFile(ROMol mol, string filename, int confId = -1)
        {
            RDKFuncs.MolToXYZFile(mol, filename, confId);
        }

        public static string MolToCXSmiles(ROMol mol, bool isomericSmiles = true,
            bool kekuleSmiles = false, int rootedAtAtom = -1, bool canonical = true,
            bool allBondsExplicit = false, bool allHsExplicit = false, bool doRandom = false)
        {
            return RDKFuncs.MolToCXSmiles(mol, isomericSmiles, kekuleSmiles, rootedAtAtom, canonical, allHsExplicit, doRandom);
        }

        //
        // InChI
        // 

        public static string InchiToInchiKey(string inchi)
        {
            return RDKFuncs.InchiToInchiKey(inchi);
        }

        public static RWMol InchiToMol(string inchi, bool sanitize = true, bool removeHs = true, ExtraInchiReturnValues ex = null)
        {
            return RDKFuncs.InchiToMol(inchi, ex ?? new ExtraInchiReturnValues(), sanitize, removeHs);
        }

        public static string MolBlockToInchi(string molblock, string options = "", ExtraInchiReturnValues ex = null)
        {
            return RDKFuncs.MolBlockToInchi(molblock, ex ?? new ExtraInchiReturnValues(), options);
        }

        public static string MolToInchi(ROMol mol, string options = "", ExtraInchiReturnValues ex = null)
        {
            return RDKFuncs.MolToInchi(mol, ex ?? new ExtraInchiReturnValues(), options);
        }

        public static string MolToInchiKey(ROMol mol, string options = "")
        {
            return RDKFuncs.MolToInchiKey(mol, options);
        }

        //
        // rdChem
        //

        public static int GetNumHeavyAtoms(ROMol mol)
        {
            return (int)mol.getNumHeavyAtoms();
            
        }

        public static int GetNumAtoms(ROMol mol, bool onlyExplicit = true)
        {
            return (int)mol.getNumAtoms(onlyExplicit);
        }

        public static int GetNumBonds(ROMol mol, bool onlyHeavy = true)
        {
            return (int)mol.getNumBonds(onlyHeavy);
        }
    }
}
