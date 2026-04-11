// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public delegate void PressureUpdateCallbackManaged(global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.PressureRecord, global::Iskra.StdWeb.PropertyAccessor> changes, global::Iskra.StdWeb.PressureObserver observer);

public partial class PressureUpdateCallback: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public PressureUpdateCallback(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public PressureUpdateCallback(PressureUpdateCallbackManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator PressureUpdateCallback(PressureUpdateCallbackManaged input)
    {
        return new global::Iskra.StdWeb.PressureUpdateCallback(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.StdWeb.PressureUpdateCallbackManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.StdWeb.PressureUpdateCallbackManaged;
        if (managed is not null)
        {
            return true;
        }

        if (!allowConversion)
        {
            return false;
        }

        managed = (changes, observer) =>
        {
            int ___argsArrayLength_3 = 2;

            using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

            // Argument 1
            global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_4 = changes.JSObject;
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
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(PressureUpdateCallbackManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (__args_290) =>
        {
            using (__args_290)
            {
                // Argument 1
                global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.PressureRecord, global::Iskra.StdWeb.PropertyAccessor> __arg_292;
                global::System.Runtime.InteropServices.JavaScript.JSObject __propObject_293;
                __propObject_293 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(__args_290, 0);
                __arg_292 = new global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.PressureRecord, global::Iskra.StdWeb.PropertyAccessor>(__propObject_293);

                // Argument 2
                global::Iskra.StdWeb.PressureObserver __arg_294;
                global::System.Runtime.InteropServices.JavaScript.JSObject __res_295 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(__args_290, 1);
                __arg_294 = global::Iskra.JSCore.JSObjectProxyFactory.GetProxy<global::Iskra.StdWeb.PressureObserver>(__res_295);

                input(__arg_292, __arg_294);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject __funcObj_296 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(__funcObj_296, input);

        return __funcObj_296;
    }
}

#nullable disable