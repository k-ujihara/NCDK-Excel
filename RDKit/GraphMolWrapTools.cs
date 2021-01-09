// MIT License
// 
// Copyright (c) 2020-2021 Kazuya Ujihara
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

namespace RDKit
{
    public static partial class GraphMolWrapTools
    {
        public static Match_Vect_Vect GetSubstructMatches(this ROMol mol, ROMol pattern)
        {
            return mol.getSubstructMatches(pattern);
        }

        public static bool HasSubstructMatch(this ROMol mol, ROMol query)
        {
            return mol.hasSubstructMatch(query);
        }

        public static ROMol DeleteSubstructs(this ROMol mol, ROMol query, bool replaceAll = false)
        {
            return mol.deleteSubstructs(query, replaceAll);
        }

        public static ROMol AddHs(this ROMol mol, bool explicitOnly = false, bool addCoords = false)
        {
            return mol.addHs(explicitOnly, addCoords);
        }

        public static ROMol RemoveHs(this ROMol mol, bool implicitOnly = false,
            bool updateExplicitCount = false, bool sanitize = true)
        {
            return mol.removeHs(implicitOnly, updateExplicitCount, sanitize);
        }

        public static int Count(this BitVect bv)
            => (int)bv.size();

        public static void ClearBits(this BitVect bv)
            => bv.clearBits();

        public static bool GetBit(this BitVect bv, int which)
            => bv.getBit((uint)which);

        public static bool SetBit(this BitVect bv, int which)
            => bv.setBit((uint)which);

        public static bool UnsetBit(this BitVect bv, int which)
            => bv.unsetBit((uint)which);

        public static int GetNumBits(this BitVect bv)
            => (int)bv.getNumBits();

        public static int GetNumOffBits(this BitVect bv)
            => (int)bv.getNumOffBits();

        public static int GetNumOnBits(this BitVect bv)
            => (int)bv.getNumOnBits();

        public static void GetOnBits(this BitVect bv, Int_Vect v)
            => bv.getOnBits(v);

        public static int Count(this SparseIntVect32 v)
            => (int)v.size();

        public static Match_Vect GetNonzero(this SparseIntVect32 v)
            => v.getNonzero();


        public static int Count(this SparseIntVectu32 v)
            => (int)v.size();

        public static UInt_Pair_Vect GetNonzero(this SparseIntVectu32 v)
            => v.getNonzero();

        public static int Count(this SparseIntVect64 v)
            => (int)v.size();

        public static Long_Pair_Vect GetNonzero(this SparseIntVect64 v)
            => v.getNonzero();

        //
        // MolDraw2D
        // 

        public static void ClearDrawing(this MolDraw2D view)
            => view.clearDrawing();

        public static MolDrawOptions DrawOptions(this MolDraw2D view)
            => view.drawOptions();

        public static DrawColour GetColor(this MolDraw2D view)
            => view.colour();

        public static void SetColor(this MolDraw2D view, DrawColour color)
            => view.setColour(color);

        public static UInt_Vect GetDash(this MolDraw2D view)
            => view.dash();

        public static void SetDash(this MolDraw2D view, UInt_Vect dash)
            => view.setDash(dash);

        public static double GetFontSize(this MolDraw2D view)
            => view.fontSize();

        public static void SetFontSize(this MolDraw2D view, double size)
            => view.setFontSize(size);

        public static double Scale(this MolDraw2D view)
            => view.scale();

        public static void SetScale(this MolDraw2D view, int width, int height, Point2D minv, Point2D maxv)
            => view.setScale(width, height, minv, maxv);

        public static double GetHeight(this MolDraw2D view)
            => view.height();

        public static double GetWidth(this MolDraw2D view)
            => view.width();

        public static int GetLineWidth(this MolDraw2D view)
            => view.lineWidth();

        public static void SetLineWidth(this MolDraw2D view, int size)
            => view.setLineWidth(size);

        public static double GetPanelHeight(this MolDraw2D view)
            => view.panelHeight();

        public static double GetPanelWidth(this MolDraw2D view)
            => view.panelWidth();

        public static void DrawMolecule(this MolDraw2D view, ROMol mol, string legend = "", Int_Vect highlight_atoms = null, Int_Vect highlight_bonds = null)
            => view.drawMolecule(mol, legend, highlight_atoms, highlight_bonds);

        public static void FinishDrawing(this MolDraw2D view)
        {
            switch (view)
            {
                case MolDraw2DSVG d2d:
                    d2d.finishDrawing();
                    break;
                case MolDraw2DCairo d2d:
                    d2d.finishDrawing();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        //
        // MolDraw2DCairo
        //

        public static void WriteDrawingText(this MolDraw2DCairo view, string fName)
        {
            view.writeDrawingText(fName);
        }

        //
        // MolDraw2DSVG
        //

        public static string GetDrawingText(this MolDraw2DSVG view)
        {
            return view.getDrawingText();
        }
    }
}
