using System.Runtime.InteropServices.JavaScript;
using Iskra.Utils;

namespace Iskra.StdWeb;

public static partial class Reflect
{
    public static partial void Apply(JSObject target, JSObject? thisArgument, object?[] argumentList)
    {
        var unwrappedArgs = argumentList
            .Select(x => x is JSObjectWrapper wrapper ? wrapper.JSObject : x)
            .ToArray();

        _ApplyAsVoid(target, thisArgument, unwrappedArgs);
    }

    public static partial object Apply<TRes>(JSObject target, JSObject? thisArgument, object?[] argumentList)
    {
        var unwrappedArgs = argumentList
            .Select(x => x is JSObjectWrapper wrapper ? wrapper.JSObject : x)
            .ToArray();

        if (typeof(TRes) == typeof(JSObject))
        {
            var res = _ApplyAsJSObject(target, thisArgument, unwrappedArgs);
            return res;
        }

        if (typeof(TRes) == typeof(JSObjectWrapper))
        {
            var obj = _ApplyAsJSObject(target, thisArgument, unwrappedArgs);
            var res = WrapperFactory.GetWrapper(obj);
            return res;
        }

        throw new NotSupportedException($"Return type {typeof(TRes)} not supported.");
    }

    [JSImport("globalThis.Reflect.apply")]
    private static partial void _ApplyAsVoid(JSObject target, JSObject? thisArgument, object?[] argumentList);

    [JSImport("globalThis.Reflect.apply")]
    private static partial JSObject _ApplyAsJSObject(JSObject target, JSObject? thisArgument, object?[] argumentList);
}