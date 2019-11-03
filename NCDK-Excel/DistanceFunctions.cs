/*
 * MIT License
 * 
 * Copyright (c) 2019 Kazuya Ujihara
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
using GraphMolWrap;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NCDKExcel
{
    public static class DistanceFunctions
    {
        [ExcelFunction()]
        public static double NCDK_Tanimoto(string fp1, string fp2)
        {
            var val = double.NaN;
            var ba1 = ToBitArrayOrNull(fp1);
            var ba2 = ToBitArrayOrNull(fp2);

            if (ba1 != null && ba2 != null)
            {
                if (ba1.Length == ba2.Length)
                {
                    val = NCDK.Similarity.Tanimoto.Calculate(ba1, ba2);
                }
            }

            return val;
        }

        /// <summary>
        /// Convert <paramref name="fp"/> to <see cref="BitArray"/> or <see langword="null"/> if failed.
        /// </summary>
        /// <param name="fp">Fingerprint expressed in string to convert.</param>
        /// <returns>Fingerprint in <see cref="BitArray"/>, <see langword="null"/> on failed to convert.</returns>
        public static BitArray ToBitArrayOrNull(string fp)
        {
            var array = new bool[fp.Length];
            for (int i = 0; i < fp.Length; i++)
            {
                switch (fp[i])
                {
                    case '0':
                        array[i] = false;
                        break;
                    case '1':
                        array[i] = true;
                        break;
                    default:
                        return null;
                }
            }
            return new BitArray(array);
        }

        [ExcelFunction()]
        public static double RDKit_TanimotoSimilarity(string fp1, string fp2)
        {
            var val = RDKit_Similarity(RDKFuncs.TanimotoSimilarity, fp1, fp2);
            if (double.IsNaN(val))
                val = RDKit_Similarity(RDKFuncs.TanimotoSimilaritySIVi64, fp1, fp2);
            return val;
        }

        [ExcelFunction()]
        public static double RDKit_AllBitSimilarity(string fp1, string fp2)
        {            return RDKit_Similarity(RDKFuncs.AllBitSimilarity, fp1, fp2);
        }

        [ExcelFunction()]
        public static double RDKit_AsymmetricSimilarity(string fp1, string fp2)
        {
            return RDKit_Similarity(RDKFuncs.AsymmetricSimilarity, fp1, fp2);
        }

        [ExcelFunction()]
        public static double RDKit_BraunBlanquetSimilarity(string fp1, string fp2)
        {
            return RDKit_Similarity(RDKFuncs.BraunBlanquetSimilarity, fp1, fp2);
        }

        [ExcelFunction()]
        public static double RDKit_CosineSimilarity(string fp1, string fp2)
        {
             return RDKit_Similarity(RDKFuncs.CosineSimilarity, fp1, fp2);
        }

        [ExcelFunction()]
        public static double RDKit_DiceSimilarity(string fp1, string fp2)
        {
            var val = RDKit_Similarity((ExplicitBitVect v1, ExplicitBitVect v2) => RDKFuncs.DiceSimilarity(v1, v2), fp1, fp2);
            if (double.IsNaN(val))
                val = RDKit_Similarity((SparseIntVect64 v1, SparseIntVect64 v2) => RDKFuncs.DiceSimilarity(v1, v2), fp1, fp2);
            return val;
        }

        [ExcelFunction()]
        public static double RDKit_KulczynskiSimilarity(string fp1, string fp2)
        {
            return RDKit_Similarity(RDKFuncs.KulczynskiSimilarity, fp1, fp2);
        }

        [ExcelFunction()]
        public static double RDKit_McConnaugheySimilarity(string fp1, string fp2)
        {
            return RDKit_Similarity(RDKFuncs.McConnaugheySimilarity, fp1, fp2);
        }

        [ExcelFunction()]
        public static double RDKit_OnBitSimilarity(string fp1, string fp2)
        {
            return RDKit_Similarity(RDKFuncs.OnBitSimilarity, fp1, fp2);
        }

        [ExcelFunction()]
        public static double RDKit_RusselSimilarity(string fp1, string fp2)
        {
            return RDKit_Similarity(RDKFuncs.RusselSimilarity, fp1, fp2);
        }

        [ExcelFunction()]
        public static double RDKit_SokalSimilarity(string fp1, string fp2)
        {
            return RDKit_Similarity(RDKFuncs.SokalSimilarity, fp1, fp2);
        }

        [ExcelFunction()]
        public static double RDKit_TverskySimilarity(string fp1, string fp2, double a, double b)
        {
            var val = RDKit_Similarity((ExplicitBitVect v1, ExplicitBitVect v2) => RDKFuncs.TverskySimilarity(v1, v2, a, b), fp1, fp2);
            if (double.IsNaN(val))
                val = RDKit_Similarity((SparseIntVect64 v1, SparseIntVect64 v2) => RDKFuncs.TverskySimilarity(v1, v2, a, b), fp1, fp2);
            return val;
        }

        static double RDKit_Similarity(Func<ExplicitBitVect, ExplicitBitVect, double> func, string fp1, string fp2)
        {
            var val = double.NaN;
            var bv1 = ToBitVectorOrNull(fp1);
            var bv2 = ToBitVectorOrNull(fp2);

            if (bv1 != null && bv2 != null)
            {
                if (bv1.size() == bv2.size())
                {
                    val = func(bv1, bv2);
                }
            }

            return val;
        }

        static double RDKit_Similarity(Func<SparseIntVect64, SparseIntVect64, double> func, string fp1, string fp2)
        {
            var val = double.NaN;
            try
            {
                var sv1 = RDKitSparseVector.FromJsonToSIV(fp1);
                var sv2 = RDKitSparseVector.FromJsonToSIV(fp2);

                val = RDKFuncs.TanimotoSimilaritySIVi64(sv1, sv2);
            }
            catch (Exception)
            {
            }

            return val;
        }

        public static ExplicitBitVect ToBitVectorOrNull(string fp)
        {
            var array = new List<int>();
            for (int i = 0; i < fp.Length; i++)
            {
                switch (fp[i])
                {
                    case '0':
                        break;
                    case '1':
                        array.Add(i);
                        break;
                    default:
                        return null;
                }
            }
            var o = new ExplicitBitVect((uint)fp.Length);
            foreach (var i in array)
            {
                o.setBit((uint)i);
            }
            return o;
        }
    }
}
