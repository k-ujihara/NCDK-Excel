using ExcelDna.Integration;
using NCDK;
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
    }
}
