using ExcelDna.Integration;
using GraphMolWrap;
using System;
using System.Collections.Generic;
using System.Text;
using static NCDKExcel.Utility;

namespace NCDKExcel
{
    static partial class Caching<T>
    {
        static readonly IDictionary<string, ROMol> RDKitMolecularCache = new Dictionary<string, ROMol>();
        static readonly ROMol nullMolRDKit = new RWMol();

        public static ROMol ParseToRDKitMol(string ident)
        {
            if (ident == null)
                throw new ArgumentNullException(nameof(ident));

            LineNotationType notationType = 0;
            if (!RDKitMolecularCache.TryGetValue(ident, out ROMol mol))
            {
                mol = RWMol.MolFromSmiles(ident);
                if (mol != null)
                {
                    notationType = LineNotationType.Smiles;
                    goto L_MolFound;
                }

                using (var rv = new ExtraInchiReturnValues())
                {
                    mol = RDKFuncs.InchiToMol(ident, rv);
                    if (mol != null)
                    {
                        notationType = LineNotationType.InChI;
                        goto L_MolFound;
                    }
                }

                mol = RWMol.MolFromMolBlock(ident);
                if (mol != null)
                {
                    notationType = LineNotationType.MolText;
                    goto L_MolFound;
                }

            L_MolFound:
                if (mol == null)
                    mol = nullMolRDKit;
                RDKitMolecularCache[ident] = mol;
            }
            if (object.ReferenceEquals(mol, nullMolRDKit))
                return null;
            return mol;
        }

        public static T Calculate(string text, string name, Func<ROMol, T> calculator)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            var key = name + SeparatorofNameKind + text;
            if (!ValueCache.TryGetValue(key, out T nReturnValue))
            {
                var mol = ParseToRDKitMol(text);
                nReturnValue = calculator(mol);
                ValueCache[key] = nReturnValue;
            }
            return nReturnValue;
        }
    }

    public static partial class DescriptorFunctions
    {
        [ExcelFunction()]
        public static string RDKit_MorganFingerprint(string text, int radius, int nBits)
        {
            if (nBits == 0)
                nBits = 2048;

            var ret = Caching<string>.Calculate(text, $"RDKit_MorganFingerprint{SeparatorofNameKind}{radius}{SeparatorofNameKind}{nBits}",
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
        /// <param name="text">Input text to caluculate, typically molecular identifier.</param>
        /// <param name="name">The descriptor name.</param>
        /// <param name="calculator">The caluculator.</param>
        /// <returns>Calculated value as <see cref="System.String"/>.</returns>
        static string RDKit_CalcStringDesc(string text, string name, Func<ROMol, string> calculator)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            var key = name + SeparatorofNameKind + text;
            var ret = Caching<string>.Calculate(text, name, calculator);
            return ret;
        }

        [ExcelFunction()]
        public static string RDKit_SMILES(string text)
        {
            return RDKit_CalcStringDesc(text, "RDKit_SMILES", mol => mol.MolToSmiles());
        }

        [ExcelFunction()]
        public static string RDKit_InChI(string text)
        {
            return RDKit_CalcStringDesc(text, "RDKit_InChI", mol => 
                {
                    using (var rv = new ExtraInchiReturnValues())
                    {
                        return RDKFuncs.MolToInchi(mol, rv);
                    }
                });
        }

        [ExcelFunction()]
        public static string RDKit_InChIKey(string text)
        {
            using (var rv = new ExtraInchiReturnValues())
            {
                return RDKit_CalcStringDesc(text, "RDKit_InChIKey", mol => RDKFuncs.MolToInchiKey(mol));
            }
        }

        [ExcelFunction()]
        public static string RDKit_MolBlock(string text)
        {
            return RDKit_CalcStringDesc(text, "RDKit_MolText", mol => mol.MolToMolBlock());
        }
    }

    public static partial class Utility
    {
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
