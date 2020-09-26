using ExcelDna.Integration;
using GraphMolWrap;
using System;
using System.Collections.Concurrent;
using System.Text;
using static NCDKExcel.RDKitMol;

namespace NCDKExcel
{
    static partial class Caching<TRet>
    {
        public static TRet Calculate(string text, string name, Func<ROMol, TRet> calculator)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            var key = new Tuple<string, string>(name, text);
            var nReturnValue = ValueCache.GetOrAdd(key, tuple =>
            {
                var mol = Parse(text);
                return calculator(mol);
            });

            return nReturnValue;
        }
    }

    public static partial class DescriptorFunctions
    {
        [ExcelFunction(Description = "Returns the Morgan fingerprint.")]
        public static string RDKit_MorganFingerprint(string text, int radius, int nBits)
        {
            if (nBits == 0)
                nBits = 2048;

            var ret = Caching<string>.Calculate(text, $"RDKit_MorganFingerprint:{radius}:{nBits}",
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

            var ret = Caching<T>.Calculate(text, name, calculator);
            return ret;
        }

        [ExcelFunction(Description = "Returns the InChI.")]
        public static string RDKit_InChI(string text, string options)
        {
            return RDKit_CalcDesc(text, "RDKit_InChI", mol =>
            {
                using (var rv = new ExtraInchiReturnValues())
                {
                    return RDKit.Chem.MolToInchi(mol, options, rv);
                }
            });
        }

        [ExcelFunction(Description = "Returns the chi Nn.")]
        public static double RDKit_ChiNn(string text, int n)
        {
            return RDKit_CalcDesc(text, "RDKit_ChiNn" + n.ToString(), mol => RDKFuncs.calcChiNn(mol, (uint)n));
        }

        [ExcelFunction(Description = "Returns the chi Nv.")]
        public static double RDKit_ChiNv(string text, int n)
        {
            return RDKit_CalcDesc(text, "RDKit_ChiNv" + n.ToString(), mol => RDKFuncs.calcChiNv(mol, (uint)n));
        }
    }

    public static class RDKitMol
    {
        static readonly ConcurrentDictionary<string, ROMol> MolecularCache = new ConcurrentDictionary<string, ROMol>();
        static readonly ROMol nullMol = new RWMol();

        public static ROMol Parse(string ident)
        {
            if (ident == null)
                throw new ArgumentNullException(nameof(ident));

            var mol = MolecularCache.GetOrAdd(ident, a_ident =>
            {
                string notationType = null;
                ROMol a_mol;

                a_mol = RWMol.MolFromSmiles(ident);
                if (a_mol != null)
                {
                    notationType = "SMILES";
                    goto L_Found;
                }

                using (var rv = new ExtraInchiReturnValues())
                {
                    a_mol = RDKFuncs.InchiToMol(ident, rv);
                    if (a_mol != null)
                    {
                        notationType = "InChI";
                        goto L_Found;
                    }
                }

                a_mol = RWMol.MolFromMolBlock(ident);
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
