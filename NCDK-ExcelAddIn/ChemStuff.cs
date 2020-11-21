using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCDK_ExcelAddIn
{
    public static class ChemStuff
    {
        public static bool IsReactionSmilees(string smiles)
        {
            return smiles.Split(' ')[0].Contains(">");
        }
    }
}
