using GraphMolWrap;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using RDKit;
using static RDKit.Chem;
using static RDKit.Chem.QED.QEDParameterTypes;

namespace NCDKExcel
{
    [TestClass()]
    public class QEDTests
    {
        [TestMethod()]
        public void NCI200Test()
        {
            foreach (var d in ReadTestData("NCI_200_qed.csv"))
            {
                Assert.AreEqual(d.Expected, QED.Calculate(d.Mol), 0.01, $"QED not equal to expected in line {d.LineNo}");
                // Check that adding hydrogens will not change the result
                // This is currently not the case. Hydrogens change the number of rotatable bonds and the
                // number of alerts.
                var mol = d.Mol.AddHs();
                Assert.AreEqual(d.Expected, QED.Calculate(mol), 0.01, $"QED not equal to expected in line {d.LineNo}");
            }
        }

        [TestCategory("Slow")]
        [TestMethod()]
        public void RegressionTest()
        {
            int failed = 0;
            foreach (var d in ReadTestData("Regression_qed.csv"))
            {
                if (Math.Abs(d.Expected - QED.Calculate(d.Mol)) > 0.01)
                {
                    failed++;
                    Trace.WriteLine($"QED not equal to expected in line {d.LineNo}");
                }
            }
            if (failed > 1)
                Assert.Fail();
        }

        [TestMethod()]
        public void PropertiesTest()
        {
            var m = Chem.MolFromSmiles("N=C(CCSCc1csc(N=C(N)N)n1)NS(N)(=O)=O");
            var p = QED.CreateProperties(m);
            Assert.AreEqual(337.045, p[MW], 0.01);
            Assert.AreEqual(-0.55833, p[ALOGP], 0.01);
            Assert.AreEqual(6, p[HBA]);
            Assert.AreEqual(5, p[HBD]);
            Assert.AreEqual(173.33, p[PSA], 0.01);
            Assert.AreEqual(7, p[ROTB]);
            Assert.AreEqual(1, p[AROM]);
            Assert.AreEqual(3, p[ALERTS]);

            p = QED.CreateProperties(m.AddHs());
            Assert.AreEqual(337.045, p[MW], 0.01);
            Assert.AreEqual(-0.55833, p[ALOGP], 0.01);
            Assert.AreEqual(6, p[HBA]);
            Assert.AreEqual(5, p[HBD]);
            Assert.AreEqual(173.33, p[PSA], 0.01);
            Assert.AreEqual(7, p[ROTB]);
            Assert.AreEqual(1, p[AROM]);
            Assert.AreEqual(3, p[ALERTS]);
        }

        [TestMethod]
        public void ExamplesTest()
        {
            // Paroxetine 0.935
            Assert.AreEqual(0.934, QED.Calculate(Chem.MolFromSmiles("c1cc2OCOc2cc1OCC1CNCCC1c1ccc(F)cc1")), 0.01);
            // Leflunomide 0.929
            Assert.AreEqual(0.911, QED.Calculate(Chem.MolFromSmiles("C1=NOC(C)=C1C(=O)Nc1ccc(cc1)C(F)(F)F")), 0.01);
            // Clomipramine 0.779
            Assert.AreEqual(0.818, QED.Calculate(Chem.MolFromSmiles("CN(C)CCCN1c2ccccc2CCc2ccc(Cl)cc21")), 0.01);
            // Tegaserod 0.213
            Assert.AreEqual(0.235, QED.Calculate(Chem.MolFromSmiles("CCCCCNC(=N)NN=CC1=CNc2ccc(CO)cc21")), 0.01);
        }

        class TestData
        {
            public int LineNo { get; set; }
            public string Smiles { get; set; }
            public ROMol Mol { get; set; }
            public double Expected { get; set; }
        }

        /// <summary>
        /// Read test data from file
        /// </summary>
        static IEnumerable<TestData> ReadTestData(string resourceName)
        {
            using (var r = new StreamReader(NCDK.ResourceLoader.GetAsStream($"NCDKExcel.test_data.QED.{resourceName}")))
            {
                int lineNo = 1;
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    if (!(line.Length == 0 || line[0] == '#'))
                    {
                        var temp = line.Trim().Split(',');
                        var smiles = temp[0];
                        var expected = double.Parse(temp[1]);
                        var mol = Chem.MolFromSmiles(smiles);
                        if (mol == null)
                            throw new AssertFailedException($"molecule construction failed on line {lineNo}");
                        yield return new TestData()
                        {
                            LineNo = lineNo,
                            Smiles = smiles,
                            Mol = mol,
                            Expected = expected,
                        };
                    }
                    lineNo++;
                }
                yield break;
            }
        }
    }
}
