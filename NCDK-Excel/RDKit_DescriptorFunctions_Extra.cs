using ExcelDna.Integration;
using GraphMolWrap;
using RDKit;
using System;
using System.Collections.Concurrent;
using System.Text;
using static NCDKExcel.RDKitMol;

namespace NCDKExcel
{
    static partial class Caching<TRet>
    {
        public static TRet Calculate(string molecule_ident, string name, Func<ROMol, TRet> calculator)
        {
            if (molecule_ident == null)
                throw new ArgumentNullException(nameof(molecule_ident));

            var key = new Tuple<string, string>(name, molecule_ident);
            var nReturnValue = ValueCache.GetOrAdd(key, tuple =>
            {
                var mol = Parse(molecule_ident);
                return calculator(mol);
            });

            return nReturnValue;
        }
    }

    public static partial class DescriptorFunctions
    {
        [ExcelFunction(Description = "Returns the Morgan fingerprint.")]
        public static string RDKit_MorganFingerprint(string molecule_ident, int radius, int nBits)
        {
            if (nBits == 0)
                nBits = 2048;

            var ret = Caching<string>.Calculate(molecule_ident, $"RDKit_MorganFingerprint:{radius}:{nBits}",
                mol =>
                {
                    string nReturnValue = null;

                    if (nReturnValue == null)
                    {
                        var result = GraphMolWrap.RDKFuncs.getMorganFingerprintAsBitVect(mol, (uint)radius, (uint)nBits);
                        nReturnValue = ToExcelString(result);
                    }

                    return (string)nReturnValue;
                });
            return (string)ret;
        }

        /// <summary>
        /// Calculate descriptor returns <see cref="System.String"/> in Excel.
        /// </summary>
        /// <param name="molecule_ident">Input text to caluculate, typically molecular identifier.</param>
        /// <param name="name">The descriptor name.</param>
        /// <param name="calculator">The caluculator.</param>
        /// <returns>Calculated value as <see cref="System.String"/>.</returns>
        static T RDKit_CalcDesc<T>(string molecule_ident, string name, Func<ROMol, T> calculator)
        {
            if (molecule_ident == null)
                throw new ArgumentNullException(nameof(molecule_ident));

            var ret = Caching<T>.Calculate(molecule_ident, name, calculator);
            return ret;
        }

        [ExcelFunction(Description = "Returns Smarts.")]
        public static string RDKit_Smarts(string molecule_ident, object isomericSmiles = null)
        {
            var _isomericSmiles = ExcelDnaUtility.ToBoolean(isomericSmiles, true);

            if (_isomericSmiles)
            {
                return RDKit_CalcDesc(molecule_ident, "RDKit_Smarts", mol => RDKit.Chem.MolToSmarts(mol));
            }
            return RDKit.Chem.MolToSmarts(Parse(molecule_ident), _isomericSmiles);
        }

        [ExcelFunction(Description = "Returns Smiles.")]
        public static string RDKit_Smiles(string molecule_ident,
            object isomericSmiles = null, bool kekuleSmiles = false,
            object rootedAtAtom = null, object canonical = null,
            bool allBondsExplicit = false, bool allHsExplicit = false,
            bool doRandom = false)
        {
            var _isomericSmiles = ExcelDnaUtility.ToBoolean(isomericSmiles, true);
            var _rootedAtAtom = ExcelDnaUtility.ToInt32(rootedAtAtom, -1);
            var _canonical = ExcelDnaUtility.ToBoolean(canonical, true);

            if (_isomericSmiles
             && !kekuleSmiles
             && _rootedAtAtom == -1
             && _canonical
             && !allBondsExplicit
             && !allHsExplicit
             && !doRandom)
            {
                return RDKit_CalcDesc(molecule_ident, "RDKit_Smiles", mol => RDKit.Chem.MolToSmiles(mol));
            }
            {
                ROMol mol;
                if (kekuleSmiles)
                {
                    var _mol = RWMol.MolFromSmiles(molecule_ident);
                    RDKFuncs.Kekulize(_mol);
                    mol = _mol;
                }
                else
                {
                    mol = Parse(molecule_ident);
                }
                return RDKit.Chem.MolToSmiles(mol, _isomericSmiles, kekuleSmiles, _rootedAtAtom, _canonical, allBondsExplicit, allHsExplicit, doRandom);
            }
        }

        [ExcelFunction(Description = "Returns the InChI.")]
        public static string RDKit_InChI(string molecule_ident, string options)
        {
            return RDKit_CalcDesc(molecule_ident, "RDKit_InChI", mol =>
            {
                using (var rv = new ExtraInchiReturnValues())
                {
                    return RDKit.Chem.MolToInchi(mol, options, rv);
                }
            });
        }

