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
        static IDictionary<string, ROMol> RDKitMolecularCache = new Dictionary<string, ROMol>();
        static ROMol nullMolRDKit = new RWMol();

        public static ROMol ParseRDKitMol(string ident)
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
                // inchi is not supported yet
                mol = RWMol.MolFromMolBlock(ident);
                if (mol != null)
                {
                    notationType = LineNotationType.MolText;
                    goto L_MolFound;
                }
                if (mol == null)
                    mol = nullMolRDKit;
            L_MolFound:
                RDKitMolecularCache[ident] = mol;
            }
            return mol;
        }

        public static T CalculateRDKit(string text, string name, Func<ROMol, T> calculator)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            var key = name + SeparatorofNameKind + text;
            if (!ValueCache.TryGetValue(key, out T nReturnValue))
            {
                var mol = ParseRDKitMol(text);
                nReturnValue = calculator(mol);
                ValueCache[key] = nReturnValue;
            }
            return nReturnValue;
        }
    }

    public static partial class DescriptorFunctions
    {
        public static string ToExcelStringRDKit(BitVect fp)
        {
            var sb = new StringBuilder();
            var n = fp.getNumBits();
            for (uint i = 0; i < n; i++)
            {
                sb.Append(fp.getBit(i) ? "1" : "0");
            }
            return sb.ToString();
        }

        [ExcelFunction()]
        public static string RDKit_MACCSFingerprint(string text)
        {
            var ret = Caching<string>.CalculateRDKit(text, "RDKit_MACCSFingerprint",
                mol =>
                {
                    using (var result = RDKFuncs.MACCSFingerprintMol(mol))
                    {
                        if (result == null)
                            return null;
                        return ToExcelStringRDKit(result);
                    }
                });
            return ret;
        }
    }
}
