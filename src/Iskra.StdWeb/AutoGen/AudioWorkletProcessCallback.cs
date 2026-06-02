// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public delegate bool AudioWorkletProcessCallbackManaged(global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.JSCore.Float32Array, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor> inputs, global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.JSCore.Float32Array, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor> outputs, global::System.Runtime.InteropServices.JavaScript.JSObject parameters);

public partial class AudioWorkletProcessCallback: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public AudioWorkletProcessCallback(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public AudioWorkletProcessCallback(AudioWorkletProcessCallbackManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator AudioWorkletProcessCallback(AudioWorkletProcessCallbackManaged input)
    {
        return new global::Iskra.StdWeb.AudioWorkletProcessCallback(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.StdWeb.AudioWorkletProcessCallbackManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.StdWeb.AudioWorkletProcessCallbackManaged;
        if (managed is not null)
        {
            return true;
        }

        if (!allowConversion)
        {
            return false;
        }

        managed = (inputs, outputs, parameters) =>
        {
            int ___argsArrayLength_3 = 3;

            using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

            // Argument 1
            global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_4 = inputs.JSObject;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 0, ___propObject_4);

            // Argument 2
            global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_5 = outputs.JSObject;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 1, ___propObject_5);

            // Argument 3
            global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_6;
            ___marshalledValue_6 = parameters;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 2, ___marshalledValue_6);

            using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

            global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyNonVoidFunction(JSObject, null, ___argsArray_0.JSObject, ___resOwner_1.JSObject);

            // Return Value
            bool ___res_2;
            bool ___res_7 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsBooleanV2(___resOwner_1.JSObject, "value");
            ___res_2 = ___res_7;
            return ___res_2;
        };
        return true;
    }
    
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(AudioWorkletProcessCallbackManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject, global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (___args_0, ___res_9) =>
        {
            using (___args_0)
            using (___res_9)
            {
                // Argument 1
                global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.JSCore.Float32Array, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor> ___arg_2;
                global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_3;
                ___propObject_3 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(___args_0, 0);
                ___arg_2 = new global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.JSCore.Float32Array, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(___propObject_3);

                // Argument 2
                global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.JSCore.Float32Array, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor> ___arg_4;
                global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_5;
                ___propObject_5 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(___args_0, 1);
                ___arg_4 = new global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.JSCore.Float32Array, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(___propObject_5);

                // Argument 3
                global::System.Runtime.InteropServices.JavaScript.JSObject ___arg_6;
                global::System.Runtime.InteropServices.JavaScript.JSObject ___res_7 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(___args_0, 2);
                ___arg_6 = ___res_7;

                bool ___managedRes_10 = input(___arg_2, ___arg_4, ___arg_6);

                bool ___marshalledValue_11;
                ___marshalledValue_11 = ___managedRes_10;
                global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsBooleanV2(___res_9, "value", ___marshalledValue_11);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject ___funcObj_8 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsNonVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(___funcObj_8, input); 

        return ___funcObj_8;
    }
}

#nullable disable