// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public delegate void EncodedAudioChunkOutputCallbackManaged(global::Iskra.StdWeb.EncodedAudioChunk output, global::Iskra.StdWeb.EncodedAudioChunkMetadata metadata);

public partial class EncodedAudioChunkOutputCallback: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public EncodedAudioChunkOutputCallback(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public EncodedAudioChunkOutputCallback(EncodedAudioChunkOutputCallbackManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator EncodedAudioChunkOutputCallback(EncodedAudioChunkOutputCallbackManaged input)
    {
        return new global::Iskra.StdWeb.EncodedAudioChunkOutputCallback(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.StdWeb.EncodedAudioChunkOutputCallbackManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.StdWeb.EncodedAudioChunkOutputCallbackManaged;
        if (managed is not null)
        {
            return true;
        }

        if (!allowConversion)
        {
            return false;
        }

        managed = (output, metadata) =>
        {
            int ___argsArrayLength_3 = 2;

            using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

            // Argument 1
            global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_4;
            ___marshalledValue_4 = output.JSObject;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

            // Argument 2
            global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_5;
            ___marshalledValue_5 = metadata.JSObject;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 1, ___marshalledValue_5);

            global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyVoidFunction(JSObject, null, ___argsArray_0.JSObject);
        };
        return true;
    }
    
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(EncodedAudioChunkOutputCallbackManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (___args_0) =>
        {
            using (___args_0)
            {
                // Argument 1
                global::Iskra.StdWeb.EncodedAudioChunk ___arg_2;
                global::System.Runtime.InteropServices.JavaScript.JSObject ___res_3 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(___args_0, 0);
                ___arg_2 = global::Iskra.JSCore.JSObjectProxyFactory.GetProxy<global::Iskra.StdWeb.EncodedAudioChunk>(___res_3);

                // Argument 2
                global::Iskra.StdWeb.EncodedAudioChunkMetadata ___arg_4;
                global::System.Runtime.InteropServices.JavaScript.JSObject ___res_5 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(___args_0, 1);
                ___arg_4 = new global::Iskra.StdWeb.EncodedAudioChunkMetadata(___res_5);

                input(___arg_2, ___arg_4);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject ___funcObj_6 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(___funcObj_6, input);

        return ___funcObj_6;
    }
}

#nullable disable