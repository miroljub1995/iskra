using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSFunction;

public static partial class JSObjectCreator
{
    [JSImport("globalThis.Object")]
    public static partial JSObject Create();
}