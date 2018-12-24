// MIT License
// 
// Copyright (c) 2018 Kazuya Ujihara
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
using NCDK.Aromaticities;
using NCDK.Config;
using NCDK.Graphs;
using NCDK.Graphs.InChI;
using NCDK.IO;
using NCDK.QSAR;
using NCDK.Silent;
using NCDK.Smiles;
using NCDK.Tools;
using NCDK.Tools.Manipulator;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Caching;

namespace NCDKExcel
{
    public static partial class DescriptorFunctions
    {
        static readonly object sync_lock_propCache = new object();
        static readonly MemoryCache propCache = new MemoryCache("9186893B3F504417AF7C8593C4786684");
        private const string SeparatorOfNameKind = "(S-E-P-A-R-A-T-O-R)";

        static string ToExcelString(object value)
        {
            switch (value)
            {
                case double v:
                    if (double.IsNaN(v))
                        return "#N/A";
                    if (double.IsInfinity(v))
                        return "#NUM!";
                    break;
            }
            return value.ToString();
        }

        static string ToExcelString(AbstractDescriptorResult result)
        {
            return string.Join(", ", result.Values.Select(n => ToExcelString(n)));
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
                var toStructure = InChIToStructure.FromInChI(inchi, ChemObjectBuilder.Instance);
                if (toStructure.ReturnStatus > InChIReturnCode.Warning)
                    throw new Exception(toStructure.Message);
                return toStructure.AtomContainer;
            }
            catch (Exception)
            {
            }
            return null;
        }

        static readonly IAtomContainer nullMol = ChemObjectBuilder.Instance.NewAtomContainer();
        static readonly object sync_lock_molCache = new object();
        static readonly MemoryCache molCache = new MemoryCache("2A66E877A5334899993A694156D51BCC");

        static IAtomContainer Parse(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            IAtomContainer mol;
            mol = molCache[text] as IAtomContainer;
            if (mol == null)
            {
                lock (sync_lock_molCache)
                {
                    mol = molCache[text] as IAtomContainer;
                    if (mol == null)
                    {
                        mol = RawParse(text);
                        if (mol == null)
                            mol = nullMol;

                        AtomContainerManipulator.PercieveAtomTypesAndConfigureAtoms(mol);
                        CDK.HydrogenAdder.AddImplicitHydrogens(mol);
                        Aromaticity.CDKLegacy.Apply(mol);
                        AtomContainerManipulator.ConvertImplicitToExplicitHydrogens(mol);
                        CDK.IsotopeFactory.ConfigureAtoms(mol);
                        Cycles.MarkRingAtomsAndBonds(mol);

                        var policy = new CacheItemPolicy();
                        molCache.Set(text, mol, policy);
                    }
                }

                if (object.ReferenceEquals(mol, nullMol))
                    return null;
            }
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
