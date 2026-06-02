// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public delegate global::Iskra.JSCore.Promise UnderlyingSinkAbortCallbackManaged(global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>? reason);

public partial class UnderlyingSinkAbortCallback: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public UnderlyingSinkAbortCallback(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public UnderlyingSinkAbortCallback(UnderlyingSinkAbortCallbackManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator UnderlyingSinkAbortCallback(UnderlyingSinkAbortCallbackManaged input)
    {
        return new global::Iskra.StdWeb.UnderlyingSinkAbortCallback(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.StdWeb.UnderlyingSinkAbortCallbackManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.StdWeb.UnderlyingSinkAbortCallbackManaged;
        if (managed is not null)
        {
            return true;
        }

        if (!allowConversion)
        {
            return false;
        }

        managed = (reason) =>
        {
            int ___argsArrayLength_3 = 1;

            using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

            // Argument 1
            global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_4;
            if (reason is null)
            {
                ___propObject_4 = null;
            }
            else
            {
                ___propObject_4 = reason.JSObject;
            }

            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnionAsNullable(___argsArray_0.JSObject, 0, ___propObject_4);

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
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(UnderlyingSinkAbortCallbackManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject, global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (___args_0, ___res_5) =>
        {
            using (___args_0)
            using (___res_5)
            {
                // Argument 1
                global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>? ___arg_2;
                global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_3;
                ___propObject_3 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsUnionV2AsNullable(___args_0, 0);
                if (___propObject_3 is null)
                {
                    ___arg_2 = null;
                }
                else
                {
                    ___arg_2 = new global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>(___propObject_3);
                }

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