using GraphMolWrap;
using System;
using System.Linq;

namespace RDKit
{
    public static partial class ChemTools
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
    }

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

       

        public static int GetSSSR(ROMol mol)
        {
            return RDKFuncs.findSSSR(mol);
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
            bool cleanIt=false, bool force = false, bool flagPossibleStereoCenters = false)
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

        public static Int_Vect_List FindAllPathsOfLengthN(ROMol mol, uint targetLen, 
            bool useBonds = true, bool useHs = false, int rootedAtAtom = -1)
        {
            return RDKFuncs.findAllPathsOfLengthN(mol, targetLen, useBonds, useHs, rootedAtAtom);
        }

        public static Int_Int_Vect_List_Map FindAllSubgraphsOfLengthMToN(ROMol mol, uint lowerLen, uint upperLen,
            bool useHs = false, int rootedAtAtom = -1)
        {
            return RDKFuncs.findAllSubgraphsOfLengthsMtoN(mol, lowerLen, upperLen, useHs, rootedAtAtom);
        }

        public static Int_Vect_List FindAllSubgraphsOfLengthN(ROMol mol, uint targetLen, 
            bool useHs = false, int rootedAtAtom = -1)
        {
            return RDKFuncs.findAllSubgraphsOfLengthN(mol, targetLen, useHs, rootedAtAtom);
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
    }
}
