using ExcelDna.Integration;
using uk.ac.cam.ch.wwmm.opsin;

namespace NCDKExcel
{
    public static class OpsinFunctions
    {
        internal static NameToStructure NameToStructureConverter { get; } = NameToStructure.getInstance();

        [ExcelFunction(Description = "Accepts IUPAC name and returns the SMILES.")]
        public static string OPSIN_ParseToSmiles(string name)
        {
            var smiles = NameToStructureConverter.parseToSmiles(name);
            return smiles;
        }
    }
}
