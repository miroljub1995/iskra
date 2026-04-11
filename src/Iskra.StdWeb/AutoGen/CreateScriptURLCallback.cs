// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public delegate string? CreateScriptURLCallbackManaged(string input, params global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>?[] arguments);

public partial class CreateScriptURLCallback: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public CreateScriptURLCallback(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public CreateScriptURLCallback(CreateScriptURLCallbackManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator CreateScriptURLCallback(CreateScriptURLCallbackManaged input)
    {
        return new global::Iskra.StdWeb.CreateScriptURLCallback(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.StdWeb.CreateScriptURLCallbackManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.StdWeb.CreateScriptURLCallbackManaged;
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
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(CreateScriptURLCallbackManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject, global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (__args_168, __res_178) =>
        {
            using (__args_168)
            using (__res_178)
            {
                // Argument 1
                string __arg_170;
                string __res_171 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsStringV2(__args_168, 0);
                __arg_170 = __res_171;

                // Argument 2
                int __length_169 = global::System.Convert.ToInt32(global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsDoubleV2(__args_168, "length"));
                int __paramsLength_173 = __length_169 - 1;
                global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>?[] __arg_172 = new global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>?[__paramsLength_173];
                for (int __i_174 = 0; __i_174 < __paramsLength_173; __i_174++)
                {
                    global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>? __paramsItem_175;

                    global::System.Runtime.InteropServices.JavaScript.JSObject? __propObject_176;
                    __propObject_176 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsUnionV2AsNullable(__args_168, 1 + __i_174);
                    if (__propObject_176 is null)
                    {
                        __paramsItem_175 = null;
                    }
                    else
                    {
                        __paramsItem_175 = new global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>(__propObject_176);
                    }

                    __arg_172[__i_174] = __paramsItem_175;
                }

                string? __managedRes_179 = input(__arg_170, __arg_172);

                string? __marshalledValue_180;
                if (__managedRes_179 is null)
                {
                    __marshalledValue_180 = null;
                }
                else
                {
                    string __notNullable_181 = (string)__managedRes_179;
                    __marshalledValue_180 = __notNullable_181;
                }
                global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2AsNullable(__res_178, "value", __marshalledValue_180);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject __funcObj_177 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsNonVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(__funcObj_177, input); 

        return __funcObj_177;
    }
}

#nullable disable