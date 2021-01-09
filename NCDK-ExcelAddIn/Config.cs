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

using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace NCDK_ExcelAddIn
{
    public static class Utils
    {
        public static string Canonicalize(string value, IEnumerable<string> values, string defaultValue = null)
        {
            value = value ?? defaultValue;
            var lowerValue = value.ToLowerInvariant();
            return values.FirstOrDefault(n => n.ToLowerInvariant() == lowerValue) ?? defaultValue;
        }
    }

    public static class Toolkits
    {
        public const string RDKit = "RDKit";
        public const string NCDK = "NCDK";
        private static readonly string[] _all = new string[] { RDKit, NCDK };
        public static string Default => Config.Default.Toolkit;
        public static IEnumerable<string> Enumerate() => _all;
        public static string Canonicalize(string value) => Utils.Canonicalize(value, _all, Default);
    }

    public static class ImageTypes
    {
        private static readonly string[] _all = { "SVG", "PNG", };
        public static string Default => Config.Default.ImageType;
        public static IEnumerable<string> Enumerate() => _all;
        public static string Canonicalize(string value) => Utils.Canonicalize(value, _all, Default);
    }

    public static class ColoringStyles
    {
        private const string _on_ = " on ";

        public const string Color = "Color";
        public const string Black = "Black";
        public const string White = "White";
        public const string Transparent = "Transparent";

        private static readonly string[] _all = new string[] {
            $"{Color} on {White}",
            $"{Color} on {Transparent}",
            $"{Black} on {White}",
            $"{Black} on {Transparent}",
            $"{White} on {Black}",
            $"Cob on {Transparent}",
            $"Nob on {Black}",
        };

        public static string Default => Config.Default.ColoringStyle;
        public static IEnumerable<string> Enumerate() => _all;
        public static string Canonicalize(string value) => Utils.Canonicalize(value, _all, Default);

        public static string ForegroundColorer(string value)
        {
            var i = value.IndexOf(_on_);
            if (i < 0)
                return ForegroundColorer(Default);
            return value.Substring(0, i);
        }

        public static string BackgroundColor(string value)
        {
            var i = value.IndexOf(_on_);
            if (i < 0)
                return BackgroundColor(Default);
            return value.Substring(i + _on_.Length);
        }
    }

    public static class Config
    {
        public static class Default
        {
            private static string GetDefaultValue(string key)
                => (string)Properties.Settings.Default.Properties[key].DefaultValue;

            public static string Toolkit => GetDefaultValue("Toolkit");
            public static string ColoringStyle => GetDefaultValue("ColoringStyle");
            public static string ImageType => GetDefaultValue("ImageType");
            public static int MinimumEdgePixels => int.Parse(GetDefaultValue("MinimumEdgePixels"), NumberStyles.Number, CultureInfo.InvariantCulture);
        }

        public static string Toolkit
        {
            get => Properties.Settings.Default.Toolkit;
            set => Properties.Settings.Default.Toolkit = Toolkits.Canonicalize(value);
        }

        public static string ColoringStyle
        {
            get => Properties.Settings.Default.ColoringStyle;
            set => Properties.Settings.Default.ColoringStyle = ColoringStyles.Canonicalize(value);
        }

        public static string ImageType
        {
            get => Properties.Settings.Default.ImageType.ToLowerInvariant();
            set => Properties.Settings.Default.ImageType = value.ToLowerInvariant();
        }

        public static int MinimumEdgePixels
        {
            get => Properties.Settings.Default.MinimumEdgePixels;
            set => Properties.Settings.Default.MinimumEdgePixels = value;
        }
    }
}
