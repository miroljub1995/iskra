// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public delegate global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.RemoteDocument, global::Iskra.StdWeb.PropertyAccessor> LoadDocumentCallbackManaged(string url, global::Iskra.StdWeb.LoadDocumentOptions options);

public partial class LoadDocumentCallback: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public LoadDocumentCallback(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public LoadDocumentCallback(LoadDocumentCallbackManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator LoadDocumentCallback(LoadDocumentCallbackManaged input)
    {
        return new global::Iskra.StdWeb.LoadDocumentCallback(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.StdWeb.LoadDocumentCallbackManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.StdWeb.LoadDocumentCallbackManaged;
        if (managed is not null)
        {
            return true;
        }

        if (!allowConversion)
        {
            return false;
        }

        managed = (url, options) =>
        {
            int ___argsArrayLength_3 = 2;

            using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

            // Argument 1
            string ___marshalledValue_4;
            ___marshalledValue_4 = url;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

            // Argument 2
            global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_5;
            ___marshalledValue_5 = options.JSObject;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 1, ___marshalledValue_5);

            using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

            global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyNonVoidFunction(JSObject, null, ___argsArray_0.JSObject, ___resOwner_1.JSObject);

            // Return Value
            global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.RemoteDocument, global::Iskra.StdWeb.PropertyAccessor> ___res_2;
            global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_6;
            ___propObject_6 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(___resOwner_1.JSObject, "value");
            ___res_2 = new global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.RemoteDocument, global::Iskra.StdWeb.PropertyAccessor>(___propObject_6);
            return ___res_2;
        };
        return true;
    }
    
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(LoadDocumentCallbackManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject, global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (___args_0, ___res_7) =>
        {
            using (___args_0)
            using (___res_7)
            {
                // Argument 1
                string ___arg_2;
                string ___res_3 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsStringV2(___args_0, 0);
                ___arg_2 = ___res_3;

                // Argument 2
                global::Iskra.StdWeb.LoadDocumentOptions ___arg_4;
                global::System.Runtime.InteropServices.JavaScript.JSObject ___res_5 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(___args_0, 1);
                ___arg_4 = new global::Iskra.StdWeb.LoadDocumentOptions(___res_5);

                global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.RemoteDocument, global::Iskra.StdWeb.PropertyAccessor> ___managedRes_8 = input(___arg_2, ___arg_4);

                global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_9 = ___managedRes_8.JSObject;
                global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___res_7, "value", ___propObject_9);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject ___funcObj_6 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsNonVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(___funcObj_6, input); 

        return ___funcObj_6;
    }
}

#nullable disable