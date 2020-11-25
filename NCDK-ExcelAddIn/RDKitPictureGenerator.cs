using GraphMolWrap;
using RDKit;
using System;
using System.IO;
using static RDKit.Chem.Draw;

namespace NCDK_ExcelAddIn
{
    public class RDKitPictureGenerator : IPictureGegerator
    {
        const double MinimumEdgeSize = 100;

        public TempFile GenerateTemporary(string text)
        {
            return GenerateTemporary(text, MinimumEdgeSize, MinimumEdgeSize);
        }

        public TempFile GenerateTemporary(string text, double width, double height)
        {
            var min = Math.Min(width, height);
            if (min < MinimumEdgeSize)
            {
                double scale = MinimumEdgeSize / min;
                width *= scale;
                height *= scale;
            }

            RWMol mol = null;
            mol = Chem.MolFromSmiles(text);
            if (mol == null)
                mol = Chem.MolFromSmarts(text);
            if (mol == null)
                return null;

            var view = new MolDraw2DSVG((int)width, (int)height);
            RdMolDraw2D.PrepareMolForDrawing(mol);
            view.DrawMolecule(mol);
            view.FinishDrawing();

            var tempFile = new TempFile(".svg");
            using (var w = new StreamWriter(tempFile.FileName))
            {
                w.Write(view.GetDrawingText());
            }

            return tempFile;
        }
    }
}
