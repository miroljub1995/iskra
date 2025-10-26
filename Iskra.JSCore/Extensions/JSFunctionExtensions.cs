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

    public static JSObject WrapAsNonVoidFunction(this Action<JSObject, JSObject> function) =>
        WrapAsNonVoidFunction_Bridge(function);

    [JSImport("wrapAsNonVoidFunction", "iskra")]
    private static partial JSObject WrapAsNonVoidFunction_Bridge(
        [JSMarshalAs<JSType.Function<JSType.Object, JSType.Object>>]
        Action<JSObject, JSObject> function
    );
}