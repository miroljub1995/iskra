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
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject, global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (___args_0, ___res_13) =>
        {
            using (___args_0)
            using (___res_13)
            {
                // Argument 1
                global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.Event, string, global::Iskra.StdWeb.GenericMarshaller.Union> ___arg_2;
                global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_3;
                ___propObject_3 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsUnionV2(___args_0, 0);
                ___arg_2 = new global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.Event, string, global::Iskra.StdWeb.GenericMarshaller.Union>(___propObject_3);

                // Argument 2
                string ___arg_4;
                string ___res_5 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsStringV2(___args_0, 1);
                ___arg_4 = ___res_5;

                // Argument 3
                uint ___arg_6;
                double ___res_7 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsDoubleV2(___args_0, 2);
                ___arg_6 = Convert.ToUInt32(___res_7);

                // Argument 4
                uint ___arg_8;
                double ___res_9 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsDoubleV2(___args_0, 3);
                ___arg_8 = Convert.ToUInt32(___res_9);

                // Argument 5
                global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>? ___arg_10;
                global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_11;
                ___propObject_11 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsUnionV2AsNullable(___args_0, 4);
                if (___propObject_11 is null)
                {
                    ___arg_10 = null;
                }
                else
                {
                    ___arg_10 = new global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>(___propObject_11);
                }

                global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>? ___managedRes_14 = input(___arg_2, ___arg_4, ___arg_6, ___arg_8, ___arg_10);

                global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_15;
                if (___managedRes_14 is null)
                {
                    ___propObject_15 = null;
                }
                else
                {
                    ___propObject_15 = ___managedRes_14.JSObject;
                }

                global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnionAsNullable(___res_13, "value", ___propObject_15);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject ___funcObj_12 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsNonVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(___funcObj_12, input); 

        return ___funcObj_12;
    }
}

#nullable disable