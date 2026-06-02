// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public delegate global::Iskra.JSCore.Generics.Promise<string, global::Iskra.StdWeb.PropertyAccessor> LanguageModelToolFunctionManaged(params global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>?[] arguments);

public partial class LanguageModelToolFunction: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public LanguageModelToolFunction(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public LanguageModelToolFunction(LanguageModelToolFunctionManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator LanguageModelToolFunction(LanguageModelToolFunctionManaged input)
    {
        return new global::Iskra.StdWeb.LanguageModelToolFunction(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.StdWeb.LanguageModelToolFunctionManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.StdWeb.LanguageModelToolFunctionManaged;
        if (managed is not null)
        {
            return true;
        }

        if (!allowConversion)
        {
            return false;
        }

        managed = (arguments) =>
        {
            int ___argsArrayLength_3 = arguments.Length + 0;

            using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

            // Argument 1
            for (int ___i_4 = 0; ___i_4 < arguments.Length; ___i_4++)
            {
            global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>? ___elem_5 = arguments[___i_4];
                global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_6;
                if (___elem_5 is null)
                {
                    ___propObject_6 = null;
                }
                else
                {
                    ___propObject_6 = ___elem_5.JSObject;
                }

                global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnionAsNullable(___argsArray_0.JSObject, 0 + ___i_4, ___propObject_6);
            }

            using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

            global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyNonVoidFunction(JSObject, null, ___argsArray_0.JSObject, ___resOwner_1.JSObject);

            // Return Value
            global::Iskra.JSCore.Generics.Promise<string, global::Iskra.StdWeb.PropertyAccessor> ___res_2;
            global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_7;
            ___propObject_7 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(___resOwner_1.JSObject, "value");
            ___res_2 = new global::Iskra.JSCore.Generics.Promise<string, global::Iskra.StdWeb.PropertyAccessor>(___propObject_7);
            return ___res_2;
        };
        return true;
    }
    
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(LanguageModelToolFunctionManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject, global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (___args_0, ___res_8) =>
        {
            using (___args_0)
            using (___res_8)
            {
                // Argument 1
                int ___length_1 = global::System.Convert.ToInt32(global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsDoubleV2(___args_0, "length"));
                int ___paramsLength_3 = ___length_1 - 0;
                global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>?[] ___arg_2 = new global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>?[___paramsLength_3];
                for (int ___i_4 = 0; ___i_4 < ___paramsLength_3; ___i_4++)
                {
                    global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>? ___paramsItem_5;

                    global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_6;
                    ___propObject_6 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsUnionV2AsNullable(___args_0, 0 + ___i_4);
                    if (___propObject_6 is null)
                    {
                        ___paramsItem_5 = null;
                    }
                    else
                    {
                        ___paramsItem_5 = new global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>(___propObject_6);
                    }

                    ___arg_2[___i_4] = ___paramsItem_5;
                }

                global::Iskra.JSCore.Generics.Promise<string, global::Iskra.StdWeb.PropertyAccessor> ___managedRes_9 = input(___arg_2);

                global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_10 = ___managedRes_9.JSObject;
                global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___res_8, "value", ___propObject_10);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject ___funcObj_7 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsNonVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(___funcObj_7, input); 

        return ___funcObj_7;
    }
}

#nullable disable