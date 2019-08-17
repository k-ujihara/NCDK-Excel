﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace NCDK_ExcelAddIn
{
    public static class ExcelTool
    {

        /// <summary>
        /// Do <paramref name="action"/> on each cell in <paramref name="range"/>.
        /// </summary>
        /// <param name="range">The range contains cells to action.</param>
        /// <param name="action">The action to do on each cell.</param>
        public static void EnumerateCells(Excel.Range range, Action<Excel.Range> action)
        {
            // Enumerate non-empty cells by Excel.Range.Find function.
            // However the first found cell is not range.Cells[1] when cell is not empty.
            // So range[1] is treated individually.

            var cellsCount = range.Count;

            Tuple<int, int> firstCellInfo, firstFoundCellInfo;
            {
                Excel.Range firstCell = range.Cells[1];
                firstCellInfo = new Tuple<int, int>(firstCell.Column, firstCell.Row);
                if (!string.IsNullOrEmpty(firstCell.Text))
                    action(firstCell);
            }

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