// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public delegate void PositionErrorCallbackManaged(global::Iskra.StdWeb.GeolocationPositionError positionError);

public partial class PositionErrorCallback: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public PositionErrorCallback(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public PositionErrorCallback(PositionErrorCallbackManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator PositionErrorCallback(PositionErrorCallbackManaged input)
    {
        return new global::Iskra.StdWeb.PositionErrorCallback(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.StdWeb.PositionErrorCallbackManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.StdWeb.PositionErrorCallbackManaged;
        if (managed is not null)
        {
            return true;
        }

        if (!allowConversion)
        {
            return false;
        }

        managed = (positionError) =>
        {
            int ___argsArrayLength_3 = 1;

            using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

            // Argument 1
            global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_4;
            ___marshalledValue_4 = positionError.JSObject;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

            global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyVoidFunction(JSObject, null, ___argsArray_0.JSObject);
        };
        return true;
    }
    
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(PositionErrorCallbackManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (___args_0) =>
        {
            using (___args_0)
            {
                // Argument 1
                global::Iskra.StdWeb.GeolocationPositionError ___arg_2;
                global::System.Runtime.InteropServices.JavaScript.JSObject ___res_3 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(___args_0, 0);
                ___arg_2 = global::Iskra.JSCore.JSObjectProxyFactory.GetProxy<global::Iskra.StdWeb.GeolocationPositionError>(___res_3);

                input(___arg_2);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject ___funcObj_4 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(___funcObj_4, input);

        return ___funcObj_4;
    }
}

#nullable disable