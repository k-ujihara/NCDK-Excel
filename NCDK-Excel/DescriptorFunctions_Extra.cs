using ExcelDna.Integration;
using System;
using System.Runtime.Caching;

namespace NCDKExcel
{
    public static partial class DescriptorFunctions
    {
        [ExcelFunction()]
        public static double NCDK_ALogP(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            var cache = MemoryCache.Default;
            var key = "AlogP" + SeparatorofNameKind + text;
            double? result = cache[key] as double?;
            if (result == null)
            {
                var mol = Parse(text);
                result = new NCDK.QSAR.Descriptors.Moleculars.ALogPDescriptor().Calculate(mol).Value;
            }
            return result.Value;
        }

        [ExcelFunction()]
        public static double NCDK_AMolarRefractivity(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            var cache = MemoryCache.Default;
            var key = "AMolarRefractivity" + SeparatorofNameKind + text;
            double? result = cache[key] as double?;
            if (result == null)
            {
                var mol = Parse(text);
                result = new NCDK.QSAR.Descriptors.Moleculars.ALogPDescriptor().Calculate(mol).AMR;
            }
            return result.Value;
        }
    }
}
