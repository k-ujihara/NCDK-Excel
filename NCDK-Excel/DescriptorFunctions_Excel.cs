
/*
 * MIT License
 * 
 * Copyright (c) 2018-2020 Kazuya Ujihara
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
using static NCDKExcel.Utility;

namespace NCDKExcel
{
    public static partial class DescriptorFunctions
    {
        [ExcelFunction(Description = "Returns the number of acidic groups.")]
        public static double NCDK_AcidicGroupCount(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_AcidicGroupCount",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.AcidicGroupCountDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Sum of the atomic polarizabilities.")]
        public static double NCDK_APol(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_APol",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.APolDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of aromatic atoms.")]
        public static double NCDK_AromaticAtomsCount(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_AromaticAtomsCount",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.AromaticAtomsCountDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of aromatic bonds.")]
        public static double NCDK_AromaticBondsCount(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_AromaticBondsCount",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.AromaticBondsCountDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of atoms.")]
        public static double NCDK_AtomCount(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_AtomCount",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.AtomCountDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the autocorrelation charge.")]
        public static string NCDK_AutocorrelationCharge(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_AutocorrelationCharge",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.AutocorrelationDescriptorCharge();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the autocorrelation mass.")]
        public static string NCDK_AutocorrelationMass(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_AutocorrelationMass",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.AutocorrelationDescriptorMass();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the autocorrelation polarizability.")]
        public static string NCDK_AutocorrelationPolarizability(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_AutocorrelationPolarizability",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.AutocorrelationDescriptorPolarizability();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the number of basic groups.")]
        public static double NCDK_BasicGroupCount(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_BasicGroupCount",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.BasicGroupCountDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the BCUT.")]
        public static string NCDK_BCUT(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_BCUT",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.BCUTDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the number of bonds.")]
        public static double NCDK_BondCount(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_BondCount",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.BondCountDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Sum of the absolute value of the difference between atomic polarizabilities of all bonded atoms in the molecule.")]
        public static double NCDK_BPol(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_BPol",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.BPolDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the topological descriptor characterizing the carbon connectivity.")]
        public static string NCDK_CarbonTypes(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_CarbonTypes",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.CarbonTypesDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Evaluates chi chain descriptors.")]
        public static string NCDK_ChiChain(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_ChiChain",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.ChiChainDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Evaluates chi cluster descriptors.")]
        public static string NCDK_ChiCluster(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_ChiCluster",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.ChiClusterDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Evaluates chi path cluster descriptors.")]
        public static string NCDK_ChiPathCluster(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_ChiPathCluster",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.ChiPathClusterDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Evaluates chi path descriptors.")]
        public static string NCDK_ChiPath(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_ChiPath",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.ChiPathDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the CPSA.")]
        public static string NCDK_CPSA(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_CPSA",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.CPSADescriptor();
                
                if (!GeometryUtil.Has3DCoordinates(mol))
                {
                    nReturnValue = null ;
                }
                else
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the eccentric connectivity index.")]
        public static double NCDK_EccentricConnectivityIndex(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_EccentricConnectivityIndex",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.EccentricConnectivityIndexDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the FMF.")]
        public static double NCDK_FMF(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_FMF",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.FMFDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the fractional PSA.")]
        public static double NCDK_FractionalPSA(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_FractionalPSA",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.FractionalPSADescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the fractional CSP.")]
        public static double NCDK_FractionalCSP3(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_FractionalCSP3",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.FractionalCSP3Descriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the fractional CSP3.")]
        public static double NCDK_FSP3(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_FSP3",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.FractionalCSP3Descriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the fragment complexity.")]
        public static double NCDK_FragmentComplexity(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_FragmentComplexity",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.FragmentComplexityDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the gravitational index.")]
        public static string NCDK_GravitationalIndex(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_GravitationalIndex",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.GravitationalIndexDescriptor();
                
                if (!GeometryUtil.Has3DCoordinates(mol))
                {
                    nReturnValue = null ;
                }
                else
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the hbond acceptor count.")]
        public static double NCDK_HBondAcceptorCount(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_HBondAcceptorCount",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.HBondAcceptorCountDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the hbond donor count.")]
        public static double NCDK_HBondDonorCount(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_HBondDonorCount",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.HBondDonorCountDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the hybridization ratio.")]
        public static double NCDK_HybridizationRatio(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_HybridizationRatio",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.HybridizationRatioDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the JPLogP.")]
        public static double NCDK_JPlogP(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_JPlogP",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.JPlogPDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the kappa shape indices.")]
        public static string NCDK_KappaShapeIndices(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_KappaShapeIndices",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.KappaShapeIndicesDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the kier hall SMARTS.")]
        public static string NCDK_KierHallSmarts(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_KierHallSmarts",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.KierHallSmartsDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the largest chain.")]
        public static double NCDK_LargestChain(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_LargestChain",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.LargestChainDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the largest pi system.")]
        public static double NCDK_LargestPiSystem(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_LargestPiSystem",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.LargestPiSystemDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the length over breadth.")]
        public static string NCDK_LengthOverBreadth(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_LengthOverBreadth",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.LengthOverBreadthDescriptor();
                NCDK.Config.BODRIsotopeFactory.Instance.ConfigureAtoms(mol);
                if (!GeometryUtil.Has3DCoordinates(mol))
                {
                    nReturnValue = null ;
                }
                else
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the longest aliphatic chain.")]
        public static double NCDK_LongestAliphaticChain(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_LongestAliphaticChain",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.LongestAliphaticChainDescriptor(checkRingSystem: true);
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the mannhold log.")]
        public static double NCDK_MannholdLogP(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_MannholdLogP",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.MannholdLogPDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the MDE.")]
        public static string NCDK_MDE(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_MDE",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.MDEDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the moment of inertia.")]
        public static string NCDK_MomentOfInertia(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_MomentOfInertia",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.MomentOfInertiaDescriptor();
                
                if (!GeometryUtil.Has3DCoordinates(mol))
                {
                    nReturnValue = null ;
                }
                else
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the petitjean number.")]
        public static double NCDK_PetitjeanNumber(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_PetitjeanNumber",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.PetitjeanNumberDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the petitjean shape index.")]
        public static string NCDK_PetitjeanShapeIndex(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_PetitjeanShapeIndex",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.PetitjeanShapeIndexDescriptor();
                
                if (!GeometryUtil.Has3DCoordinates(mol))
                {
                    nReturnValue = null ;
                }
                else
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the rotatable bonds count.")]
        public static double NCDK_RotatableBondsCount(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_RotatableBondsCount",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.RotatableBondsCountDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the Rule of Five.")]
        public static double NCDK_RuleOfFive(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_RuleOfFive",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.RuleOfFiveDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the small ring.")]
        public static string NCDK_SmallRing(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_SmallRing",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.SmallRingDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the TPSA.")]
        public static double NCDK_TPSA(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_TPSA",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.TPSADescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the VABC.")]
        public static double NCDK_VABC(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_VABC",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.VABCDescriptor();
                AtomContainerManipulator.PercieveAtomTypesAndConfigureAtoms(mol); AddImplicitHydrogens(mol);
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the vadj ma.")]
        public static double NCDK_VAdjMa(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_VAdjMa",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.VAdjMaDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the weighted path.")]
        public static string NCDK_WeightedPath(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_WeightedPath",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.WeightedPathDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the WHIM.")]
        public static string NCDK_WHIM(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_WHIM",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.WHIMDescriptor();
                
                if (!GeometryUtil.Has3DCoordinates(mol))
                {
                    nReturnValue = null ;
                }
                else
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the wiener numbers.")]
        public static string NCDK_WienerNumbers(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_WienerNumbers",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.WienerNumbersDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the xlog PDe.")]
        public static double NCDK_XLogP(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_XLogP",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.XLogPDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the zagreb index.")]
        public static double NCDK_ZagrebIndex(string text)
        {
            var ret = Caching<double?>.Calculate(text, "NCDK_ZagrebIndex",
                mol =>
                {
                double? nReturnValue = null;
                var descriptor = new NCDK.QSAR.Descriptors.Moleculars.ZagrebIndexDescriptor();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.Calculate(mol);
                    nReturnValue = result.Value;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns ECFP0.")]
        public static string NCDK_ECFP0(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_ECFP0",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.Fingerprints.CircularFingerprinter(NCDK.Fingerprints.CircularFingerprinterClass.ECFP0);
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns ECFP2.")]
        public static string NCDK_ECFP2(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_ECFP2",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.Fingerprints.CircularFingerprinter(NCDK.Fingerprints.CircularFingerprinterClass.ECFP2);
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns ECFP4.")]
        public static string NCDK_ECFP4(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_ECFP4",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.Fingerprints.CircularFingerprinter(NCDK.Fingerprints.CircularFingerprinterClass.ECFP4);
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns ECFP6.")]
        public static string NCDK_ECFP6(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_ECFP6",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.Fingerprints.CircularFingerprinter(NCDK.Fingerprints.CircularFingerprinterClass.ECFP6);
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns FCFP0.")]
        public static string NCDK_FCFP0(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_FCFP0",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.Fingerprints.CircularFingerprinter(NCDK.Fingerprints.CircularFingerprinterClass.FCFP0);
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns FCFP2.")]
        public static string NCDK_FCFP2(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_FCFP2",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.Fingerprints.CircularFingerprinter(NCDK.Fingerprints.CircularFingerprinterClass.FCFP2);
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns FCFP4.")]
        public static string NCDK_FCFP4(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_FCFP4",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.Fingerprints.CircularFingerprinter(NCDK.Fingerprints.CircularFingerprinterClass.FCFP4);
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns FCFP6.")]
        public static string NCDK_FCFP6(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_FCFP6",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.Fingerprints.CircularFingerprinter(NCDK.Fingerprints.CircularFingerprinterClass.FCFP6);
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the AtomPairs2D fingerprint.")]
        public static string NCDK_AtomPairs2DFingerprint(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_AtomPairs2DFingerprint",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.Fingerprints.AtomPairs2DFingerprinter();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the EState fingerprint.")]
        public static string NCDK_EStateFingerprint(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_EStateFingerprint",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.Fingerprints.EStateFingerprinter();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the Extended fingerprint.")]
        public static string NCDK_ExtendedFingerprint(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_ExtendedFingerprint",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.Fingerprints.ExtendedFingerprinter();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the CDK fingerprint.")]
        public static string NCDK_CDKFingerprint(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_CDKFingerprint",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.Fingerprints.Fingerprinter();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the KlekotaRoth fingerprint.")]
        public static string NCDK_KlekotaRothFingerprint(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_KlekotaRothFingerprint",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.Fingerprints.KlekotaRothFingerprinter();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the Lingo fingerprint.")]
        public static string NCDK_LingoFingerprint(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_LingoFingerprint",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.Fingerprints.LingoFingerprinter();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the MACCS fingerprint.")]
        public static string NCDK_MACCSFingerprint(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_MACCSFingerprint",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.Fingerprints.MACCSFingerprinter();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the ShortestPath.")]
        public static string NCDK_ShortestPathFingerprint(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_ShortestPathFingerprint",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.Fingerprints.ShortestPathFingerprinter();
                AtomContainerManipulator.PercieveAtomTypesAndConfigureAtoms(mol);
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the Substructure.")]
        public static string NCDK_SubstructureFingerprint(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_SubstructureFingerprint",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.Fingerprints.SubstructureFingerprinter();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the Pubchem fingerprint.")]
        public static string NCDK_PubchemFingerprint(string text)
        {
            var ret = Caching<string>.Calculate(text, "NCDK_PubchemFingerprint",
                mol =>
                {
                string nReturnValue = null;
                var descriptor = new NCDK.Fingerprints.PubchemFingerprinter();
                
                if (nReturnValue == null)
                {
                    var result = descriptor.GetBitFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the MACCSKeys fingerprint.")]
        public static string RDKit_MACCSKeysFingerprint(string text)
        {
            var ret = Caching<string>.Calculate(text, "RDKit_MACCSKeysFingerprint",
                mol =>
                {
                string nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.GetMACCSKeysFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the Layered fingerprint.")]
        public static string RDKit_LayeredFingerprint(string text)
        {
            var ret = Caching<string>.Calculate(text, "RDKit_LayeredFingerprint",
                mol =>
                {
                string nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.LayeredFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the HashedAtomPair fingerprint.")]
        public static string RDKit_HashedAtomPairFingerprint(string text)
        {
            var ret = Caching<string>.Calculate(text, "RDKit_HashedAtomPairFingerprint",
                mol =>
                {
                string nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.GetHashedAtomPairFingerprintAsBitVect(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the HashedTopologicalTorsion fingerprint.")]
        public static string RDKit_HashedTopologicalTorsionFingerprint(string text)
        {
            var ret = Caching<string>.Calculate(text, "RDKit_HashedTopologicalTorsionFingerprint",
                mol =>
                {
                string nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.GetHashedTopologicalTorsionFingerprintAsBitVect(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the Pattern fingerprint.")]
        public static string RDKit_PatternFingerprint(string text)
        {
            var ret = Caching<string>.Calculate(text, "RDKit_PatternFingerprint",
                mol =>
                {
                string nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.PatternFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the RDK fingerprint.")]
        public static string RDKit_RDKFingerprint(string text)
        {
            var ret = Caching<string>.Calculate(text, "RDKit_RDKFingerprint",
                mol =>
                {
                string nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.RDKFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the AtomPair fingerprint.")]
        public static string RDKit_AtomPairFingerprint(string text)
        {
            var ret = Caching<string>.Calculate(text, "RDKit_AtomPairFingerprint",
                mol =>
                {
                string nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.GetAtomPairFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the TopologicalTorsion fingerprint.")]
        public static string RDKit_TopologicalTorsionFingerprint(string text)
        {
            var ret = Caching<string>.Calculate(text, "RDKit_TopologicalTorsionFingerprint",
                mol =>
                {
                string nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.GetTopologicalTorsionFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns Chi0n.")]
        public static double RDKit_Chi0n(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_Chi0n",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcChi0n(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Chi0v.")]
        public static double RDKit_Chi0v(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_Chi0v",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcChi0v(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Chi1n.")]
        public static double RDKit_Chi1n(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_Chi1n",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcChi1n(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Chi1v.")]
        public static double RDKit_Chi1v(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_Chi1v",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcChi1v(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Chi2n.")]
        public static double RDKit_Chi2n(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_Chi2n",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcChi2n(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Chi2v.")]
        public static double RDKit_Chi2v(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_Chi2v",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcChi2v(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Chi3n.")]
        public static double RDKit_Chi3n(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_Chi3n",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcChi3n(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Chi3v.")]
        public static double RDKit_Chi3v(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_Chi3v",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcChi3v(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Chi4n.")]
        public static double RDKit_Chi4n(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_Chi4n",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcChi4n(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Chi4v.")]
        public static double RDKit_Chi4v(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_Chi4v",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcChi4v(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Kappa1.")]
        public static double RDKit_Kappa1(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_Kappa1",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcKappa1(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Kappa2.")]
        public static double RDKit_Kappa2(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_Kappa2",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcKappa2(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Kappa3.")]
        public static double RDKit_Kappa3(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_Kappa3",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcKappa3(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns LabuteASA.")]
        public static double RDKit_LabuteASA(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_LabuteASA",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcLabuteASA(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns MolLogP.")]
        public static double RDKit_MolLogP(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_MolLogP",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.Crippen.MolLogP(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns MolMR.")]
        public static double RDKit_MolMR(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_MolMR",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.Crippen.MolMR(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns ExactMolWt.")]
        public static double RDKit_ExactMolWt(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_ExactMolWt",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcExactMolWt(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns FractionCSP3.")]
        public static double RDKit_FractionCSP3(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_FractionCSP3",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcFractionCSP3(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns HallKierAlpha.")]
        public static double RDKit_HallKierAlpha(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_HallKierAlpha",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcHallKierAlpha(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of LipinskiHBA.")]
        public static double RDKit_NumLipinskiHBA(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumLipinskiHBA",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcNumLipinskiHBA(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of LipinskiHBD.")]
        public static double RDKit_NumLipinskiHBD(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumLipinskiHBD",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcNumLipinskiHBD(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of AliphaticCarbocycles.")]
        public static double RDKit_NumAliphaticCarbocycles(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumAliphaticCarbocycles",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcNumAliphaticCarbocycles(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of AliphaticHeterocycles.")]
        public static double RDKit_NumAliphaticHeterocycles(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumAliphaticHeterocycles",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcNumAliphaticHeterocycles(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of AliphaticRings.")]
        public static double RDKit_NumAliphaticRings(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumAliphaticRings",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcNumAliphaticRings(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of AmideBonds.")]
        public static double RDKit_NumAmideBonds(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumAmideBonds",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcNumAmideBonds(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of AromaticCarbocycles.")]
        public static double RDKit_NumAromaticCarbocycles(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumAromaticCarbocycles",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcNumAromaticCarbocycles(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of AromaticHeterocycles.")]
        public static double RDKit_NumAromaticHeterocycles(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumAromaticHeterocycles",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcNumAromaticHeterocycles(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of AromaticRings.")]
        public static double RDKit_NumAromaticRings(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumAromaticRings",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcNumAromaticRings(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of BridgeheadAtoms.")]
        public static double RDKit_NumBridgeheadAtoms(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumBridgeheadAtoms",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcNumBridgeheadAtoms(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of HBA.")]
        public static double RDKit_NumHBA(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumHBA",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcNumHBA(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of HBD.")]
        public static double RDKit_NumHBD(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumHBD",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcNumHBD(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns TPSA.")]
        public static double RDKit_TPSA(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_TPSA",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcTPSA(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of RotatableBonds.")]
        public static double RDKit_NumRotatableBonds(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumRotatableBonds",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcNumRotatableBonds(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of Heteroatoms.")]
        public static double RDKit_NumHeteroatoms(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumHeteroatoms",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcNumHeteroatoms(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of Heterocycles.")]
        public static double RDKit_NumHeterocycles(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumHeterocycles",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcNumHeterocycles(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of Rings.")]
        public static double RDKit_NumRings(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumRings",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcNumRings(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of SaturatedCarbocycles.")]
        public static double RDKit_NumSaturatedCarbocycles(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumSaturatedCarbocycles",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcNumSaturatedCarbocycles(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of SaturatedHeterocycles.")]
        public static double RDKit_NumSaturatedHeterocycles(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumSaturatedHeterocycles",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcNumSaturatedHeterocycles(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of SaturatedRings.")]
        public static double RDKit_NumSaturatedRings(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumSaturatedRings",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcNumSaturatedRings(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of SpiroAtoms.")]
        public static double RDKit_NumSpiroAtoms(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumSpiroAtoms",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcNumSpiroAtoms(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of malCharge.")]
        public static double RDKit_FormalCharge(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_FormalCharge",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.GetFormalCharge(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of AtomStereoCenters.")]
        public static double RDKit_NumAtomStereoCenters(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumAtomStereoCenters",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcNumAtomStereoCenters(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of UnspecifiedAtomStereoCenters.")]
        public static double RDKit_NumUnspecifiedAtomStereoCenters(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumUnspecifiedAtomStereoCenters",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcNumUnspecifiedAtomStereoCenters(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns MolFormula.")]
        public static string RDKit_MolFormula(string text)
        {
            var ret = Caching<string>.Calculate(text, "RDKit_MolFormula",
                mol =>
                {
                string nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Descriptors.CalcMolFormula(mol);
                    nReturnValue = result;
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns CXSmiles.")]
        public static string RDKit_CXSmiles(string text)
        {
            var ret = Caching<string>.Calculate(text, "RDKit_CXSmiles",
                mol =>
                {
                string nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.MolToCXSmiles(mol);
                    nReturnValue = result;
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns InchiKey.")]
        public static string RDKit_InchiKey(string text)
        {
            var ret = Caching<string>.Calculate(text, "RDKit_InchiKey",
                mol =>
                {
                string nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.MolToInchiKey(mol);
                    nReturnValue = result;
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns MolBlock.")]
        public static string RDKit_MolBlock(string text)
        {
            var ret = Caching<string>.Calculate(text, "RDKit_MolBlock",
                mol =>
                {
                string nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.MolToMolBlock(mol);
                    nReturnValue = result;
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns PDBBlock.")]
        public static string RDKit_PDBBlock(string text)
        {
            var ret = Caching<string>.Calculate(text, "RDKit_PDBBlock",
                mol =>
                {
                string nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.MolToPDBBlock(mol);
                    nReturnValue = result;
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns TPLBlock.")]
        public static string RDKit_TPLBlock(string text)
        {
            var ret = Caching<string>.Calculate(text, "RDKit_TPLBlock",
                mol =>
                {
                string nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.MolToTPLBlock(mol);
                    nReturnValue = result;
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns XYZBlock.")]
        public static string RDKit_XYZBlock(string text)
        {
            var ret = Caching<string>.Calculate(text, "RDKit_XYZBlock",
                mol =>
                {
                string nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.MolToXYZBlock(mol);
                    nReturnValue = result;
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns Smarts.")]
        public static string RDKit_Smarts(string text)
        {
            var ret = Caching<string>.Calculate(text, "RDKit_Smarts",
                mol =>
                {
                string nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.MolToSmarts(mol);
                    nReturnValue = result;
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns Smiles.")]
        public static string RDKit_Smiles(string text)
        {
            var ret = Caching<string>.Calculate(text, "RDKit_Smiles",
                mol =>
                {
                string nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.MolToSmiles(mol);
                    nReturnValue = result;
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns QED.")]
        public static double RDKit_QED(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_QED",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.QED.Calculate(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of HeavyAtoms.")]
        public static double RDKit_NumHeavyAtoms(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumHeavyAtoms",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.GetNumHeavyAtoms(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of Atoms.")]
        public static double RDKit_NumAtoms(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumAtoms",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.GetNumAtoms(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of Bonds.")]
        public static double RDKit_NumBonds(string text)
        {
            var ret = Caching<double?>.Calculate(text, "RDKit_NumBonds",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.GetNumBonds(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
    }
}

