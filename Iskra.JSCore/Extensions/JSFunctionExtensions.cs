using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore.Extensions;

public static partial class JSFunctionExtensions
{
    public static JSObject WrapAsVoidFunction(this Action<JSObject> function) =>
        WrapAsVoidFunction_Bridge(function);

    [JSImport("wrapAsVoidFunction", "iskra")]
    private static partial JSObject WrapAsVoidFunction_Bridge(
        [JSMarshalAs<JSType.Function<JSType.Object>>]
        Action<JSObject> function
    );
}