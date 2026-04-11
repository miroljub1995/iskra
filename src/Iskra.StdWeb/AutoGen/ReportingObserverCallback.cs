// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public delegate void ReportingObserverCallbackManaged(global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.Report, global::Iskra.StdWeb.PropertyAccessor> reports, global::Iskra.StdWeb.ReportingObserver observer);

public partial class ReportingObserverCallback: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ReportingObserverCallback(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ReportingObserverCallback(ReportingObserverCallbackManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator ReportingObserverCallback(ReportingObserverCallbackManaged input)
    {
        return new global::Iskra.StdWeb.ReportingObserverCallback(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.StdWeb.ReportingObserverCallbackManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.StdWeb.ReportingObserverCallbackManaged;
        if (managed is not null)
        {
            return true;
        }

        if (!allowConversion)
        {
            return false;
        }

        managed = (reports, observer) =>
        {
            int ___argsArrayLength_3 = 2;

            using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

            // Argument 1
            global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_4 = reports.JSObject;
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
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(ReportingObserverCallbackManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (__args_269) =>
        {
            using (__args_269)
            {
                // Argument 1
                global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.Report, global::Iskra.StdWeb.PropertyAccessor> __arg_271;
                global::System.Runtime.InteropServices.JavaScript.JSObject __propObject_272;
                __propObject_272 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(__args_269, 0);
                __arg_271 = new global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.Report, global::Iskra.StdWeb.PropertyAccessor>(__propObject_272);

                // Argument 2
                global::Iskra.StdWeb.ReportingObserver __arg_273;
                global::System.Runtime.InteropServices.JavaScript.JSObject __res_274 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(__args_269, 1);
                __arg_273 = global::Iskra.JSCore.JSObjectProxyFactory.GetProxy<global::Iskra.StdWeb.ReportingObserver>(__res_274);

                input(__arg_271, __arg_273);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject __funcObj_275 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(__funcObj_275, input);

        return __funcObj_275;
    }
}

#nullable disable