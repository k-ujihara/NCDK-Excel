using GraphMolWrap;
using System.Collections.Generic;
using System;

namespace RDKit
{
    public static partial class Chem
    {
        //
        // rdDescriptor
        //

        public static int Compute2DCoords(
            ROMol mol,
            bool canonOrient = true,
            bool clearConfs = true,
            IReadOnlyDictionary<int, Point2D> coordMap = null,
            int nFlipsPerSample = 0,
            int nSamples = 0,
            int sampleSeed = 0,
            bool permuteDeg4Nodes = false)
        {
            // TODO: bondLength and forceRDKit option is not implemented.

            var cMap = new Int_Point2D_Map();
            var n_atoms = mol.GetNumAtoms();
            if (coordMap != null)
            {
                foreach (var id in coordMap.Keys)
                {
                    if (id >= n_atoms)
                        throw new ArgumentException("atom index out of range");
                    cMap[id] = coordMap[id];
                }
            }
            return (int)mol.compute2DCoords(cMap, canonOrient, clearConfs, (uint)nFlipsPerSample, (uint)nSamples, sampleSeed, permuteDeg4Nodes);
        }

        // TODO:
        // Compute2DCoordsMimicDistmat
        // GenerateDepictionMatching2DStructure
        // GenerateDepictionMatching3DStructure
    }
}
