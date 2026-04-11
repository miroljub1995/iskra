// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public delegate void BlobCallbackManaged(global::Iskra.StdWeb.Blob? blob);

public partial class BlobCallback: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public BlobCallback(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public BlobCallback(BlobCallbackManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator BlobCallback(BlobCallbackManaged input)
    {
        return new global::Iskra.StdWeb.BlobCallback(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.StdWeb.BlobCallbackManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.StdWeb.BlobCallbackManaged;
        if (managed is not null)
        {
            return true;
        }

        if (!allowConversion)
        {
            return false;
        }

        managed = (blob) =>
        {
            int ___argsArrayLength_3 = 1;

            using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

            // Argument 1
            global::System.Runtime.InteropServices.JavaScript.JSObject? ___marshalledValue_4;
            if (blob is null)
            {
                ___marshalledValue_4 = null;
            }
            else
            {
                global::Iskra.StdWeb.Blob ___notNullable_5 = (global::Iskra.StdWeb.Blob)blob;
                ___marshalledValue_4 = ___notNullable_5.JSObject;
            }
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2AsNullable(___argsArray_0.JSObject, 0, ___marshalledValue_4);

            global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyVoidFunction(JSObject, null, ___argsArray_0.JSObject);
        };
        return true;
    }
    
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(BlobCallbackManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (__args_469) =>
        {
            using (__args_469)
            {
                // Argument 1
                global::Iskra.StdWeb.Blob? __arg_471;
                global::System.Runtime.InteropServices.JavaScript.JSObject? __res_472 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2AsNullable(__args_469, 0);
                if (__res_472 is null)
                {
                    __arg_471 = null;
                }
                else
                {
                    global::System.Runtime.InteropServices.JavaScript.JSObject __notNullable_473 = (global::System.Runtime.InteropServices.JavaScript.JSObject)__res_472;
                    __arg_471 = global::Iskra.JSCore.JSObjectProxyFactory.GetProxy<global::Iskra.StdWeb.Blob>(__notNullable_473);
                }

                input(__arg_471);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject __funcObj_474 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(__funcObj_474, input);

        return __funcObj_474;
    }
}

#nullable disable