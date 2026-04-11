// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public delegate void ResizeObserverCallbackManaged(global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.ResizeObserverEntry, global::Iskra.StdWeb.PropertyAccessor> entries, global::Iskra.StdWeb.ResizeObserver observer);

public partial class ResizeObserverCallback: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ResizeObserverCallback(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ResizeObserverCallback(ResizeObserverCallbackManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator ResizeObserverCallback(ResizeObserverCallbackManaged input)
    {
        return new global::Iskra.StdWeb.ResizeObserverCallback(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.StdWeb.ResizeObserverCallbackManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.StdWeb.ResizeObserverCallbackManaged;
        if (managed is not null)
        {
            return true;
        }

        if (!allowConversion)
        {
            return false;
        }

        managed = (entries, observer) =>
        {
            int ___argsArrayLength_3 = 2;

            using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

            // Argument 1
            global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_4 = entries.JSObject;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 0, ___propObject_4);

            // Argument 2
            global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_5;
            ___marshalledValue_5 = observer.JSObject;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 1, ___marshalledValue_5);

            global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyVoidFunction(JSObject, null, ___argsArray_0.JSObject);
        };
        return true;
    }
    
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(ResizeObserverCallbackManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (__args_375) =>
        {
            using (__args_375)
            {
                // Argument 1
                global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.ResizeObserverEntry, global::Iskra.StdWeb.PropertyAccessor> __arg_377;
                global::System.Runtime.InteropServices.JavaScript.JSObject __propObject_378;
                __propObject_378 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(__args_375, 0);
                __arg_377 = new global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.ResizeObserverEntry, global::Iskra.StdWeb.PropertyAccessor>(__propObject_378);

                // Argument 2
                global::Iskra.StdWeb.ResizeObserver __arg_379;
                global::System.Runtime.InteropServices.JavaScript.JSObject __res_380 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(__args_375, 1);
                __arg_379 = global::Iskra.JSCore.JSObjectProxyFactory.GetProxy<global::Iskra.StdWeb.ResizeObserver>(__res_380);

                input(__arg_377, __arg_379);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject __funcObj_381 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(__funcObj_381, input);

        return __funcObj_381;
    }
}

#nullable disable