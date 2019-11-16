using GraphMolWrap;
using System;

namespace RDKit
{
    public static partial class Chem
    {
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

        public static Match_Vect_Vect GetSubstructMatches(this ROMol mol, ROMol pattern)
        {
            return mol.getSubstructMatches(pattern);
        }

        public static bool HasSubstructMatch(this ROMol mol, ROMol query)
        {
            return mol.hasSubstructMatch(query);
        }

        public static ROMol DeleteSubstructs(ROMol mol, ROMol query, bool replaceAll = false)
        {
            return mol.deleteSubstructs(query, replaceAll);
        }

        public static string MolToSmiles(ROMol mol)
        {
            return RDKFuncs.MolToSmiles(mol);
        }

        public static string MolToSmarts(ROMol mol)
        {
            return RDKFuncs.MolToSmarts(mol);
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

        public static ROMol RemoveHs(this ROMol mol, bool implicitOnly = false, 
            bool updateExplicitCount = false, bool sanitize = true)
        {
            return mol.removeHs(implicitOnly, updateExplicitCount, sanitize);
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

        public static void MolToMolFile(ROMol mol, string filename, bool includeStereo = true,
            int confId = -1, bool kekulize = true, bool forceV3000 = false)
        {
            RDKFuncs.MolToMolFile(mol, filename, includeStereo, confId, kekulize, forceV3000);
        }

        public static string MolToMolBlock(ROMol mol, bool includeStereo = true, 
            int confId = -1, bool kekulize = true, bool forceV3000 = false)
        {
            return RDKFuncs.MolToMolBlock(mol, includeStereo, confId, kekulize, forceV3000);
        }

        public static string MolToPDBBlock(ROMol mol, int confId = -1, PDBFlavors flavor = 0)
        {
            return RDKFuncs.MolToPDBBlock(mol, confId, (uint)flavor);
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
