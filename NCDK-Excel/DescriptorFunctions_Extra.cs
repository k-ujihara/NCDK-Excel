using ExcelDna.Integration;
using NCDK;
using NCDK.Graphs.InChI;
using System;
using System.Runtime.Caching;
using static NCDKExcel.Utility;

namespace NCDKExcel
{
    public static partial class DescriptorFunctions
    {
        static double NCDK_CalcDoubleDesc(string text, string name, Func<IAtomContainer, double?> calculator)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            var cache = MemoryCache.Default;
            var key = name + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;
            if (nReturnValue == null)
            {
                var mol = Parse(text);
                nReturnValue = calculator(mol);
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return nReturnValue.Value;
        }

        static string NCDK_CalcStringDesc(string text, string name, Func<IAtomContainer, string> calculator)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            var cache = MemoryCache.Default;
            var key = name + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;
            if (nReturnValue == null)
            {
                var mol = Parse(text);
                nReturnValue = calculator(mol);
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return nReturnValue;
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
