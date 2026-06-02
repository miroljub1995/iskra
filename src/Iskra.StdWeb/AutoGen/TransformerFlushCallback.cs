// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public delegate global::Iskra.JSCore.Promise TransformerFlushCallbackManaged(global::Iskra.StdWeb.TransformStreamDefaultController controller);

public partial class TransformerFlushCallback: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public TransformerFlushCallback(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public TransformerFlushCallback(TransformerFlushCallbackManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator TransformerFlushCallback(TransformerFlushCallbackManaged input)
    {
        return new global::Iskra.StdWeb.TransformerFlushCallback(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.StdWeb.TransformerFlushCallbackManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.StdWeb.TransformerFlushCallbackManaged;
        if (managed is not null)
        {
            return true;
        }

        if (!allowConversion)
        {
            return false;
        }

        managed = (controller) =>
        {
            int ___argsArrayLength_3 = 1;

            using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

            // Argument 1
            global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_4;
            ___marshalledValue_4 = controller.JSObject;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

            using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

            global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyNonVoidFunction(JSObject, null, ___argsArray_0.JSObject, ___resOwner_1.JSObject);

            // Return Value
            global::Iskra.JSCore.Promise ___res_2;
            global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_5;
            ___propObject_5 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(___resOwner_1.JSObject, "value");
            ___res_2 = new global::Iskra.JSCore.Promise(___propObject_5);
            return ___res_2;
        };
        return true;
    }
    
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(TransformerFlushCallbackManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject, global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (___args_0, ___res_5) =>
        {
            using (___args_0)
            using (___res_5)
            {
                // Argument 1
                global::Iskra.StdWeb.TransformStreamDefaultController ___arg_2;
                global::System.Runtime.InteropServices.JavaScript.JSObject ___res_3 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(___args_0, 0);
                ___arg_2 = global::Iskra.JSCore.JSObjectProxyFactory.GetProxy<global::Iskra.StdWeb.TransformStreamDefaultController>(___res_3);

                global::Iskra.JSCore.Promise ___managedRes_6 = input(___arg_2);

                global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_7 = ___managedRes_6.JSObject;
                global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___res_5, "value", ___propObject_7);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject ___funcObj_4 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsNonVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(___funcObj_4, input); 

        return ___funcObj_4;
    }
}

#nullable disable