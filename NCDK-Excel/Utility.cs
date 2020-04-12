using GraphMolWrap;
using NCDK;
using NCDK.Fingerprints;
using NCDK.Graphs.InChI;
using NCDK.IO;
using NCDK.QSAR;
using RDKit;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Text;

namespace NCDKExcel
{
    public static partial class Utility
    {
        public const string SeparatorofNameKind = "(S-E-P-A-R-A-T-O-R)";

        public static string ToExcelString(object value)
        {
            switch (value)
            {
                case double f:
                    if (double.IsNaN(f))
                        return "#N/A";
                    if (double.IsInfinity(f))
                        return "#NUM!";
                    goto default;
                default:
                    return value.ToString();
            }
        }

        public static string ToExcelString(BitVect fp)
        {
            var sb = new StringBuilder();
            var n = fp.getNumBits();
            for (int i = 0; i < n; i++)
            {
                sb.Append(fp.GetBit(i) ? "1" : "0");
            }
            return sb.ToString();
        }

        public static string ToExcelString(SparseIntVect32 vector)
        {
            return RDKitSparseVector.ToJson(vector);
        }

        public static string ToExcelString(SparseIntVect64 vector)
        {
            return RDKitSparseVector.ToJson(vector);
        }

        public static string ToExcelString(IDescriptorResult result)
        {
            return string.Join(", ", result.Values.Select(n => ToExcelString(n)));
        }

        public static string ToExcelString(IBitFingerprint fp)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < fp.Length; i++)
            {
                sb.Append(fp[i] ? "1" : "0");
            }
            return sb.ToString();
        }

        static IAtomContainer ParseSmiles(string smiles)
        {
            try
            {
                var mol = CDK.SmilesParser.ParseSmiles(smiles);
                if (mol.Atoms.Count == 0)
                    return null;
                return mol;
            }
            catch (Exception)
            {
            }
            return null;
        }

        static IAtomContainer ParseInChI(string inchi)
        {
            try
            {
                var structure = InChIToStructure.FromInChI(inchi);
                if (structure.ReturnStatus == InChIReturnCode.Ok)
                {
                    return structure.AtomContainer;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        /// <summary>
        /// Add implicit hydrogens.
        /// </summary>
        /// <param name="container">Molecular to add hydrogens</param>
        public static void AddImplicitHydrogens(IAtomContainer container)
        {
            var matcher = CDK.AtomTypeMatcher;
            int atomCount = container.Atoms.Count;
            string[] originalAtomTypeNames = new string[atomCount];
            for (int i = 0; i < atomCount; i++)
            {
                var atom = container.Atoms[i];
                var type = matcher.FindMatchingAtomType(container, atom);
                originalAtomTypeNames[i] = atom.AtomTypeName;
                atom.AtomTypeName = type.AtomTypeName;
            }
            var hAdder = CDK.HydrogenAdder;
            hAdder.AddImplicitHydrogens(container);
            // reset to the original atom types
            for (int i = 0; i < atomCount; i++)
            {
                var atom = container.Atoms[i];
                atom.AtomTypeName = originalAtomTypeNames[i];
            }
        }

        /// <summary>
        /// Dummy molecule to indicate <see langword="null"/>.
        /// </summary>
        static readonly IAtomContainer nullMol = CDK.Builder.NewAtomContainer();

        static ConcurrentDictionary<string, IAtomContainer> MolecularCache = new ConcurrentDictionary<string, IAtomContainer>();

        /// <summary>
        /// Parse <paramref name="text"/> as SMILES, InChI or MOL text and cache it.
        /// </summary>
        /// <param name="ident">Text to parse</param>
        /// <returns>Molecular or <see langword="null"/> if it cannot be parsed.</returns>
        public static IAtomContainer Parse(string ident)
        {
            if (ident == null)
                throw new ArgumentNullException(nameof(ident));

            IAtomContainer mol;
            if (!MolecularCache.TryGetValue(ident, out mol))
            {
                mol = RawParse(ident, out string notationType);
                if (mol == null)
                    mol = nullMol;
                else
                {
                    if (notationType != null)
                        mol.SetProperty("source", notationType);
                }

                MolecularCache[ident] = mol;
            }
            if (object.ReferenceEquals(mol, nullMol))
                return null;

            return mol;
        }

        static IAtomContainer RawParse(string text, out string notationType)
        {
            IAtomContainer mol = null;

            if (text == null)
            {
                notationType = "None";
                return null;
            }
            if (text.IndexOf('\r') >= 0)
                goto Go_Mol;
            if (text.IndexOf('\n') >= 0)
                goto Go_Mol;

            mol = ParseSmiles(text);
            if (mol != null)
            {
                notationType = "SMILES";
                return mol;
            }

            mol = ParseInChI(text);
            if (mol != null)
            {
                notationType = "InChI";
                return mol;
            }

        Go_Mol:
            using (var r = new MDLV2000Reader(new StringReader(text)))
            {
                var m = CDK.Builder.NewAtomContainer();
                try
                {
                    r.Read(m);
                    mol = m;
                }
                catch (Exception)
                { }
            }
            if (mol != null)
            {
                notationType = "MolBlock";
                return mol;
            }

            using (var r = new MDLV3000Reader(new StringReader(text)))
            {
                var m = CDK.Builder.NewAtomContainer();
                try
                {
                    r.Read(m);
                    mol = m;
                }
                catch (Exception)
                { }
            }
            if (mol != null)
            {
                notationType = "MolBlock";
                return mol;
            }

            notationType = "None";
            return null;
        }

        public static string ToMolBlock(IAtomContainer mol)
        {
            string ret = null;
            using (var sr = new StringWriter())
            {
                try
                {
                    using (var w = new MDLV2000Writer(sr))
                    {
                        w.WriteMolecule(mol);
                    }
                    ret = sr.ToString();
                }
                catch (Exception)
                {
                }
            }
            return ret;
        }
    }
}
