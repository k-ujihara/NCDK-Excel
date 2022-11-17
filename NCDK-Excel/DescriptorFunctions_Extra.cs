using ExcelDna.Integration;
using NCDK;
using NCDK.Graphs.InChI;
using System;
using System.Collections.Concurrent;
using static NCDKExcel.Utility;

namespace NCDKExcel
{
    static partial class Caching<TRet>
    {
        static readonly ConcurrentDictionary<Tuple<string, string>, TRet> ValueCache = new ConcurrentDictionary<Tuple<string, string>, TRet>();

        public static TRet Calculate(string text, string name, Func<IAtomContainer, TRet> calculator)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            var key = new Tuple<string, string>(name, text);
            TRet nReturnValue = ValueCache.GetOrAdd(key, tuple =>
            {
                var mol = Parse(text);
                return calculator(mol);
            });

            return nReturnValue;
        }
    }

    public static partial class DescriptorFunctions
    {
        /// <summary>
        /// Calculate descriptor returns <see cref="System.Double"/> in Excel.
        /// </summary>
        /// <param name="molecule_ident">Input text to caluculate, typically molecular identifier.</param>
        /// <param name="name">The descriptor name.</param>
        /// <param name="calculator">The caluculator.</param>
        /// <returns>Calculated value as <see cref="System.Double"/>.</returns>
        static double NCDK_CalcDoubleDesc(string molecule_ident, string name, Func<IAtomContainer, double?> calculator)
        {
            if (molecule_ident == null)
                throw new ArgumentNullException(nameof(molecule_ident));

            var ret = Caching<double?>.Calculate(molecule_ident, name, calculator);
            return ret.Value;
        }

        /// <summary>
        /// Calculate descriptor returns <see cref="System.String"/> in Excel.
        /// </summary>
        /// <param name="text">Input text to caluculate, typically molecular identifier.</param>
        /// <param name="name">The descriptor name.</param>
        /// <param name="calculator">The caluculator.</param>
        /// <returns>Calculated value as <see cref="System.String"/>.</returns>
        static string NCDK_CalcStringDesc(string text, string name, Func<IAtomContainer, string> calculator)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            var ret = Caching<string>.Calculate(text, name, calculator);
            return ret;
        }

        /// <summary>
        /// Call NCDK functions by name.
        /// This calls <see cref="DescriptorFunctions"/>.NCDK_<paramref name="name"/>(<paramref name="molecule_ident"/>) method using refrection.
        /// </summary>
        /// <param name="name">The name to specify the method.</param>
        /// <param name="molecule_ident">The text to specify the molecule.</param>
        /// <returns>The calculated value expressed by string.</returns>
        [ExcelFunction(Name = "NCDK")]
        public static string NCDKByName(string name, string molecule_ident)
        {
            var type = typeof(DescriptorFunctions);
            var method = type.GetMethod("NCDK_" + name);
            if (method == null)
                return null;
            var ret = method.Invoke(null, new object[] { molecule_ident });
            return ret?.ToString();
        }

        [ExcelFunction("Returns ALogP")]
        public static double NCDK_ALogP(string molecule_ident)
        {
            return NCDK_CalcDoubleDesc(molecule_ident, "NCDK_ALogP", mol => new NCDK.QSAR.Descriptors.Moleculars.ALogPDescriptor().Calculate(mol).Value);
        }

        [ExcelFunction("Returns molar refractivity")]
        public static double NCDK_AMolarRefractivity(string text)
        {
            return NCDK_CalcDoubleDesc(text, "NCDK_AMolarRefractivity", mol => new NCDK.QSAR.Descriptors.Moleculars.ALogPDescriptor().Calculate(mol).AMR);
        }


        [ExcelFunction("Returns molecular weight")]
        public static double NCDK_MolecularWeight(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_MolecularWeight",
                mol =>
                {
                    double? nReturnValue = null;

                    if (nReturnValue == null)
                    {
                        var result = NCDK.Tools.Manipulator.AtomContainerManipulator.GetMass(mol, NCDK.Tools.Manipulator.MolecularWeightTypes.MolWeight);
                        nReturnValue = result;
                    }

                    return (double)nReturnValue;
                });
            return (double)ret;
        }

        [ExcelFunction("Returns exact mass")]
        public static double NCDK_ExactMass(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_ExactMass",
                mol =>
                {
                    double? nReturnValue = null;

                    if (nReturnValue == null)
                    {
                        var result = NCDK.Tools.Manipulator.AtomContainerManipulator.GetMass(mol, NCDK.Tools.Manipulator.MolecularWeightTypes.MostAbundant);
                        nReturnValue = result;
                    }

                    return (double)nReturnValue;
                });
            return (double)ret;
        }

        private static NCDK.QSAR.Descriptors.Moleculars.BCUTDescriptor.Result CalcBCUT(string molecule_ident, int nhigh, int nlow)
        {
            if (nhigh == 0)
                nhigh = 1;
            if (nlow == 0)
                nlow = 1;

            var mol = Parse(molecule_ident);
            var descriptor = new NCDK.QSAR.Descriptors.Moleculars.BCUTDescriptor();
            var result = descriptor.Calculate(mol, nhigh, nlow);
            return result;
        }

        [ExcelFunction(Description = "Returns the BCUT.")]
        public static string NCDK_BCUT(string molecule_ident, int nhigh, int nlow)
        {
            var result = CalcBCUT(molecule_ident, nhigh, nlow);
            return ToExcelString(result);
        }

        [ExcelFunction(Description = "Returns the element of BCUT.")]
        public static double NCDK_BCUTWithIndex(string molecule_ident, string key, int nhigh, int nlow)
        {
            var result = CalcBCUT(molecule_ident, nhigh, nlow);
            if (int.TryParse(key, out int index))
                return result.Values[index - 1];
            else
            {
                result.TryGetValue(key, out double value);
                return value;
            }
        }

        internal static NCDK.Smiles.SmilesGenerator SmilesGenerator { get; } = new NCDK.Smiles.SmilesGenerator(NCDK.Smiles.SmiFlavors.Default);

        [ExcelFunction()]
        public static string NCDK_SMILES(string molecule_ident)
        {
            return NCDK_CalcStringDesc(molecule_ident, "NCDK_SMILES", mol => SmilesGenerator.Create(mol));
        }

        [ExcelFunction()]
        public static string NCDK_InChI(string molecule_ident)
        {
            return NCDK_CalcStringDesc(molecule_ident, "NCDK_InChI", mol => InChIGeneratorFactory.Instance.GetInChIGenerator(mol).InChI);
        }

        [ExcelFunction()]
        public static string NCDK_InChIKey(string molecule_ident)
        {
            return NCDK_CalcStringDesc(molecule_ident, "NCDK_InChIKey", mol => InChIGeneratorFactory.Instance.GetInChIGenerator(mol).GetInChIKey());
        }

        [ExcelFunction()]
        public static string NCDK_MolBlock(string molecule_ident)
        {
            return NCDK_CalcStringDesc(molecule_ident, "NCDK_MolBlock", mol => Utility.ToMolBlock(mol));
        }
    }
}
