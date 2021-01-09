// MIT License
// 
// Copyright (c) 2021 Kazuya Ujihara
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using GraphMolWrap;
using System;
using System.IO;

namespace RDKit
{
    public static partial class Chem
    {
        public static partial class Draw
        {
            /// <summary>
            /// Generates a drawing of a molecule and writes it to a file.
            /// </summary>
            /// <seealso href="https://github.com/rdkit/rdkit/blob/1649029367a8e517cf1913a5b80b91813874e002/rdkit/Chem/Draw/__init__.py#L265-L300"/>
            public static void MolToFile(
                RWMol mol, 
                string filename, 
                Tuple<int, int> size = null, 
                bool kekulize = true, 
                bool wedgeBonds = true, 
                string imageType = null, 
                bool fitImage = false, 
                string legend = "",
                Int_Vect highlight_atoms = null, 
                Int_Vect highlight_bonds = null,
                DrawColour highlightColor = null
            )
            {
                if (size == null)
                    size = new Tuple<int, int>(300, 300);

                if (imageType == null)
                    imageType = Path.GetExtension(filename).Substring(1).ToLowerInvariant();

                try
                {
                    RdMolDraw2D.PrepareMolForDrawing(mol, kekulize: kekulize, wedgeBonds: wedgeBonds);
                }
                catch (Exception)
                {
                    RdMolDraw2D.PrepareMolForDrawing(mol, kekulize: false, wedgeBonds: wedgeBonds);
                }
                MolDraw2D d2d;
                switch (imageType)
                {
                    case "png":
                        d2d = new MolDraw2DCairo(size.Item1, size.Item2);
                        break;
                    case "svg":
                        d2d = new MolDraw2DSVG(size.Item1, size.Item2);
                        break;
                    default:
                        throw new Exception($"{imageType} is not supported.");
                }
                if (highlightColor != null)
                    d2d.DrawOptions().highlightColour = highlightColor;
                d2d.DrawOptions().prepareMolsBeforeDrawing = false;
                d2d.DrawMolecule(mol, legend, highlight_atoms, highlight_bonds);
                d2d.FinishDrawing();
                switch (d2d)
                {
                    case MolDraw2DCairo d:
                        d.WriteDrawingText(filename);
                        break;
                    case MolDraw2DSVG d:
                        using (var w = new StreamWriter(filename))
                        {
                            w.Write(d.GetDrawingText());
                        }
                        break;
                }
            }
        }
    }
}
