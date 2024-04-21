using System.Runtime.InteropServices.JavaScript;

namespace Iskra.Utils;

public partial class JSFunctionConstructor
{
    [JSImport("globalThis.Function")]
    public static partial JSObject Function(string code);

    [JSImport("globalThis.Function")]
    public static partial JSObject Function(string arg1Name, string code);

    [JSImport("globalThis.Function")]
    public static partial JSObject Function(string arg1Name, string arg2Name, string code);

    [JSImport("globalThis.Function")]
    public static partial JSObject Function(string arg1Name, string arg2Name, string arg3Name, string code);

    [JSImport("globalThis.Function")]
    public static partial JSObject Function(string arg1Name, string arg2Name, string arg3Name, string arg4Name,
        string code);
}