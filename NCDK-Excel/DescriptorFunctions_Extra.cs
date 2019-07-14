using ExcelDna.Integration;
using NCDK;
using NCDK.Graphs.InChI;
using System;
using System.Collections.Generic;
using static NCDKExcel.Utility;

namespace NCDKExcel
{
    static class Caching<T>
    {
        static IDictionary<string, T> ValueCache = new Dictionary<string, T>();

        public static T Calculate(string text, string name, Func<IAtomContainer, T> calculator)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            var key = name + SeparatorofNameKind + text;
            if (!ValueCache.TryGetValue(key, out T nReturnValue))
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
        static IDictionary<string, double?> ValueCacheDouble = new Dictionary<string, double?>();

        /// <summary>
        /// Calculate descriptor returns <see cref="System.Double"/> in Excel.
        /// </summary>
        /// <param name="text">Input text to caluculate, typically molecular identifier.</param>
        /// <param name="name">The descriptor name.</param>
        /// <param name="calculator">The caluculator.</param>
        /// <returns>Calculated value as <see cref="System.Double"/>.</returns>
        static double NCDK_CalcDoubleDesc(string text, string name, Func<IAtomContainer, double?> calculator)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            var key = name + SeparatorofNameKind + text;
            var ret = Caching<double?>.Calculate(text, name, calculator);
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

            var key = name + SeparatorofNameKind + text;
            var ret = Caching<string>.Calculate(text, name, calculator);
            return ret;
        }

        /// <summary>
        /// Call NCDK functions by name.
        /// This calls <see cref="DescriptorFunctions"/>.NCDK_<paramref name="name"/>(<paramref name="text"/>) method using refrection.
        /// </summary>
        /// <param name="name">The name to specify the method.</param>
        /// <param name="text">The text to specify the molecule.</param>
        /// <returns>The calculated value expressed by string.</returns>
        [ExcelFunction(Name = "NCDK")]
        public static string NCDKByName(string name, string text)
        {
            var type = typeof(DescriptorFunctions);
            var method = type.GetMethod("NCDK_" + name);
            if (method == null)
                return null;
            var ret = method.Invoke(null, new object[] { text });
            return ret?.ToString();
        }

        [ExcelFunction()]
        public static double NCDK_ALogP(string text)
        {
            return NCDK_CalcDoubleDesc(text, "AlogP", mol => new NCDK.QSAR.Descriptors.Moleculars.ALogPDescriptor().Calculate(mol).Value);
        }

        [ExcelFunction()]
        public static double NCDK_AMolarRefractivity(string text)
        {
            return NCDK_CalcDoubleDesc(text, "AMolarRefractivity", mol => new NCDK.QSAR.Descriptors.Moleculars.ALogPDescriptor().Calculate(mol).AMR);
        }


        [ExcelFunction()]
        public static double NCDK_MolecularWeight(string text)
        {
            var ret = Caching<double?>.Calculate(text, "MolecularWeight",
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

        [ExcelFunction()]
        public static double NCDK_ExactMass(string text)
        {
            var ret = Caching<double?>.Calculate(text, "ExactMass",
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

        private static NCDK.Smiles.SmilesGenerator localSmilesGenerator = null;
        private static readonly object lockSmilesGenerator = new object();
        internal static NCDK.Smiles.SmilesGenerator SmilesGenerator
        {
            get
            {
                if (localSmilesGenerator == null)
                    lock (lockSmilesGenerator)
                    {
                        if (localSmilesGenerator == null)
                            localSmilesGenerator = new NCDK.Smiles.SmilesGenerator(NCDK.Smiles.SmiFlavors.Default);
                    }

                return localSmilesGenerator;
            }
        }

        [ExcelFunction()]
        public static string NCDK_SMILES(string text)
        {
            return NCDK_CalcStringDesc(text, "SMILES", mol => SmilesGenerator.Create(mol));
        }

        [ExcelFunction()]
        public static string NCDK_InChI(string text)
        {
            return NCDK_CalcStringDesc(text, "InChI", mol => InChIGeneratorFactory.Instance.GetInChIGenerator(mol).InChI);
        }

        [ExcelFunction()]
        public static string NCDK_InChIKey(string text)
        {
            return NCDK_CalcStringDesc(text, "InChIKey", mol => InChIGeneratorFactory.Instance.GetInChIGenerator(mol).GetInChIKey());
        }

        [ExcelFunction()]
        public static string NCDK_MolText(string text)
        {
            return NCDK_CalcStringDesc(text, "MolText", mol => Utility.ToMolText(mol));
        }
    }
}
