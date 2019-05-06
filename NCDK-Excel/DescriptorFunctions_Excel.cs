
/*
 * MIT License
 * 
 * Copyright (c) 2018-2019 Kazuya Ujihara
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
using NCDK.Geometries;
using NCDK.Tools.Manipulator;
using System.Runtime.Caching;

namespace NCDKExcel
{
    public static partial class DescriptorFunctions
    {
        [ExcelFunction()]
        public static double NCDK_AcidicGroupCount(string text)
        {
            var cache = MemoryCache.Default;
            var key = "AcidicGroupCount" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.AcidicGroupCountDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_AromaticAtomsCount(string text)
        {
            var cache = MemoryCache.Default;
            var key = "AromaticAtomsCount" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.AromaticAtomsCountDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_AromaticBondsCount(string text)
        {
            var cache = MemoryCache.Default;
            var key = "AromaticBondsCount" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.AromaticBondsCountDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_AtomCount(string text)
        {
            var cache = MemoryCache.Default;
            var key = "AtomCount" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.AtomCountDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_BasicGroupCount(string text)
        {
            var cache = MemoryCache.Default;
            var key = "BasicGroupCount" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.BasicGroupCountDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_BondCount(string text)
        {
            var cache = MemoryCache.Default;
            var key = "BondCount" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.BondCountDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }
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
                
                if (!GeometryUtil.Has3DCoordinates(mol))
                {
                    nReturnValue = "#N/A" ;
                }
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_EccentricConnectivityIndex(string text)
        {
            var cache = MemoryCache.Default;
            var key = "EccentricConnectivityIndex" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.EccentricConnectivityIndexDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
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
                
                if (!GeometryUtil.Has3DCoordinates(mol))
                {
                    nReturnValue = "#N/A" ;
                }
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_HBondAcceptorCount(string text)
        {
            var cache = MemoryCache.Default;
            var key = "HBondAcceptorCount" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.HBondAcceptorCountDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_HBondDonorCount(string text)
        {
            var cache = MemoryCache.Default;
            var key = "HBondDonorCount" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.HBondDonorCountDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_LargestChain(string text)
        {
            var cache = MemoryCache.Default;
            var key = "LargestChain" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.LargestChainDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_LargestPiSystem(string text)
        {
            var cache = MemoryCache.Default;
            var key = "LargestPiSystem" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.LargestPiSystemDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
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
                NCDK.Config.BODRIsotopeFactory.Instance.ConfigureAtoms(mol);
                if (!GeometryUtil.Has3DCoordinates(mol))
                {
                    nReturnValue = "#N/A" ;
                }
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_LongestAliphaticChain(string text)
        {
            var cache = MemoryCache.Default;
            var key = "LongestAliphaticChain" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.LongestAliphaticChainDescriptor(checkRingSystem: true);
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }
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
                
                if (!GeometryUtil.Has3DCoordinates(mol))
                {
                    nReturnValue = "#N/A" ;
                }
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
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
                
                if (!GeometryUtil.Has3DCoordinates(mol))
                {
                    nReturnValue = "#N/A" ;
                }
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_RotatableBondsCount(string text)
        {
            var cache = MemoryCache.Default;
            var key = "RotatableBondsCount" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.RotatableBondsCountDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
        }
        [ExcelFunction()]
        public static double NCDK_RuleOfFive(string text)
        {
            var cache = MemoryCache.Default;
            var key = "RuleOfFive" + SeparatorofNameKind + text;
            double? nReturnValue = cache[key] as double?;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.RuleOfFiveDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
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
                AtomContainerManipulator.PercieveAtomTypesAndConfigureAtoms(mol); AddImplicitHydrogens(mol);
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }
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
                
                if (!GeometryUtil.Has3DCoordinates(mol))
                {
                    nReturnValue = "#N/A" ;
                }
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
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
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (double)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_ECFP0(string text)
        {
            var cache = MemoryCache.Default;
            var key = "ECFP0" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.Fingerprints.CircularFingerprinter(NCDK.Fingerprints.CircularFingerprinterClass.ECFP0);
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_ECFP2(string text)
        {
            var cache = MemoryCache.Default;
            var key = "ECFP2" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.Fingerprints.CircularFingerprinter(NCDK.Fingerprints.CircularFingerprinterClass.ECFP2);
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_ECFP4(string text)
        {
            var cache = MemoryCache.Default;
            var key = "ECFP4" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.Fingerprints.CircularFingerprinter(NCDK.Fingerprints.CircularFingerprinterClass.ECFP4);
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_ECFP6(string text)
        {
            var cache = MemoryCache.Default;
            var key = "ECFP6" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.Fingerprints.CircularFingerprinter(NCDK.Fingerprints.CircularFingerprinterClass.ECFP6);
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_FCFP0(string text)
        {
            var cache = MemoryCache.Default;
            var key = "FCFP0" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.Fingerprints.CircularFingerprinter(NCDK.Fingerprints.CircularFingerprinterClass.FCFP0);
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_FCFP2(string text)
        {
            var cache = MemoryCache.Default;
            var key = "FCFP2" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.Fingerprints.CircularFingerprinter(NCDK.Fingerprints.CircularFingerprinterClass.FCFP2);
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_FCFP4(string text)
        {
            var cache = MemoryCache.Default;
            var key = "FCFP4" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.Fingerprints.CircularFingerprinter(NCDK.Fingerprints.CircularFingerprinterClass.FCFP4);
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_FCFP6(string text)
        {
            var cache = MemoryCache.Default;
            var key = "FCFP6" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.Fingerprints.CircularFingerprinter(NCDK.Fingerprints.CircularFingerprinterClass.FCFP6);
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_AtomPairs2DFingerprinter(string text)
        {
            var cache = MemoryCache.Default;
            var key = "AtomPairs2DFingerprinter" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.Fingerprints.AtomPairs2DFingerprinter();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_EStateFingerprinter(string text)
        {
            var cache = MemoryCache.Default;
            var key = "EStateFingerprinter" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.Fingerprints.EStateFingerprinter();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_ExtendedFingerprinter(string text)
        {
            var cache = MemoryCache.Default;
            var key = "ExtendedFingerprinter" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.Fingerprints.ExtendedFingerprinter();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_CDKFingerprinter(string text)
        {
            var cache = MemoryCache.Default;
            var key = "CDKFingerprinter" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.Fingerprints.Fingerprinter();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_KlekotaRothFingerprinter(string text)
        {
            var cache = MemoryCache.Default;
            var key = "KlekotaRothFingerprinter" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.Fingerprints.KlekotaRothFingerprinter();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_LingoFingerprinter(string text)
        {
            var cache = MemoryCache.Default;
            var key = "LingoFingerprinter" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.Fingerprints.LingoFingerprinter();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_MACCSFingerprinter(string text)
        {
            var cache = MemoryCache.Default;
            var key = "MACCSFingerprinter" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.Fingerprints.MACCSFingerprinter();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_ShortestPathFingerprinter(string text)
        {
            var cache = MemoryCache.Default;
            var key = "ShortestPathFingerprinter" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.Fingerprints.ShortestPathFingerprinter();
                AtomContainerManipulator.PercieveAtomTypesAndConfigureAtoms(mol);
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_SubstructureFingerprinter(string text)
        {
            var cache = MemoryCache.Default;
            var key = "SubstructureFingerprinter" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.Fingerprints.SubstructureFingerprinter();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
        [ExcelFunction()]
        public static string NCDK_PubchemFingerprinter(string text)
        {
            var cache = MemoryCache.Default;
            var key = "PubchemFingerprinter" + SeparatorofNameKind + text;
            string nReturnValue = cache[key] as string;

            if (nReturnValue == null)
            {
                var mol = Parse(text);
                var descriptor = new NCDK.Fingerprints.PubchemFingerprinter();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }
                var policy = new CacheItemPolicy();
                cache.Set(key, nReturnValue, policy);
            }
            return (string)nReturnValue;
        }
    }
}

