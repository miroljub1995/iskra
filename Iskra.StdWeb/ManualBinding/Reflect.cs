using System.Runtime.InteropServices.JavaScript;

namespace Iskra.StdWeb;

public static partial class Reflect
{
    public static partial void Apply(JSObject target, JSObject? thisArgument, object?[] argumentList)
    {
        var unwrappedArgs = argumentList
            .Select(x => x is OneOf oneOf ? oneOf.Value : x)
            .Select(x => x is JSObjectWrapper wrapper ? wrapper.JSObject : x)
            .ToArray();

        _ApplyAsVoid(target, thisArgument, unwrappedArgs);
    }

    public static partial object Apply<TRes>(JSObject target, JSObject? thisArgument, object?[] argumentList)
    {
        var unwrappedArgs = argumentList
            .Select(x => x is OneOf oneOf ? oneOf.Value : x)
            .Select(x => x is JSObjectWrapper wrapper ? wrapper.JSObject : x)
            .ToArray();

        if (typeof(TRes) == typeof(JSObject))
        {
            var res = _ApplyAsJSObject(target, thisArgument, unwrappedArgs);
            return res;
        }

        if (typeof(TRes) == typeof(JSObjectWrapper) || typeof(TRes).IsSubclassOf(typeof(JSObjectWrapper)))
        {
            var obj = _ApplyAsJSObject(target, thisArgument, unwrappedArgs);

            return WrapperFactory.GetWrapper<TRes>(obj);
        }

        if (typeof(TRes) == typeof(bool))
        {
            var res = _ApplyAsBool(target, thisArgument, unwrappedArgs);
            return res;
        }

        throw new NotSupportedException($"Return type {typeof(TRes)} not supported.");
    }

    [JSImport("globalThis.Reflect.apply")]
    private static partial void _ApplyAsVoid(
        JSObject target,
        JSObject? thisArgument,
        [JSMarshalAs<JSType.Array<JSType.Any>>]
        object?[] argumentList
    );

    [JSImport("globalThis.Reflect.apply")]
    private static partial bool _ApplyAsBool(
        JSObject target,
        JSObject? thisArgument,
        [JSMarshalAs<JSType.Array<JSType.Any>>]
        object?[] argumentList
    );

    [JSImport("globalThis.Reflect.apply")]
    private static partial JSObject _ApplyAsJSObject(
        JSObject target,
        JSObject? thisArgument,
        [JSMarshalAs<JSType.Array<JSType.Any>>]
        object?[] argumentList
    );

    public static partial JSObject Construct(JSObject constructor, object?[] args)
    {
        var argsWithExtractedObjects = args
            .Select(x => x is JSObjectWrapper wrapper ? wrapper.JSObject : x)
            .ToArray();

        return _Construct(constructor, argsWithExtractedObjects);
    }

    public static partial JSObject Construct(JSObject constructor, object?[] args, JSObject newTarget)
    {
        var argsWithExtractedObjects = args
            .Select(x => x is JSObjectWrapper wrapper ? wrapper.JSObject : x)
            .ToArray();

        return _Construct(constructor, argsWithExtractedObjects);
    }

    [JSImport("globalThis.Reflect.construct")]
    private static partial JSObject _Construct(
        JSObject constructor,
        [JSMarshalAs<JSType.Array<JSType.Any>>]
        object?[] args
    );

    [JSImport("globalThis.Reflect.construct")]
    private static partial JSObject _Construct(
        JSObject constructor,
        [JSMarshalAs<JSType.Array<JSType.Any>>]
        object?[] args,
        JSObject newTarget
    );
}