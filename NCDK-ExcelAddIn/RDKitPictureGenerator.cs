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
using RDKit;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using static RDKit.Chem.Draw;

namespace NCDK_ExcelAddIn
{
    public class RDKitPictureGenerator : IPictureGegerator
    {
        public TempFile GenerateTemporary(string text)
        {
            return GenerateTemporary(text, Config.MinimumEdgePixels, Config.MinimumEdgePixels);
        }

        private static readonly Regex re_rect_tag = new Regex(@"\<rect .*\bstyle\=\'opacity\:[01](\.\d*)?\b.*\<\/rect\>", RegexOptions.Compiled);

        private static bool ImageBGIsTransparent()
        {
            return ColoringStyles.BackgroundColor(Config.ColoringStyle) == ColoringStyles.Transparent;
        }

        public TempFile GenerateTemporary(string text, double width, double height)
        {
            var min = Math.Min(width, height);
            if (min < Config.MinimumEdgePixels)
            {
                double scale = Config.MinimumEdgePixels / min;
                width *= scale;
                height *= scale;
            }

            RWMol mol = null;
            mol = Chem.MolFromSmiles(text);
            if (mol == null)
                mol = Chem.MolFromSmarts(text);
            if (mol == null)
                mol = Chem.MolFromMolBlock(text);
            if (mol == null)
                mol = Chem.MolFromInchi(text);
            if (mol == null)
                return null;

            var tempFile = new TempFile("." + Config.ImageType);
            var filename = tempFile.FileName;
            MolToFile(mol, filename, new Tuple<int, int>((int)width, (int)height));

            if (filename.EndsWith(".svg"))
            {
                string svg;
                using (var r = new StreamReader(filename))
                {
                    svg = r.ReadToEnd();
                }
                if (ImageBGIsTransparent())
                {
                    using (var r = new StreamWriter(filename))
                    {
                        r.Write(re_rect_tag.Replace(svg, ""));
                    }
                }
            }

            return tempFile;
        }
    }
}
