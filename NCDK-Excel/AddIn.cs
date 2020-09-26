using ExcelDna.Integration;
using ExcelDna.IntelliSense;
public class AddIn : IExcelAddIn
{
    public void AutoOpen()
    {
        // Versions before v1.1.0 required only a call to Register() in the AutoOpen().
        // The name was changed (and made obsolete) to highlight the pair of function calls now required.
        IntelliSenseServer.Install();
    }

    public void AutoClose()
    {
        IntelliSenseServer.Uninstall();
    }
}
