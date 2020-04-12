using ExcelDna.Integration;
using GraphMolWrap;
using RDKit;
using System;
using System.Collections.Concurrent;

namespace NCDKExcel
{
    public static partial class RDKit_ReactionFunctions
    {
        static readonly ConcurrentDictionary<Tuple<string, string>, bool?> HasSubstructMatchCache =
            new ConcurrentDictionary<Tuple<string, string>, bool?>();

        [ExcelFunction()]
        public static object RDKit_HasSubstructMatch(string smiles, string smarts)
        {
            var key = new Tuple<string, string>(smiles, smarts);
            var result = HasSubstructMatchCache.GetOrAdd(key, tuple =>
            {
                string a_smiles = tuple.Item1;
                string a_smarts = tuple.Item2;

                var mol = RDKitMol.Parse(a_smiles);
                if (mol == null)
                    return null;

                var query = RDKitSmarts.Parse(a_smarts);
                if (query == null)
                    return null;

                return mol.HasSubstructMatch(query);
            });

            return result;
        }
    }

    class RDKitSmarts
    {
        static readonly ConcurrentDictionary<string, ROMol> SmartsCache = new ConcurrentDictionary<string, ROMol>();
        static readonly ROMol nullSmarts = new ROMol();

        public static ROMol Parse(string smarts)
        {
            if (smarts == null)
                throw new ArgumentNullException(nameof(smarts));

            var pattern = SmartsCache.GetOrAdd(smarts, a_smarts =>
            {
                ROMol query = Chem.MolFromSmarts(a_smarts);

                if (query == null)
                    return nullSmarts;

                query.setProp("source", "SMARTS");
                return query;
            });
       
            if (object.ReferenceEquals(pattern, nullSmarts))
                return null;

            return pattern;
        }
    }
}
