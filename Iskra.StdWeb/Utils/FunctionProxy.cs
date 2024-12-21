using System.Runtime.InteropServices.JavaScript;

namespace Iskra.StdWeb.Utils;

public static class FunctionProxy
{
    private const string FunctionName = "iskra_functionProxy";

    private static bool _isInitialized;

    public const string ImportFunctionName = $"globalThis.{FunctionName}";

    public static void EnsureInitialized()
    {
        if (_isInitialized)
        {
            return;
        }

        var proxyMethod = new Function("cb", "return ((...args) => cb(...args));");
        JSHost.GlobalThis.SetProperty(FunctionName, proxyMethod.JSObject);
        _isInitialized = true;
    }
}