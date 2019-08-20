using ExcelDna.Integration;
using GraphMolWrap;
using System;
using System.Collections.Generic;
using System.Text;
using static NCDKExcel.RDKitUtility;

namespace NCDKExcel
{
    static partial class Caching<TRet>
    {
        public static TRet Calculate(string text, string name, Func<ROMol, TRet> calculator)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            var key = name + SeparatorofNameKind + text;
            if (!ValueCache.TryGetValue(key, out TRet nReturnValue))
            {
                var mol = Parse(text);
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
        static T RDKit_CalcDesc<T>(string text, string name, Func<ROMol, T> calculator)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            var key = name + SeparatorofNameKind + text;
            var ret = Caching<T>.Calculate(text, name, calculator);
            return ret;
        }


        [ExcelFunction()]
        public static string RDKit_SMILES(string text)
        {
            return RDKit_CalcDesc(text, "RDKit_SMILES", mol => mol.MolToSmiles());
        }

        [ExcelFunction()]
        public static string RDKit_InChI(string text)
        {
            return RDKit_CalcDesc(text, "RDKit_InChI", mol => 
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
                return RDKit_CalcDesc(text, "RDKit_InChIKey", mol => RDKFuncs.MolToInchiKey(mol));
            }
        }

        [ExcelFunction()]
        public static string RDKit_MolBlock(string text)
        {
            return RDKit_CalcDesc(text, "RDKit_MolText", mol => mol.MolToMolBlock());
        }

        [ExcelFunction()]
        public static double RDKit_ChiNn(string text, int n)
        {
            return RDKit_CalcDesc(text, "RDKit_ChiNn" + n.ToString(), mol => RDKFuncs.calcChiNn(mol, (uint)n));
        }

        [ExcelFunction()]
        public static double RDKit_ChiNv(string text, int n)
        {
            return RDKit_CalcDesc(text, "RDKit_ChiNv" + n.ToString(), mol => RDKFuncs.calcChiNv(mol, (uint)n));
        }
    }

    public static partial class RDKitUtility
    {
        public const string SeparatorofNameKind = NCDKExcel.Utility.SeparatorofNameKind;

        static readonly IDictionary<string, ROMol> MolecularCache = new Dictionary<string, ROMol>();
        static readonly ROMol nullMol = new RWMol();

        public static ROMol Parse(string ident)
        {
            if (ident == null)
                throw new ArgumentNullException(nameof(ident));

            LineNotationType notationType = 0;
            if (!MolecularCache.TryGetValue(ident, out ROMol mol))
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
                    mol = nullMol;
                MolecularCache[ident] = mol;
            }
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
