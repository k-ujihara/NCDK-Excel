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
        public static partial class Draw
        {
            public static class RdMolDraw2D
            {
                public static void PrepareAndDrawMolecule(MolDraw2D drawer, ROMol mol, string legend = "", Int_Vect highlight_atoms = null, Int_Vect highlight_bonds = null)
                {
                    RDKFuncs.prepareAndDrawMolecule(drawer, mol, legend, highlight_atoms, highlight_bonds);
                }

                public static void PrepareMolForDrawing(RWMol mol, bool kekulize = true, bool addChiralHs = true, bool wedgeBonds = true, bool forceCoords = false)
                {
                    RDKFuncs.prepareMolForDrawing(mol, kekulize, addChiralHs, wedgeBonds, forceCoords);
                }
            }
        }
    }
}
