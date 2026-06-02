// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public delegate string? CreateHTMLCallbackManaged(string input, params global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>?[] arguments);

public partial class CreateHTMLCallback: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public CreateHTMLCallback(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public CreateHTMLCallback(CreateHTMLCallbackManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator CreateHTMLCallback(CreateHTMLCallbackManaged input)
    {
        return new global::Iskra.StdWeb.CreateHTMLCallback(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.StdWeb.CreateHTMLCallbackManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.StdWeb.CreateHTMLCallbackManaged;
        if (managed is not null)
        {
            return true;
        }

        if (!allowConversion)
        {
            return false;
        }

        managed = (input, arguments) =>
        {
            int ___argsArrayLength_3 = arguments.Length + 1;

            using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

            // Argument 1
            string ___marshalledValue_4;
            ___marshalledValue_4 = input;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

            // Argument 2
            for (int ___i_5 = 0; ___i_5 < arguments.Length; ___i_5++)
            {
            global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>? ___elem_6 = arguments[___i_5];
                global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_7;
                if (___elem_6 is null)
                {
                    ___propObject_7 = null;
                }
                else
                {
                    ___propObject_7 = ___elem_6.JSObject;
                }

                global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnionAsNullable(___argsArray_0.JSObject, 1 + ___i_5, ___propObject_7);
            }

            using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

            global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyNonVoidFunction(JSObject, null, ___argsArray_0.JSObject, ___resOwner_1.JSObject);

            // Return Value
            string? ___res_2;
            string? ___res_8 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsStringV2AsNullable(___resOwner_1.JSObject, "value");
            if (___res_8 is null)
            {
                ___res_2 = null;
            }
            else
            {
                string ___notNullable_9 = (string)___res_8;
                ___res_2 = ___notNullable_9;
            }
            return ___res_2;
        };
        return true;
    }
    
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(CreateHTMLCallbackManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject, global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (___args_0, ___res_10) =>
        {
            using (___args_0)
            using (___res_10)
            {
                // Argument 1
                string ___arg_2;
                string ___res_3 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsStringV2(___args_0, 0);
                ___arg_2 = ___res_3;

                // Argument 2
                int ___length_1 = global::System.Convert.ToInt32(global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsDoubleV2(___args_0, "length"));
                int ___paramsLength_5 = ___length_1 - 1;
                global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>?[] ___arg_4 = new global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>?[___paramsLength_5];
                for (int ___i_6 = 0; ___i_6 < ___paramsLength_5; ___i_6++)
                {
                    global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>? ___paramsItem_7;

                    global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_8;
                    ___propObject_8 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsUnionV2AsNullable(___args_0, 1 + ___i_6);
                    if (___propObject_8 is null)
                    {
                        ___paramsItem_7 = null;
                    }
                    else
                    {
                        ___paramsItem_7 = new global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>(___propObject_8);
                    }

                    ___arg_4[___i_6] = ___paramsItem_7;
                }

                string? ___managedRes_11 = input(___arg_2, ___arg_4);

                string? ___marshalledValue_12;
                if (___managedRes_11 is null)
                {
                    ___marshalledValue_12 = null;
                }
                else
                {
                    string ___notNullable_13 = (string)___managedRes_11;
                    ___marshalledValue_12 = ___notNullable_13;
                }
                global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2AsNullable(___res_10, "value", ___marshalledValue_12);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject ___funcObj_9 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsNonVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(___funcObj_9, input); 

        return ___funcObj_9;
    }
}

#nullable disable