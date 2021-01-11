using ExcelDna.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCDKExcel
{
    public static class ExcelDnaUtility
    {
        public static bool ToBoolean(object value, bool defaultValue = false)
        {
            if (value is ExcelMissing)
                return defaultValue;
            return Convert.ToBoolean(value);
        }

        public static int ToInt32(object value, int defaultValue = 0)
        {
            if (value is ExcelMissing)
                return defaultValue;
            return Convert.ToInt32(value);
        }

        public static double ToDouble(object value, double defaultValue = 0)
        {
            if (value is ExcelMissing)
                return defaultValue;
            return Convert.ToDouble(value);
        }
    }
}
