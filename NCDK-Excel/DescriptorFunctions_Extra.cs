using ExcelDna.Integration;
using NCDK.QSAR;
using NCDK.QSAR.Results;
using System;
using System.Runtime.Caching;

namespace ExcelNCDK
{
    public static partial class DescriptorFunctions
    {
        static DescriptorValue<ArrayResult<double>> Calc_ALogP(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            var cache = MemoryCache.Default;
            var key = "AlogP" + SeparatorofNameKind + text;
            DescriptorValue<ArrayResult<double>> result = cache[key] as DescriptorValue<ArrayResult<double>>;
            if (result == null)
            {
                var mol = Parse(text);
                result = new NCDK.QSAR.Descriptors.Moleculars.ALogPDescriptor().Calculate(mol);
                var policy = new CacheItemPolicy();
                cache.Set(key, result, policy);
            }
            return result;
        }

        [ExcelFunction()]
        public static double NCDK_ALogP(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            var val = Calc_ALogP(text);
            return val.Value[0];
        }

        [ExcelFunction()]
        public static double NCDK_AMolarRefractivity(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            var val = Calc_ALogP(text);
            return val.Value[2];
        }
    }
}
