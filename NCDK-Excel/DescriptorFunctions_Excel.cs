
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
        public static double NCDK_AcidicGroupCount(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_AcidicGroupCount",
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
        public static double NCDK_APol(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_APol",
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
        public static double NCDK_AromaticAtomsCount(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_AromaticAtomsCount",
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
        public static double NCDK_AromaticBondsCount(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_AromaticBondsCount",
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
        public static double NCDK_AtomCount(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_AtomCount",
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
        public static string NCDK_AutocorrelationCharge(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_AutocorrelationCharge",
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
        public static string NCDK_AutocorrelationMass(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_AutocorrelationMass",
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
        public static string NCDK_AutocorrelationPolarizability(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_AutocorrelationPolarizability",
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
        public static double NCDK_BasicGroupCount(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_BasicGroupCount",
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
        [ExcelFunction(Description = "Returns the number of bonds.")]
        public static double NCDK_BondCount(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_BondCount",
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
        public static double NCDK_BPol(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_BPol",
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
        public static string NCDK_CarbonTypes(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_CarbonTypes",
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
        public static string NCDK_ChiChain(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_ChiChain",
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
        public static string NCDK_ChiCluster(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_ChiCluster",
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
        public static string NCDK_ChiPathCluster(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_ChiPathCluster",
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
        public static string NCDK_ChiPath(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_ChiPath",
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
        public static string NCDK_CPSA(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_CPSA",
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
        public static double NCDK_EccentricConnectivityIndex(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_EccentricConnectivityIndex",
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
        public static double NCDK_FMF(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_FMF",
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
        public static double NCDK_FractionalPSA(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_FractionalPSA",
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
        public static double NCDK_FractionalCSP3(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_FractionalCSP3",
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
        public static double NCDK_FSP3(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_FSP3",
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
        public static double NCDK_FragmentComplexity(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_FragmentComplexity",
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
        public static string NCDK_GravitationalIndex(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_GravitationalIndex",
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
        public static double NCDK_HBondAcceptorCount(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_HBondAcceptorCount",
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
        public static double NCDK_HBondDonorCount(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_HBondDonorCount",
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
        public static double NCDK_HybridizationRatio(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_HybridizationRatio",
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
        public static double NCDK_JPlogP(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_JPlogP",
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
        public static string NCDK_KappaShapeIndices(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_KappaShapeIndices",
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
        public static string NCDK_KierHallSmarts(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_KierHallSmarts",
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
        public static double NCDK_LargestChain(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_LargestChain",
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
        public static double NCDK_LargestPiSystem(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_LargestPiSystem",
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
        public static string NCDK_LengthOverBreadth(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_LengthOverBreadth",
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
        public static double NCDK_LongestAliphaticChain(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_LongestAliphaticChain",
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
        public static double NCDK_MannholdLogP(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_MannholdLogP",
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
        public static string NCDK_MDE(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_MDE",
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
        public static string NCDK_MomentOfInertia(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_MomentOfInertia",
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
        public static double NCDK_PetitjeanNumber(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_PetitjeanNumber",
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
        public static string NCDK_PetitjeanShapeIndex(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_PetitjeanShapeIndex",
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
        public static double NCDK_RotatableBondsCount(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_RotatableBondsCount",
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
        public static double NCDK_RuleOfFive(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_RuleOfFive",
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
        public static string NCDK_SmallRing(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_SmallRing",
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
        public static double NCDK_TPSA(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_TPSA",
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
        public static double NCDK_VABC(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_VABC",
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
        public static double NCDK_VAdjMa(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_VAdjMa",
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
        public static string NCDK_WeightedPath(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_WeightedPath",
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
        public static string NCDK_WHIM(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_WHIM",
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
        public static string NCDK_WienerNumbers(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_WienerNumbers",
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
        public static double NCDK_XLogP(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_XLogP",
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
        public static double NCDK_ZagrebIndex(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "NCDK_ZagrebIndex",
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
        public static string NCDK_ECFP0(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_ECFP0",
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
        public static string NCDK_ECFP2(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_ECFP2",
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
        public static string NCDK_ECFP4(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_ECFP4",
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
        public static string NCDK_ECFP6(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_ECFP6",
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
        public static string NCDK_FCFP0(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_FCFP0",
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
        public static string NCDK_FCFP2(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_FCFP2",
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
        public static string NCDK_FCFP4(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_FCFP4",
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
        public static string NCDK_FCFP6(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_FCFP6",
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
        public static string NCDK_AtomPairs2DFingerprint(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_AtomPairs2DFingerprint",
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
        public static string NCDK_EStateFingerprint(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_EStateFingerprint",
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
        public static string NCDK_ExtendedFingerprint(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_ExtendedFingerprint",
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
        public static string NCDK_CDKFingerprint(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_CDKFingerprint",
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
        public static string NCDK_KlekotaRothFingerprint(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_KlekotaRothFingerprint",
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
        public static string NCDK_LingoFingerprint(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_LingoFingerprint",
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
        public static string NCDK_MACCSFingerprint(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_MACCSFingerprint",
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
        public static string NCDK_ShortestPathFingerprint(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_ShortestPathFingerprint",
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
        public static string NCDK_SubstructureFingerprint(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_SubstructureFingerprint",
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
        public static string NCDK_PubchemFingerprint(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "NCDK_PubchemFingerprint",
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
        public static string RDKit_MACCSKeysFingerprint(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "RDKit_MACCSKeysFingerprint",
                mol =>
                {
                string nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.GetMACCSKeysFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the Layered fingerprint.")]
        public static string RDKit_LayeredFingerprint(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "RDKit_LayeredFingerprint",
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
        public static string RDKit_HashedAtomPairFingerprint(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "RDKit_HashedAtomPairFingerprint",
                mol =>
                {
                string nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.GetHashedAtomPairFingerprintAsBitVect(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the HashedTopologicalTorsion fingerprint.")]
        public static string RDKit_HashedTopologicalTorsionFingerprint(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "RDKit_HashedTopologicalTorsionFingerprint",
                mol =>
                {
                string nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.GetHashedTopologicalTorsionFingerprintAsBitVect(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the Pattern fingerprint.")]
        public static string RDKit_PatternFingerprint(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "RDKit_PatternFingerprint",
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
        public static string RDKit_RDKFingerprint(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "RDKit_RDKFingerprint",
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
        public static string RDKit_AtomPairFingerprint(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "RDKit_AtomPairFingerprint",
                mol =>
                {
                string nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.GetAtomPairFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns the TopologicalTorsion fingerprint.")]
        public static string RDKit_TopologicalTorsionFingerprint(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "RDKit_TopologicalTorsionFingerprint",
                mol =>
                {
                string nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.GetTopologicalTorsionFingerprint(mol);
                    nReturnValue = ToExcelString(result);
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns Chi0n.")]
        public static double RDKit_Chi0n(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_Chi0n",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcChi0n(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Chi0v.")]
        public static double RDKit_Chi0v(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_Chi0v",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcChi0v(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Chi1n.")]
        public static double RDKit_Chi1n(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_Chi1n",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcChi1n(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Chi1v.")]
        public static double RDKit_Chi1v(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_Chi1v",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcChi1v(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Chi2n.")]
        public static double RDKit_Chi2n(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_Chi2n",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcChi2n(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Chi2v.")]
        public static double RDKit_Chi2v(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_Chi2v",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcChi2v(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Chi3n.")]
        public static double RDKit_Chi3n(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_Chi3n",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcChi3n(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Chi3v.")]
        public static double RDKit_Chi3v(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_Chi3v",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcChi3v(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Chi4n.")]
        public static double RDKit_Chi4n(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_Chi4n",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcChi4n(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Chi4v.")]
        public static double RDKit_Chi4v(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_Chi4v",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcChi4v(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Kappa1.")]
        public static double RDKit_Kappa1(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_Kappa1",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcKappa1(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Kappa2.")]
        public static double RDKit_Kappa2(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_Kappa2",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcKappa2(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns Kappa3.")]
        public static double RDKit_Kappa3(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_Kappa3",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcKappa3(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns LabuteASA.")]
        public static double RDKit_LabuteASA(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_LabuteASA",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcLabuteASA(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns MolLogP.")]
        public static double RDKit_MolLogP(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_MolLogP",
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
        public static double RDKit_MolMR(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_MolMR",
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
        public static double RDKit_ExactMolWt(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_ExactMolWt",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcExactMolWt(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns FractionCSP3.")]
        public static double RDKit_FractionCSP3(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_FractionCSP3",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcFractionCSP3(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns HallKierAlpha.")]
        public static double RDKit_HallKierAlpha(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_HallKierAlpha",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcHallKierAlpha(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of LipinskiHBA.")]
        public static double RDKit_NumLipinskiHBA(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_NumLipinskiHBA",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcNumLipinskiHBA(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of LipinskiHBD.")]
        public static double RDKit_NumLipinskiHBD(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_NumLipinskiHBD",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcNumLipinskiHBD(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of AliphaticCarbocycles.")]
        public static double RDKit_NumAliphaticCarbocycles(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_NumAliphaticCarbocycles",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcNumAliphaticCarbocycles(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of AliphaticHeterocycles.")]
        public static double RDKit_NumAliphaticHeterocycles(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_NumAliphaticHeterocycles",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcNumAliphaticHeterocycles(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of AliphaticRings.")]
        public static double RDKit_NumAliphaticRings(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_NumAliphaticRings",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcNumAliphaticRings(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of AmideBonds.")]
        public static double RDKit_NumAmideBonds(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_NumAmideBonds",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcNumAmideBonds(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of AromaticCarbocycles.")]
        public static double RDKit_NumAromaticCarbocycles(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_NumAromaticCarbocycles",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcNumAromaticCarbocycles(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of AromaticHeterocycles.")]
        public static double RDKit_NumAromaticHeterocycles(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_NumAromaticHeterocycles",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcNumAromaticHeterocycles(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of AromaticRings.")]
        public static double RDKit_NumAromaticRings(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_NumAromaticRings",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcNumAromaticRings(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of BridgeheadAtoms.")]
        public static double RDKit_NumBridgeheadAtoms(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_NumBridgeheadAtoms",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcNumBridgeheadAtoms(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of HBA.")]
        public static double RDKit_NumHBA(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_NumHBA",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcNumHBA(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of HBD.")]
        public static double RDKit_NumHBD(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_NumHBD",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcNumHBD(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns TPSA.")]
        public static double RDKit_TPSA(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_TPSA",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcTPSA(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of RotatableBonds.")]
        public static double RDKit_NumRotatableBonds(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_NumRotatableBonds",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcNumRotatableBonds(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of Heteroatoms.")]
        public static double RDKit_NumHeteroatoms(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_NumHeteroatoms",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcNumHeteroatoms(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of Heterocycles.")]
        public static double RDKit_NumHeterocycles(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_NumHeterocycles",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcNumHeterocycles(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of Rings.")]
        public static double RDKit_NumRings(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_NumRings",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcNumRings(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of SaturatedCarbocycles.")]
        public static double RDKit_NumSaturatedCarbocycles(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_NumSaturatedCarbocycles",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcNumSaturatedCarbocycles(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of SaturatedHeterocycles.")]
        public static double RDKit_NumSaturatedHeterocycles(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_NumSaturatedHeterocycles",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcNumSaturatedHeterocycles(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of SaturatedRings.")]
        public static double RDKit_NumSaturatedRings(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_NumSaturatedRings",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcNumSaturatedRings(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of SpiroAtoms.")]
        public static double RDKit_NumSpiroAtoms(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_NumSpiroAtoms",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcNumSpiroAtoms(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of malCharge.")]
        public static double RDKit_FormalCharge(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_FormalCharge",
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
        public static double RDKit_NumAtomStereoCenters(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_NumAtomStereoCenters",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcNumAtomStereoCenters(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns the number of UnspecifiedAtomStereoCenters.")]
        public static double RDKit_NumUnspecifiedAtomStereoCenters(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_NumUnspecifiedAtomStereoCenters",
                mol =>
                {
                double? nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcNumUnspecifiedAtomStereoCenters(mol);
                    nReturnValue = result;
                }

                return (double)nReturnValue;
                });
            return (double)ret;
        }
        [ExcelFunction(Description = "Returns MolFormula.")]
        public static string RDKit_MolFormula(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "RDKit_MolFormula",
                mol =>
                {
                string nReturnValue = null;
                
                if (nReturnValue == null)
                {
                    var result = RDKit.Chem.CalcMolFormula(mol);
                    nReturnValue = result;
                }

                return (string)nReturnValue;
                });
            return (string)ret;
        }
        [ExcelFunction(Description = "Returns CXSmiles.")]
        public static string RDKit_CXSmiles(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "RDKit_CXSmiles",
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
        public static string RDKit_InchiKey(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "RDKit_InchiKey",
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
        public static string RDKit_MolBlock(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "RDKit_MolBlock",
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
        public static string RDKit_PDBBlock(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "RDKit_PDBBlock",
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
        public static string RDKit_TPLBlock(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "RDKit_TPLBlock",
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
        public static string RDKit_XYZBlock(string molecule_ident)
        {
            var ret = Caching<string>.Calculate(molecule_ident, "RDKit_XYZBlock",
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
        [ExcelFunction(Description = "Returns QED.")]
        public static double RDKit_QED(string molecule_ident)
        {
            var ret = Caching<double?>.Calculate(molecule_ident, "RDKit_QED",
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
    }
}

