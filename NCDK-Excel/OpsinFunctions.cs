using ExcelDna.Integration;
using Opsin;

namespace NCDKExcel
{
    public static class OpsinFunctions
    {
        internal static NameToStructure NameToStructureConverter { get; } = NameToStructure.Instance;
        //internal static NameToInchi nts = new NameToInchi();

        [ExcelFunction(Description = "Accepts IUPAC name and returns the SMILES.")]
        public static string OPSIN_ParseToSmiles(string name)
        {
            var smiles = NameToStructureConverter.ParseToSmiles(name);
            return smiles;
        }

        [ExcelFunction(Description = "Accepts IUPAC name and returns the CML.")]
        public static string OPSIN_ParseToCML(string name)
        {
            var smiles = NameToStructureConverter.ParseToCML(name);
            return smiles;
        }

        //[ExcelFunction(Description = "Accepts IUPAC name and returns the CML.")]
        //public static string OPSIN_ParseToInChI(string name)
        //{
        //    return nts.ParseToInchi(name);
        //}

        //[ExcelFunction(Description = "Accepts IUPAC name and returns the StdInChI.")]
        //public static string OPSIN_ParseToStdInChI(string name)
        //{
        //    return nts.ParseToStdInchi(name);
        //}

        //[ExcelFunction(Description = "Accepts IUPAC name and returns the StdInChIKey.")]
        //public static string OPSIN_ParseToStdInChIKey(string name)
        //{
        //    return nts.ParseToStdInchiKey(name);
        //}
    }
}
