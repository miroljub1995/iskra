using System.Runtime.InteropServices.JavaScript;

namespace Iskra.StdWeb.Utils;

public static class JSConstructor
{
    public static JSObject New(string constructorProperty, object?[] args)
    {
        var constructor = JSHost.GlobalThis.GetPropertyAsJSObject(constructorProperty);
        if (constructor is null)
        {
            throw new Exception($"Can't get constructor for property {constructorProperty}.");
        }

        return Reflect.Construct(constructor, args);
    }
}