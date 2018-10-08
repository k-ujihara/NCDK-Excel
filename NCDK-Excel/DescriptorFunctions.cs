/*
 * MIT License
 * 
 * Copyright (c) 2017 Kazuya Ujihara
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using NCDK;
using NCDK.Aromaticities;
using NCDK.AtomTypes;
using NCDK.Config;
using NCDK.Graphs;
using NCDK.Graphs.InChI;
using NCDK.IO;
using NCDK.QSAR;
using NCDK.QSAR.Results;
using NCDK.Silent;
using NCDK.Smiles;
using NCDK.Tools;
using NCDK.Tools.Manipulator;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Caching;

namespace ExcelNCDK
{
    public static partial class DescriptorFunctions
    {
        private const string SeparatorofNameKind = "(S-E-P-A-R-A-T-O-R)";

        static string ToExcelString(double value)
        {
            if (double.IsNaN(value))
                return "#N/A";
            if (double.IsInfinity(value))
                return "#NUM!";
            return value.ToString();
        }

        static string ToExcelString(DescriptorValue<ArrayResult<double>> result)
        {
            return string.Join(", ", result.Value.Select(n => ToExcelString(n)));
        }

        static string ToExcelString(DescriptorValue<ArrayResult<int>> result)
        {
            return string.Join(", ", result.Value.Select(n => n.ToString()));
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

        static void AddImplicitHydrogens(IAtomContainer container)
        {
            CDKAtomTypeMatcher matcher = CDKAtomTypeMatcher.GetInstance(container.Builder);
            int atomCount = container.Atoms.Count;
            string[] originalAtomTypeNames = new string[atomCount];
            for (int i = 0; i < atomCount; i++)
            {
                IAtom atom = container.Atoms[i];
                IAtomType type = matcher.FindMatchingAtomType(container, atom);
                originalAtomTypeNames[i] = atom.AtomTypeName;
                atom.AtomTypeName = type.AtomTypeName;
            }
            CDKHydrogenAdder hAdder = CDKHydrogenAdder.GetInstance(container.Builder);
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
            var mol = cache[text] as IAtomContainer;
            if (mol == null)
            {
                mol = RawParse(text);
                if (mol == null)
                    mol = nullMol;

                AtomContainerManipulator.PercieveAtomTypesAndConfigureAtoms(mol);
                Aromaticity.CDKLegacy.Apply(mol);
                CDKHydrogenAdder.GetInstance(ChemObjectBuilder.Instance).AddImplicitHydrogens(mol);
                AtomContainerManipulator.ConvertImplicitToExplicitHydrogens(mol);
                BODRIsotopeFactory.Instance.ConfigureAtoms(mol);
                Cycles.MarkRingAtomsAndBonds(mol);

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
