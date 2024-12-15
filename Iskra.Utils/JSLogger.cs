using System.Runtime.InteropServices.JavaScript;

namespace Iskra.Utils;

/// <summary>
/// TODO: Should be replaced once console is mapped
/// </summary>
public partial class JSLogger
{
    [JSImport("globalThis.console.log")]
    public static partial JSObject Log(
        [JSMarshalAs<JSType.Array<JSType.Any>>]
        object?[] args
    );
}