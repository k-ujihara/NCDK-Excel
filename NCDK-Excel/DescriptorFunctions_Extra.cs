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

using ExcelDna.Integration;
using NCDK.QSAR;
using NCDK.QSAR.Results;
using System;
using System.Runtime.Caching;

namespace NCDKExcel
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
                lock (sync_lock_cache)
                {
                    result = cache[key] as DescriptorValue<ArrayResult<double>>;
                    if (result == null)
                    {
                        var mol = Parse(text);
                        result = new NCDK.QSAR.Descriptors.Moleculars.ALogPDescriptor().Calculate(mol);
                        var policy = new CacheItemPolicy();
                        cache.Set(key, result, policy);
                    }
                }
            }
            return result;
        }

        [ExcelFunction(IsThreadSafe = true)]
        public static double NCDK_ALogP(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            var val = Calc_ALogP(text);
            return val.Value[0];
        }

        [ExcelFunction(IsThreadSafe = true)]
        public static double NCDK_AMolarRefractivity(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            var val = Calc_ALogP(text);
            return val.Value[2];
        }
    }
}
