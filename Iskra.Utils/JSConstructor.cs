using System.Runtime.InteropServices.JavaScript;

namespace Iskra.Utils;

/// <summary>
/// TODO: This should be replaced with Reflect.Construct once implemented. Make sure JSObjectWrapper objects are unwrapped.
/// </summary>
public static partial class JSConstructor
{
    public static JSObject New(string constructorProperty, object?[] args)
    {
        var constructor = JSHost.GlobalThis.GetPropertyAsJSObject(constructorProperty);
        JSLogger.Log(["New", constructor]);
        return JSHost.GlobalThis;
        if (constructor is null)
        {
            throw new Exception($"Can't get constructor for property {constructorProperty}.");
        }

        var argsWithExtractedObjects = args
            .Select(x => x is JSObjectWrapper wrapper ? wrapper.JSObject : x)
            .ToArray();

        return Construct(constructor, argsWithExtractedObjects);
    }

    [JSImport("globalThis.Reflect.construct")]
    private static partial JSObject Construct(
        JSObject constructor,
        [JSMarshalAs<JSType.Array<JSType.Any>>]
        object?[] args
    );
}