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

using NCDK;
using NCDK.Depict;
using NCDK.Renderers.Colors;
using NCDK.Smiles;
using NCDK.Tools.Manipulator;
using System;
using System.IO;
using System.Text.RegularExpressions;
using static NCDK_ExcelAddIn.ChemStuff;
using WPF = System.Windows;

namespace NCDK_ExcelAddIn
{
    public class NCDKPictureGenerator : IPictureGegerator
    {
        private static IAtomColorer ToAtomColorer(string colorerName)
        {
            switch (colorerName.ToLowerInvariant())
            {
                case "color":
                    return new CDK2DAtomColors();
                case "black":
                    return new UniColor(WPF::Media.Colors.Black);
                case "white":
                    return new UniColor(WPF::Media.Colors.White);
                case "cob":
                    return new CobColorer();
                case "nob":
                    return new NobColorer();
                default:
                    return new CDK2DAtomColors();
            }
        }

        private static WPF::Media.Color ToWPFColor(string colorName)
        {
            try
            {
                return (WPF::Media.Color)WPF::Media.ColorConverter.ConvertFromString(colorName);
            }
            catch (FormatException)
            {
                return WPF::Media.Colors.White;
            }
        }

        private DepictionGenerator pictureGenerator = null;
        public DepictionGenerator PictureGenerator
        {
            get
            {
                if (pictureGenerator == null)
                {
                    pictureGenerator = new DepictionGenerator
                    {
                        AtomColorer = ToAtomColorer(ColoringStyles.ForegroundColorer(Config.ColoringStyle)),
                        BackgroundColor = ToWPFColor(ColoringStyles.BackgroundColor(Config.ColoringStyle)),
                    };
                }
                return pictureGenerator;
            }
        }

        private static readonly SmilesParser parser = new SmilesParser(CDK.Builder);

        public NCDKPictureGenerator()
        {
        }

        private static readonly Regex _rect_transparent = new Regex(@"\<rect\s+x=\'0\'\s+y\=\'0\'.*\brgba\(\s*\d+\s*,\s*\d*\,\s*\d+\s*\,\s*(?<a>[0](\.0*)?)\s*\).*\/\>", RegexOptions.Compiled);

        public void Generate(string text, string filename)
        {
            Depiction depict;
            if (IsReactionSmilees(text))
            {
                var rxn = parser.ParseReactionSmiles(text);
                ReactionManipulator.PerceiveDativeBonds(rxn);
                ReactionManipulator.PerceiveRadicals(rxn);
                depict = PictureGenerator.Depict(rxn);
            }
            else
            {
                var mol = NCDKExcel.Utility.Parse(text);
                AtomContainerManipulator.PerceiveDativeBonds(mol);
                AtomContainerManipulator.PerceiveRadicals(mol);
                depict = PictureGenerator.Depict(mol);
            }
            depict.WriteTo(filename);

            if (!filename.EndsWith(".svg"))
                return;

            string svg;
            using (var r = new StreamReader(filename))
            {
                svg = r.ReadToEnd();
            }
            using (var r = new StreamWriter(filename))
            {
                r.Write(_rect_transparent.Replace(svg, ""));
            }
        }

        public TempFile GenerateTemporary(string text)
        {
            var tempFile = new TempFile("." + Config.ImageType);
            Generate(text, tempFile.FileName);

            return tempFile;
        }

        public TempFile GenerateTemporary(string text, double width, double height)
        {
            // ignore width and height
            return GenerateTemporary(text);
        }
    }

    public class CobColorer : IAtomColorer
    {
        private static readonly CDK2DAtomColors colors = new CDK2DAtomColors();

        public WPF::Media.Color GetAtomColor(IAtom atom)
        {
            var res = colors.GetAtomColor(atom);
            if (res.Equals(WPF::Media.Colors.Black))
                return WPF::Media.Colors.White;
            else
                return res;
        }

        public WPF::Media.Color GetAtomColor(IAtom atom, WPF::Media.Color color)
        {
            var res = colors.GetAtomColor(atom, color);
            if (res.Equals(WPF::Media.Colors.Black))
                return WPF::Media.Colors.White;
            else
                return res;
        }
    }

    public class NobColorer : IAtomColorer
    {
        private static readonly CDK2DAtomColors colors = new CDK2DAtomColors();
        private static readonly WPF::Media.Color Neon = WPF::Media.Color.FromRgb(0x00, 0xFF, 0x0E);

        public WPF::Media.Color GetAtomColor(IAtom atom)
        {
            var res = colors.GetAtomColor(atom);
            if (res.Equals(WPF::Media.Colors.Black))
                return Neon;
            else
                return res;
        }

        public WPF::Media.Color GetAtomColor(IAtom atom, WPF::Media.Color color)
        {
            var res = colors.GetAtomColor(atom, color);
            if (res.Equals(WPF::Media.Colors.Black))
                return Neon;
            else
                return res;
        }
    }
}
