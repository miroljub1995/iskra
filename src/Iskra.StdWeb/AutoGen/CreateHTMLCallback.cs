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
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject, global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (__args_140, __res_150) =>
        {
            using (__args_140)
            using (__res_150)
            {
                // Argument 1
                string __arg_142;
                string __res_143 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsStringV2(__args_140, 0);
                __arg_142 = __res_143;

                // Argument 2
                int __length_141 = global::System.Convert.ToInt32(global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsDoubleV2(__args_140, "length"));
                int __paramsLength_145 = __length_141 - 1;
                global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>?[] __arg_144 = new global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>?[__paramsLength_145];
                for (int __i_146 = 0; __i_146 < __paramsLength_145; __i_146++)
                {
                    global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>? __paramsItem_147;

                    global::System.Runtime.InteropServices.JavaScript.JSObject? __propObject_148;
                    __propObject_148 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsUnionV2AsNullable(__args_140, 1 + __i_146);
                    if (__propObject_148 is null)
                    {
                        __paramsItem_147 = null;
                    }
                    else
                    {
                        __paramsItem_147 = new global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>(__propObject_148);
                    }

                    __arg_144[__i_146] = __paramsItem_147;
                }

                string? __managedRes_151 = input(__arg_142, __arg_144);

                string? __marshalledValue_152;
                if (__managedRes_151 is null)
                {
                    __marshalledValue_152 = null;
                }
                else
                {
                    string __notNullable_153 = (string)__managedRes_151;
                    __marshalledValue_152 = __notNullable_153;
                }
                global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2AsNullable(__res_150, "value", __marshalledValue_152);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject __funcObj_149 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsNonVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(__funcObj_149, input); 

        return __funcObj_149;
    }
}

#nullable disable