        [ExcelFunction(Description = "Returns the chi Nn.")]
        public static double RDKit_ChiNn(string molecule_ident, int n)
        {
            return RDKit_CalcDesc(molecule_ident, "RDKit_ChiNn" + n.ToString(), mol => RDKFuncs.calcChiNn(mol, (uint)n));
        }

        [ExcelFunction(Description = "Returns the chi Nv.")]
        public static double RDKit_ChiNv(string molecule_ident, int n)
        {
            return RDKit_CalcDesc(molecule_ident, "RDKit_ChiNv" + n.ToString(), mol => RDKFuncs.calcChiNv(mol, (uint)n));
        }

        [ExcelFunction(Description = "Returns the number of HeavyAtoms.")]
        public static double RDKit_NumHeavyAtoms(string molecule_ident)
        {
            var mol = Parse(molecule_ident);
            return mol.GetNumHeavyAtoms();
        }

        [ExcelFunction(Description = "Returns the number of Atoms.")]
        public static double RDKit_NumAtoms(string molecule_ident)
        {
            var mol = Parse(molecule_ident);
            return mol.GetNumAtoms();
        }

        [ExcelFunction(Description = "Returns the number of Bonds.")]
        public static double RDKit_NumBonds(string molecule_ident)
        {
            var mol = Parse(molecule_ident);
            return mol.GetNumBonds();
        }

        [ExcelFunction(Description = "Remove Hs.")]
        public static string RDKit_RemoveHs(string molecule_ident)
        {
            var mol = Parse(molecule_ident);
            mol = Chem.RemoveHs(mol);
            return ToIdentString(mol);
        }

        [ExcelFunction(Description = "Add Hs.")]
        public static string RDKit_AddHs(string molecule_ident)
        {
            var mol = Parse(molecule_ident);
            mol = Chem.AddHs(mol);
            return ToIdentString(mol);
        }


        [ExcelFunction(Description = "Embed molecule.")]
        public static string RDKit_EmbedMolecule(string molecule_ident)
        {
            var mol = Parse(molecule_ident);
            var numMols = Chem.EmbedMolecule(mol);
            if (numMols > 0)
                return null;
            return ToIdentString(mol, "MolBlock");
        }
    }

    public static class RDKitMol
    {
        static readonly ConcurrentDictionary<string, ROMol> MolecularCache = new ConcurrentDictionary<string, ROMol>();
        static readonly ROMol nullMol = new RWMol();

        public static string ToIdentString(ROMol mol, string source=null)
        {
            if (source == null)
                source = mol.getProp("source");
            switch (source)
            {
                case "SMILES":
                    return Chem.MolToSmiles(mol);
                case "InChI":
                    return Chem.MolToInchi(mol);
                case "MolBlock":
                    return Chem.MolToMolBlock(mol);
                default:
                    return Chem.MolToSmiles(mol);
            }
        }

        /// <summary>
        /// Tries to parses text as SMILES, InChI, or MolBlock and returns RDKit ROMol.
        /// </summary>
        /// <param name="molecule_ident">Text expression of molecule like SMILES, InChI, or MolBlock.</param>
        /// <returns>RDKit ROMol.</returns>
        public static ROMol Parse(string molecule_ident)
        {
            if (molecule_ident == null)
                throw new ArgumentNullException(nameof(molecule_ident));

            var mol = MolecularCache.GetOrAdd(molecule_ident, a_ident =>
            {
                string notationType = null;
                ROMol a_mol;

                a_mol = RWMol.MolFromSmiles(molecule_ident);
                if (a_mol != null)
                {
                    notationType = "SMILES";
                    goto L_Found;
                }

                using (var rv = new ExtraInchiReturnValues())
                {
                    a_mol = RDKFuncs.InchiToMol(molecule_ident, rv);
                    if (a_mol != null)
                    {
                        notationType = "InChI";
                        goto L_Found;
                    }
                }

                a_mol = RWMol.MolFromMolBlock(molecule_ident);
                if (a_mol != null)
                {
                    RDKFuncs.assignStereochemistryFrom3D(a_mol);
                    notationType = "MolBlock";
                    goto L_Found;
                }

            L_Found:
                if (a_mol == null)
                    a_mol = nullMol;
                else
                {
                    if (notationType != null)
                        a_mol.setProp("source", notationType);
                }

                return a_mol;
            });

            if (object.ReferenceEquals(mol, nullMol))
                return null;

            return mol;
        }

        public static string ToExcelString(BitVect fp)
        {
            var sb = new StringBuilder();
            var n = fp.getNumBits();
            for (uint i = 0; i < n; i++)
            {
                sb.Append(fp.getBit(i) ? "1" : "0");
            }
            return sb.ToString();
        }
    }
}
