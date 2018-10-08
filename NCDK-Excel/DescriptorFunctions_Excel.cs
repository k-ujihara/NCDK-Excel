
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

using ExcelDna.Integration;
using NCDK.Tools.Manipulator;
using System.Runtime.Caching;

namespace ExcelNCDK
{
    public static partial class DescriptorFunctions
    {
        [ExcelFunction()]
        public static int NCDK_AcidicGroupCount(string text)
        {
            var cache = MemoryCache.Default;
            var key = "AcidicGroupCount" + SeparatorofNameKind + text;
            int? nReturnValue = cache[key] as int?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.AcidicGroupCountDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (int)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_APol(string text)
        {
            var cache = MemoryCache.Default;
            var key = "APol" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.APolDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
        }
        [ExcelFunction()]
        public static int NCDK_AromaticAtomsCount(string text)
        {
            var cache = MemoryCache.Default;
            var key = "AromaticAtomsCount" + SeparatorofNameKind + text;
            int? nReturnValue = cache[key] as int?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.AromaticAtomsCountDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (int)nReturnValue;
        }
        [ExcelFunction()]
        public static int NCDK_AromaticBondsCount(string text)
        {
            var cache = MemoryCache.Default;
            var key = "AromaticBondsCount" + SeparatorofNameKind + text;
            int? nReturnValue = cache[key] as int?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.AromaticBondsCountDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (int)nReturnValue;
        }
        [ExcelFunction()]
        public static int NCDK_AtomCount(string text)
        {
            var cache = MemoryCache.Default;
            var key = "AtomCount" + SeparatorofNameKind + text;
            int? nReturnValue = cache[key] as int?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.AtomCountDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (int)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_AutocorrelationCharge(string text)
        {
            var cache = MemoryCache.Default;
            var key = "AutocorrelationCharge" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.AutocorrelationDescriptorCharge();
                var result = descriptor.Calculate(mol);
                nReturnValue = ToExcelString(result);
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_AutocorrelationMass(string text)
        {
            var cache = MemoryCache.Default;
            var key = "AutocorrelationMass" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.AutocorrelationDescriptorMass();
                var result = descriptor.Calculate(mol);
                nReturnValue = ToExcelString(result);
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_AutocorrelationPolarizability(string text)
        {
            var cache = MemoryCache.Default;
            var key = "AutocorrelationPolarizability" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.AutocorrelationDescriptorPolarizability();
                var result = descriptor.Calculate(mol);
                nReturnValue = ToExcelString(result);
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static int NCDK_BasicGroupCount(string text)
        {
            var cache = MemoryCache.Default;
            var key = "BasicGroupCount" + SeparatorofNameKind + text;
            int? nReturnValue = cache[key] as int?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.BasicGroupCountDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (int)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_BCUT(string text)
        {
            var cache = MemoryCache.Default;
            var key = "BCUT" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.BCUTDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = ToExcelString(result);
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static int NCDK_BondCount(string text)
        {
            var cache = MemoryCache.Default;
            var key = "BondCount" + SeparatorofNameKind + text;
            int? nReturnValue = cache[key] as int?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.BondCountDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (int)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_BPol(string text)
        {
            var cache = MemoryCache.Default;
            var key = "BPol" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.BPolDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_CarbonTypes(string text)
        {
            var cache = MemoryCache.Default;
            var key = "CarbonTypes" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.CarbonTypesDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = ToExcelString(result);
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_ChiChain(string text)
        {
            var cache = MemoryCache.Default;
            var key = "ChiChain" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.ChiChainDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = ToExcelString(result);
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_ChiCluster(string text)
        {
            var cache = MemoryCache.Default;
            var key = "ChiCluster" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.ChiClusterDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = ToExcelString(result);
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_ChiPathCluster(string text)
        {
            var cache = MemoryCache.Default;
            var key = "ChiPathCluster" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.ChiPathClusterDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = ToExcelString(result);
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_ChiPath(string text)
        {
            var cache = MemoryCache.Default;
            var key = "ChiPath" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.ChiPathDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = ToExcelString(result);
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_CPSA(string text)
        {
            var cache = MemoryCache.Default;
            var key = "CPSA" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.CPSADescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = ToExcelString(result);
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static int NCDK_EccentricConnectivityIndex(string text)
        {
            var cache = MemoryCache.Default;
            var key = "EccentricConnectivityIndex" + SeparatorofNameKind + text;
            int? nReturnValue = cache[key] as int?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.EccentricConnectivityIndexDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (int)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_FMF(string text)
        {
            var cache = MemoryCache.Default;
            var key = "FMF" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.FMFDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_FractionalPSA(string text)
        {
            var cache = MemoryCache.Default;
            var key = "FractionalPSA" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.FractionalPSADescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_FragmentComplexity(string text)
        {
            var cache = MemoryCache.Default;
            var key = "FragmentComplexity" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.FragmentComplexityDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_GravitationalIndex(string text)
        {
            var cache = MemoryCache.Default;
            var key = "GravitationalIndex" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.GravitationalIndexDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = ToExcelString(result);
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static int NCDK_HBondAcceptorCount(string text)
        {
            var cache = MemoryCache.Default;
            var key = "HBondAcceptorCount" + SeparatorofNameKind + text;
            int? nReturnValue = cache[key] as int?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.HBondAcceptorCountDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (int)nReturnValue;
        }
        [ExcelFunction()]
        public static int NCDK_HBondDonorCount(string text)
        {
            var cache = MemoryCache.Default;
            var key = "HBondDonorCount" + SeparatorofNameKind + text;
            int? nReturnValue = cache[key] as int?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.HBondDonorCountDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (int)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_HybridizationRatio(string text)
        {
            var cache = MemoryCache.Default;
            var key = "HybridizationRatio" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.HybridizationRatioDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_KappaShapeIndices(string text)
        {
            var cache = MemoryCache.Default;
            var key = "KappaShapeIndices" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.KappaShapeIndicesDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = ToExcelString(result);
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_KierHallSmarts(string text)
        {
            var cache = MemoryCache.Default;
            var key = "KierHallSmarts" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.KierHallSmartsDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = ToExcelString(result);
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static int NCDK_LargestChain(string text)
        {
            var cache = MemoryCache.Default;
            var key = "LargestChain" + SeparatorofNameKind + text;
            int? nReturnValue = cache[key] as int?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.LargestChainDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (int)nReturnValue;
        }
        [ExcelFunction()]
        public static int NCDK_LargestPiSystem(string text)
        {
            var cache = MemoryCache.Default;
            var key = "LargestPiSystem" + SeparatorofNameKind + text;
            int? nReturnValue = cache[key] as int?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.LargestPiSystemDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (int)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_LengthOverBreadth(string text)
        {
            var cache = MemoryCache.Default;
            var key = "LengthOverBreadth" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.LengthOverBreadthDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = ToExcelString(result);
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static int NCDK_LongestAliphaticChain(string text)
        {
            var cache = MemoryCache.Default;
            var key = "LongestAliphaticChain" + SeparatorofNameKind + text;
            int? nReturnValue = cache[key] as int?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.LongestAliphaticChainDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (int)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_MannholdLogP(string text)
        {
            var cache = MemoryCache.Default;
            var key = "MannholdLogP" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.MannholdLogPDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_MDE(string text)
        {
            var cache = MemoryCache.Default;
            var key = "MDE" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.MDEDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = ToExcelString(result);
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_MomentOfInertia(string text)
        {
            var cache = MemoryCache.Default;
            var key = "MomentOfInertia" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.MomentOfInertiaDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = ToExcelString(result);
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_PetitjeanNumber(string text)
        {
            var cache = MemoryCache.Default;
            var key = "PetitjeanNumber" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.PetitjeanNumberDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_PetitjeanShapeIndex(string text)
        {
            var cache = MemoryCache.Default;
            var key = "PetitjeanShapeIndex" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.PetitjeanShapeIndexDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = ToExcelString(result);
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static int NCDK_RotatableBondsCount(string text)
        {
            var cache = MemoryCache.Default;
            var key = "RotatableBondsCount" + SeparatorofNameKind + text;
            int? nReturnValue = cache[key] as int?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.RotatableBondsCountDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (int)nReturnValue;
        }
        [ExcelFunction()]
        public static int NCDK_RuleOfFive(string text)
        {
            var cache = MemoryCache.Default;
            var key = "RuleOfFive" + SeparatorofNameKind + text;
            int? nReturnValue = cache[key] as int?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.RuleOfFiveDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (int)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_SmallRing(string text)
        {
            var cache = MemoryCache.Default;
            var key = "SmallRing" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.SmallRingDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = ToExcelString(result);
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_TPSA(string text)
        {
            var cache = MemoryCache.Default;
            var key = "TPSA" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.TPSADescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_VABC(string text)
        {
            var cache = MemoryCache.Default;
            var key = "VABC" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.VABCDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_VAdjMa(string text)
        {
            var cache = MemoryCache.Default;
            var key = "VAdjMa" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.VAdjMaDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_Weight(string text)
        {
            var cache = MemoryCache.Default;
            var key = "Weight" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.WeightDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_WeightedPath(string text)
        {
            var cache = MemoryCache.Default;
            var key = "WeightedPath" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.WeightedPathDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = ToExcelString(result);
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_WHIM(string text)
        {
            var cache = MemoryCache.Default;
            var key = "WHIM" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.WHIMDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = ToExcelString(result);
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_WienerNumbers(string text)
        {
            var cache = MemoryCache.Default;
            var key = "WienerNumbers" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.WienerNumbersDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = ToExcelString(result);
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_XLogP(string text)
        {
            var cache = MemoryCache.Default;
            var key = "XLogP" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.XLogPDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_ZagrebIndex(string text)
        {
            var cache = MemoryCache.Default;
            var key = "ZagrebIndex" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.ZagrebIndexDescriptor();
                var result = descriptor.Calculate(mol);
                nReturnValue = result.Value.Value;
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
        }
    }
}

