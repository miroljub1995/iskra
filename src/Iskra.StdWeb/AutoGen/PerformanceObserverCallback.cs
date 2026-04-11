// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public delegate void PerformanceObserverCallbackManaged(global::Iskra.StdWeb.PerformanceObserverEntryList entries, global::Iskra.StdWeb.PerformanceObserver observer, global::Iskra.StdWeb.PerformanceObserverCallbackOptions options);

public partial class PerformanceObserverCallback: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public PerformanceObserverCallback(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public PerformanceObserverCallback(PerformanceObserverCallbackManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator PerformanceObserverCallback(PerformanceObserverCallbackManaged input)
    {
        return new global::Iskra.StdWeb.PerformanceObserverCallback(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.StdWeb.PerformanceObserverCallbackManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.StdWeb.PerformanceObserverCallbackManaged;
        if (managed is not null)
        {
            return true;
        }

        if (!allowConversion)
        {
            return false;
        }

        managed = (entries, observer, options) =>
        {
            int ___argsArrayLength_3 = 3;

            using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

            // Argument 1
            global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_4;
            ___marshalledValue_4 = entries.JSObject;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

            // Argument 2
            global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_5;
            ___marshalledValue_5 = observer.JSObject;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 1, ___marshalledValue_5);

            // Argument 3
            global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_6;
            ___marshalledValue_6 = options.JSObject;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 2, ___marshalledValue_6);

            global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyVoidFunction(JSObject, null, ___argsArray_0.JSObject);
        };
        return true;
    }
    
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(PerformanceObserverCallbackManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (__args_297) =>
        {
            using (__args_297)
            {
                // Argument 1
                global::Iskra.StdWeb.PerformanceObserverEntryList __arg_299;
                global::System.Runtime.InteropServices.JavaScript.JSObject __res_300 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(__args_297, 0);
                __arg_299 = global::Iskra.JSCore.JSObjectProxyFactory.GetProxy<global::Iskra.StdWeb.PerformanceObserverEntryList>(__res_300);

                // Argument 2
                global::Iskra.StdWeb.PerformanceObserver __arg_301;
                global::System.Runtime.InteropServices.JavaScript.JSObject __res_302 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(__args_297, 1);
                __arg_301 = global::Iskra.JSCore.JSObjectProxyFactory.GetProxy<global::Iskra.StdWeb.PerformanceObserver>(__res_302);

                // Argument 3
                global::Iskra.StdWeb.PerformanceObserverCallbackOptions __arg_303;
                global::System.Runtime.InteropServices.JavaScript.JSObject __res_304 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(__args_297, 2);
                __arg_303 = new global::Iskra.StdWeb.PerformanceObserverCallbackOptions(__res_304);

                input(__arg_299, __arg_301, __arg_303);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject __funcObj_305 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(__funcObj_305, input);

        return __funcObj_305;
    }
}

#nullable disable