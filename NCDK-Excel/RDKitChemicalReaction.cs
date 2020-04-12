using ExcelDna.Integration;
using GraphMolWrap;
using RDKit;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace NCDKExcel
{
    public static partial class RDKit_ReactionFunctions
    {
        static readonly ConcurrentDictionary<Tuple<string, string>, string> RunReactionCache = 
            new ConcurrentDictionary<Tuple<string, string>, string>();

        [ExcelFunction()]
        public static string RDKit_RunReactionSmiles(string rxnIdent, string reactantsIdent)
        {
            var key = new Tuple<string, string>(rxnIdent, reactantsIdent);
            if (!RunReactionCache.TryGetValue(key, out string result))
            {
                try
                {
                    var rxn = RDKitChemicalReaction.Parse(rxnIdent);
                    var mols = new List<ROMol>();
                    foreach (var reactant_smiles in reactantsIdent.Split('.'))
                    {
                        var mol = RDKitUtility.Parse(reactant_smiles);
                        if (mol == null)
                        {
                            goto L_Found;
                        }
                        mols.Add(mol);
                    }
                    var reactants = new ROMol_Vect(mols);
                    var products_candidate_list = rxn.runReactants(reactants);
                    if (products_candidate_list.Count > 0)
                        result = string.Join(".", products_candidate_list.First().Select(mol => Chem.MolToSmiles(mol)));
                }
                catch (Exception)
                {
                }
            L_Found:
                if (result == null)
                    result = "#VALUE!";
                RunReactionCache[key] = result;
            }
            return result;
        }
    }

    public static class RDKitChemicalReaction
    {
        static readonly ConcurrentDictionary<string, ChemicalReaction> ReactionCache = new ConcurrentDictionary<string, ChemicalReaction>();
        static readonly ChemicalReaction nullRxn = new ChemicalReaction();

        public static ChemicalReaction Parse(string rxnSmarts)
        {
            if (rxnSmarts == null)
                throw new ArgumentNullException(nameof(rxnSmarts));

            string notationType = null;
            if (!ReactionCache.TryGetValue(rxnSmarts, out ChemicalReaction rxn))
            {
                rxn = ChemicalReaction.ReactionFromSmarts(rxnSmarts);
                if (rxn != null)
                {
                    notationType = "Reaction SMILES";
                    goto L_Found;
                }

            L_Found:
                if (rxn == null)
                    rxn = nullRxn;
                else
                {
                    if (notationType != null)
                        rxn.setProp("source", notationType);
                }

                ReactionCache[rxnSmarts] = rxn;
            }
            if (object.ReferenceEquals(rxn, nullRxn))
                return null;

            return rxn;
        }
    }
}
