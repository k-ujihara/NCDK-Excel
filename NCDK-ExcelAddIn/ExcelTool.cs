// MIT License
// 
// Copyright (c) 2020 Kazuya Ujihara
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
using Excel = Microsoft.Office.Interop.Excel;

namespace NCDK_ExcelAddIn
{
    public static class ExcelTool
    {
        /// <summary>
        /// Do <paramref name="action"/> on each cell in <paramref name="range"/>.
        /// </summary>
        /// <param name="range">The range contains cells to action.</param>
        /// <param name="action">The action to do on each cell.</param>
        /// <param name="callback">Callback function before visiting each cell.</param>
        public static void EnumerateCells(Excel.Range range, Action<Excel.Range> action, Action callback = null)
        {
            // Enumerate non-empty cells by Excel.Range.Find function.
            // However the first found cell is not range.Cells[1] when cell is not empty.
            // So range[1] is treated individually.

            var cellsCount = range.Count;

            Tuple<int, int> firstCellInfo, firstFoundCellInfo;
            {
                var firstCell = (Excel.Range)range.Cells[1];
                firstCellInfo = new Tuple<int, int>(firstCell.Column, firstCell.Row);
                if (!string.IsNullOrEmpty((string)firstCell.Text))
                    action(firstCell);
            }

            // The Following is to avoid Excel's bug,
            // ie, range.Find("*") returns cell outside range when range.Count == 1.
            if (range.Count == 1)
                return;
            Excel.Range foundCell = range.Find("*");
            firstFoundCellInfo = new Tuple<int, int>(foundCell.Column, foundCell.Row);
            if (foundCell == null)
                return;
            if (firstFoundCellInfo.Equals(firstCellInfo))
                return;
            action(foundCell);

            Excel.Range newfoundCell = null;
            for (int i = 0; i < cellsCount; i++)
            {
                callback?.Invoke();

                newfoundCell = range.FindNext(foundCell);
                var cellInfo = new Tuple<int, int>(newfoundCell.Column, newfoundCell.Row);
                if (firstCellInfo.Equals(cellInfo)
                 || firstFoundCellInfo.Equals(cellInfo))
                    break;

                action(newfoundCell);
                foundCell = newfoundCell;
            }
        }
    }
}
