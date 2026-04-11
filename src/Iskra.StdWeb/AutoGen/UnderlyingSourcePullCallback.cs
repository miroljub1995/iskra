// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public delegate global::Iskra.JSCore.Promise UnderlyingSourcePullCallbackManaged(global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.ReadableStreamDefaultController, global::Iskra.StdWeb.ReadableByteStreamController, global::Iskra.StdWeb.GenericMarshaller.Union> controller);

public partial class UnderlyingSourcePullCallback: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public UnderlyingSourcePullCallback(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public UnderlyingSourcePullCallback(UnderlyingSourcePullCallbackManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator UnderlyingSourcePullCallback(UnderlyingSourcePullCallbackManaged input)
    {
        return new global::Iskra.StdWeb.UnderlyingSourcePullCallback(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.StdWeb.UnderlyingSourcePullCallbackManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.StdWeb.UnderlyingSourcePullCallbackManaged;
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
            global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_4 = controller.JSObject;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnion(___argsArray_0.JSObject, 0, ___propObject_4);

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
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(UnderlyingSourcePullCallbackManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject, global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (__args_34, __res_39) =>
        {
            using (__args_34)
            using (__res_39)
            {
                // Argument 1
                global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.ReadableStreamDefaultController, global::Iskra.StdWeb.ReadableByteStreamController, global::Iskra.StdWeb.GenericMarshaller.Union> __arg_36;
                global::System.Runtime.InteropServices.JavaScript.JSObject __propObject_37;
                __propObject_37 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsUnionV2(__args_34, 0);
                __arg_36 = new global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.ReadableStreamDefaultController, global::Iskra.StdWeb.ReadableByteStreamController, global::Iskra.StdWeb.GenericMarshaller.Union>(__propObject_37);

                global::Iskra.JSCore.Promise __managedRes_40 = input(__arg_36);

                global::System.Runtime.InteropServices.JavaScript.JSObject __propObject_41 = __managedRes_40.JSObject;
                global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(__res_39, "value", __propObject_41);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject __funcObj_38 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsNonVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(__funcObj_38, input); 

        return __funcObj_38;
    }
}

#nullable disable