using System.Runtime.InteropServices;

namespace NCDKExcel
{
    public static class ComUtility
    {
        public static void ReleaseComObject(object o)
        {
            if (o != null)
                Marshal.ReleaseComObject(o);
        }
    }
}
