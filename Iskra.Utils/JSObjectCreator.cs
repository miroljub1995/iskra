using System.Runtime.InteropServices.JavaScript;

namespace Iskra.Utils;

public static partial class JSObjectCreator
{
    [JSImport("globalThis.Object")]
    public static partial JSObject Create();
}