// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public delegate global::Iskra.JSCore.Generics.Promise<global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>?, global::Iskra.StdWeb.PropertyAccessorNullable> LockGrantedCallbackManaged(global::Iskra.StdWeb.Lock? @lock);

public partial class LockGrantedCallback: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public LockGrantedCallback(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public LockGrantedCallback(LockGrantedCallbackManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator LockGrantedCallback(LockGrantedCallbackManaged input)
    {
        return new global::Iskra.StdWeb.LockGrantedCallback(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.StdWeb.LockGrantedCallbackManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.StdWeb.LockGrantedCallbackManaged;
        if (managed is not null)
        {
            return true;
        }

        if (!allowConversion)
        {
            return false;
        }

        managed = (@lock) =>
        {
            int ___argsArrayLength_3 = 1;

            using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

            // Argument 1
            global::System.Runtime.InteropServices.JavaScript.JSObject? ___marshalledValue_4;
            if (@lock is null)
            {
                ___marshalledValue_4 = null;
            }
            else
            {
                global::Iskra.StdWeb.Lock ___notNullable_5 = (global::Iskra.StdWeb.Lock)@lock;
                ___marshalledValue_4 = ___notNullable_5.JSObject;
            }
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2AsNullable(___argsArray_0.JSObject, 0, ___marshalledValue_4);

            using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

            global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyNonVoidFunction(JSObject, null, ___argsArray_0.JSObject, ___resOwner_1.JSObject);

            // Return Value
            global::Iskra.JSCore.Generics.Promise<global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>?, global::Iskra.StdWeb.PropertyAccessorNullable> ___res_2;
            global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_6;
            ___propObject_6 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(___resOwner_1.JSObject, "value");
            ___res_2 = new global::Iskra.JSCore.Generics.Promise<global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>?, global::Iskra.StdWeb.PropertyAccessorNullable>(___propObject_6);
            return ___res_2;
        };
        return true;
    }
    
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(LockGrantedCallbackManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject, global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (___args_0, ___res_6) =>
        {
            using (___args_0)
            using (___res_6)
            {
                // Argument 1
                global::Iskra.StdWeb.Lock? ___arg_2;
                global::System.Runtime.InteropServices.JavaScript.JSObject? ___res_3 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2AsNullable(___args_0, 0);
                if (___res_3 is null)
                {
                    ___arg_2 = null;
                }
                else
                {
                    global::System.Runtime.InteropServices.JavaScript.JSObject ___notNullable_4 = (global::System.Runtime.InteropServices.JavaScript.JSObject)___res_3;
                    ___arg_2 = global::Iskra.JSCore.JSObjectProxyFactory.GetProxy<global::Iskra.StdWeb.Lock>(___notNullable_4);
                }

                global::Iskra.JSCore.Generics.Promise<global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>?, global::Iskra.StdWeb.PropertyAccessorNullable> ___managedRes_7 = input(___arg_2);

                global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_8 = ___managedRes_7.JSObject;
                global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___res_6, "value", ___propObject_8);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject ___funcObj_5 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsNonVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(___funcObj_5, input); 

        return ___funcObj_5;
    }
}

#nullable disable