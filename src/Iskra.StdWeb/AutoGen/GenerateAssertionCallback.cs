// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public delegate global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.RTCIdentityAssertionResult, global::Iskra.StdWeb.PropertyAccessor> GenerateAssertionCallbackManaged(string contents, string origin, global::Iskra.StdWeb.RTCIdentityProviderOptions options);

public partial class GenerateAssertionCallback: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public GenerateAssertionCallback(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public GenerateAssertionCallback(GenerateAssertionCallbackManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator GenerateAssertionCallback(GenerateAssertionCallbackManaged input)
    {
        return new global::Iskra.StdWeb.GenerateAssertionCallback(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.StdWeb.GenerateAssertionCallbackManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.StdWeb.GenerateAssertionCallbackManaged;
        if (managed is not null)
        {
            return true;
        }

        if (!allowConversion)
        {
            return false;
        }

        managed = (contents, origin, options) =>
        {
            int ___argsArrayLength_3 = 3;

            using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

            // Argument 1
            string ___marshalledValue_4;
            ___marshalledValue_4 = contents;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

            // Argument 2
            string ___marshalledValue_5;
            ___marshalledValue_5 = origin;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2(___argsArray_0.JSObject, 1, ___marshalledValue_5);

            // Argument 3
            global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_6;
            ___marshalledValue_6 = options.JSObject;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 2, ___marshalledValue_6);

            using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

            global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyNonVoidFunction(JSObject, null, ___argsArray_0.JSObject, ___resOwner_1.JSObject);

            // Return Value
            global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.RTCIdentityAssertionResult, global::Iskra.StdWeb.PropertyAccessor> ___res_2;
            global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_7;
            ___propObject_7 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(___resOwner_1.JSObject, "value");
            ___res_2 = new global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.RTCIdentityAssertionResult, global::Iskra.StdWeb.PropertyAccessor>(___propObject_7);
            return ___res_2;
        };
        return true;
    }
    
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(GenerateAssertionCallbackManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject, global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (___args_0, ___res_9) =>
        {
            using (___args_0)
            using (___res_9)
            {
                // Argument 1
                string ___arg_2;
                string ___res_3 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsStringV2(___args_0, 0);
                ___arg_2 = ___res_3;

                // Argument 2
                string ___arg_4;
                string ___res_5 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsStringV2(___args_0, 1);
                ___arg_4 = ___res_5;

                // Argument 3
                global::Iskra.StdWeb.RTCIdentityProviderOptions ___arg_6;
                global::System.Runtime.InteropServices.JavaScript.JSObject ___res_7 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(___args_0, 2);
                ___arg_6 = new global::Iskra.StdWeb.RTCIdentityProviderOptions(___res_7);

                global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.RTCIdentityAssertionResult, global::Iskra.StdWeb.PropertyAccessor> ___managedRes_10 = input(___arg_2, ___arg_4, ___arg_6);

                global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_11 = ___managedRes_10.JSObject;
                global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___res_9, "value", ___propObject_11);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject ___funcObj_8 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsNonVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(___funcObj_8, input); 

        return ___funcObj_8;
    }
}

#nullable disable