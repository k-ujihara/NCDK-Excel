// MIT License
// 
// Copyright (c) 2018-2019 Kazuya Ujihara
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.


using NCDK;
using NCDK.Fingerprints;
using NCDK.IO;
using NCDK.QSAR;
using NCDK.Silent;
using NCDK.Smiles;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Text;

namespace NCDKExcel
{
    public static partial class DescriptorFunctions
    {
        private const string SeparatorofNameKind = "(S-E-P-A-R-A-T-O-R)";

        static string ToExcelString(object value)
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

        static string ToExcelString(IDescriptorResult result)
        {
            return string.Join(", ", result.Values.Select(n => ToExcelString(n)));
        }

        static string ToExcelString(IBitFingerprint fp)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < fp.Length; i++)
            {
                sb.Append(fp[i] ? "1" : "0");
            }
            return sb.ToString();
        }

        static SmilesParser parser = new SmilesParser(ChemObjectBuilder.Instance);

        static IAtomContainer ParseSmiles(string smiles)
        {
            try
            {
                var mol = parser.ParseSmiles(smiles);
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
                using (var reader = new InChIPlainTextReader(new StringReader(inchi)))
                {
                    var chemFile = reader.Read(new ChemFile());
                    if (chemFile.Count != 1)
                        throw new Exception();
                    var seq = chemFile[0];
                    if (seq.Count != 1)
                        throw new Exception();
                    var model = seq[0];
                    if (model.MoleculeSet.Count != 1)
                        throw new Exception();
                    var mol = model.MoleculeSet[0];
                    return mol;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        static void AddImplicitHydrogens(IAtomContainer container)
        {
            var matcher = CDK.AtomTypeMatcher;
            int atomCount = container.Atoms.Count;
            string[] originalAtomTypeNames = new string[atomCount];
            for (int i = 0; i < atomCount; i++)
            {
                IAtom atom = container.Atoms[i];
                IAtomType type = matcher.FindMatchingAtomType(container, atom);
                originalAtomTypeNames[i] = atom.AtomTypeName;
                atom.AtomTypeName = type.AtomTypeName;
            }
            var hAdder = CDK.HydrogenAdder;
            hAdder.AddImplicitHydrogens(container);
            // reset to the original atom types
            for (int i = 0; i < atomCount; i++)
            {
                IAtom atom = container.Atoms[i];
                atom.AtomTypeName = originalAtomTypeNames[i];
            }
        }

        static readonly IAtomContainer nullMol = ChemObjectBuilder.Instance.NewAtomContainer();

        static IAtomContainer Parse(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            var cache = MemoryCache.Default;
            if (!(cache[text] is IAtomContainer mol))
            {
                mol = RawParse(text);
                if (mol == null)
                    mol = nullMol;

                var policy = new CacheItemPolicy();
                cache.Set(text, mol, policy);
            }
            if (object.ReferenceEquals(mol, nullMol))
                return null;
            return mol;
        }

        static IAtomContainer RawParse(string text)
        {
            IAtomContainer mol = null;

            if (text == null)
                return null;
            if (text.IndexOf('\r') >= 0)
                goto Go_Mol;
            if (text.IndexOf('\n') >= 0)
                goto Go_Mol;

            mol = ParseSmiles(text);
            if (mol != null)
                return mol;

            mol = ParseInChI(text);
            if (mol != null)
                return mol;
           
            Go_Mol:
            using (var r = new MDLV2000Reader(new StringReader(text)))
            {
                var m = ChemObjectBuilder.Instance.NewAtomContainer();
                try
                {
                    r.Read(m);
                    mol = m;
                }
                catch (Exception)
                { }
            }
            if (mol != null)
                return mol;

            using (var r = new MDLV3000Reader(new StringReader(text)))
            {
                var m = ChemObjectBuilder.Instance.NewAtomContainer();
                try
                {
                    r.Read(m);
                    mol = m;
                }
                catch (Exception)
                { }
            }
            if (mol != null)
                return mol;

            return null;
        }
    }
}
