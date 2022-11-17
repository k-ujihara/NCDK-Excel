using GraphMolWrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDKit
{
    public static partial class Chem
    {
        //
        // rdDistGeom 
        //

        public static int EmbedMolecule(
            ROMol mol, 
            int maxIterations = 0, 
            int seed = -1, 
            bool clearConfs =true, 
            bool useRandomCoords=false, 
            double boxSizeMult=2.0, 
            bool randNegEig= true, 
            int numZeroFail=1
            //Int_Point3D_Map coordMap, 
            //double forceTol = 0.001, 
            //bool ignoreSmoothingFailures=false, 
            //bool enforceChirality=true, 
            //bool useExpTorsionAnglePrefs=true, 
            //bool useBasicKnowledge=false
        )
        {
            return DistanceGeom.EmbedMolecule(
                mol,
                (uint)maxIterations,
                seed, clearConfs,
                useRandomCoords, 
                boxSizeMult, 
                randNegEig, 
                (uint)numZeroFail);
        }
    }
}
