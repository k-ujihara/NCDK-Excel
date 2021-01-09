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

using System;
using System.Globalization;
using System.Windows.Forms;

namespace NCDK_ExcelAddIn
{
    public partial class PrefDialog : Form
    {
        public PrefDialog()
        {
            InitializeComponent();
        }

        private void PrefDialog_Load(object sender, EventArgs e)
        {
            foreach (var v in Toolkits.Enumerate())
                this.comboToolkit.Items.Add(v);
            foreach (var v in ColoringStyles.Enumerate())
                this.comboColoring.Items.Add(v);
            foreach (var v in ImageTypes.Enumerate())
                this.comboImageType.Items.Add(v);
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            this.comboColoring.Text = Config.Default.Toolkit;
            this.comboColoring.Text = Config.Default.ColoringStyle;
            this.comboImageType.Text = Config.Default.ImageType.ToUpperInvariant();
            this.textMinimumPixels.Text = Config.Default.MinimumEdgePixels.ToString(CultureInfo.InvariantCulture);
        }
    }
}
