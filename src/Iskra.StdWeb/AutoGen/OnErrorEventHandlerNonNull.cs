// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public delegate global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>? OnErrorEventHandlerNonNullManaged(global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.Event, string, global::Iskra.StdWeb.GenericMarshaller.Union> @event, string source, uint lineno, uint colno, global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>? error);

public partial class OnErrorEventHandlerNonNull: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public OnErrorEventHandlerNonNull(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public OnErrorEventHandlerNonNull(OnErrorEventHandlerNonNullManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator OnErrorEventHandlerNonNull(OnErrorEventHandlerNonNullManaged input)
    {
        return new global::Iskra.StdWeb.OnErrorEventHandlerNonNull(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.StdWeb.OnErrorEventHandlerNonNullManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.StdWeb.OnErrorEventHandlerNonNullManaged;
        if (managed is not null)
        {
            return true;
        }

        if (!allowConversion)
        {
            return false;
        }

        managed = (@event, source, lineno, colno, error) =>
        {
            int ___argsArrayLength_3 = 5;

            using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

            // Argument 1
            global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_4 = @event.JSObject;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnion(___argsArray_0.JSObject, 0, ___propObject_4);

            // Argument 2
            string ___marshalledValue_5;
            ___marshalledValue_5 = source;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2(___argsArray_0.JSObject, 1, ___marshalledValue_5);

            // Argument 3
            double ___marshalledValue_6;
            ___marshalledValue_6 = Convert.ToDouble(lineno);
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsDoubleV2(___argsArray_0.JSObject, 2, ___marshalledValue_6);

            // Argument 4
            double ___marshalledValue_7;
            ___marshalledValue_7 = Convert.ToDouble(colno);
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsDoubleV2(___argsArray_0.JSObject, 3, ___marshalledValue_7);

            // Argument 5
            global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_8;
            if (error is null)
            {
                ___propObject_8 = null;
            }
            else
            {
                ___propObject_8 = error.JSObject;
            }

            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnionAsNullable(___argsArray_0.JSObject, 4, ___propObject_8);

            using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

            global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyNonVoidFunction(JSObject, null, ___argsArray_0.JSObject, ___resOwner_1.JSObject);

            // Return Value
            global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>? ___res_2;
            global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_9;
            ___propObject_9 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsUnionV2AsNullable(___resOwner_1.JSObject, "value");
            if (___propObject_9 is null)
            {
                ___res_2 = null;
            }
            else
            {
                ___res_2 = new global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>(___propObject_9);
            }
            return ___res_2;
        };
        return true;
    }
    
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(OnErrorEventHandlerNonNullManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject, global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (__args_508, __res_521) =>
        {
            using (__args_508)
            using (__res_521)
            {
                // Argument 1
                global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.Event, string, global::Iskra.StdWeb.GenericMarshaller.Union> __arg_510;
                global::System.Runtime.InteropServices.JavaScript.JSObject __propObject_511;
                __propObject_511 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsUnionV2(__args_508, 0);
                __arg_510 = new global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.Event, string, global::Iskra.StdWeb.GenericMarshaller.Union>(__propObject_511);

                // Argument 2
                string __arg_512;
                string __res_513 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsStringV2(__args_508, 1);
                __arg_512 = __res_513;

                // Argument 3
                uint __arg_514;
                double __res_515 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsDoubleV2(__args_508, 2);
                __arg_514 = Convert.ToUInt32(__res_515);

                // Argument 4
                uint __arg_516;
                double __res_517 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsDoubleV2(__args_508, 3);
                __arg_516 = Convert.ToUInt32(__res_517);

                // Argument 5
                global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>? __arg_518;
                global::System.Runtime.InteropServices.JavaScript.JSObject? __propObject_519;
                __propObject_519 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsUnionV2AsNullable(__args_508, 4);
                if (__propObject_519 is null)
                {
                    __arg_518 = null;
                }
                else
                {
                    __arg_518 = new global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>(__propObject_519);
                }

                global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>? __managedRes_522 = input(__arg_510, __arg_512, __arg_514, __arg_516, __arg_518);

                global::System.Runtime.InteropServices.JavaScript.JSObject? __propObject_523;
                if (__managedRes_522 is null)
                {
                    __propObject_523 = null;
                }
                else
                {
                    __propObject_523 = __managedRes_522.JSObject;
                }

                global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnionAsNullable(__res_521, "value", __propObject_523);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject __funcObj_520 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsNonVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(__funcObj_520, input); 

        return __funcObj_520;
    }
}

#nullable disable