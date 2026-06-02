// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public delegate global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>? ReducerManaged(global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>? accumulator, global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>? currentValue, ulong index);

public partial class Reducer: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public Reducer(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public Reducer(ReducerManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator Reducer(ReducerManaged input)
    {
        return new global::Iskra.StdWeb.Reducer(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.StdWeb.ReducerManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.StdWeb.ReducerManaged;
        if (managed is not null)
        {
            return true;
        }

        if (!allowConversion)
        {
            return false;
        }

        managed = (accumulator, currentValue, index) =>
        {
            int ___argsArrayLength_3 = 3;

            using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

            // Argument 1
            global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_4;
            if (accumulator is null)
            {
                ___propObject_4 = null;
            }
            else
            {
                ___propObject_4 = accumulator.JSObject;
            }

            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnionAsNullable(___argsArray_0.JSObject, 0, ___propObject_4);

            // Argument 2
            global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_5;
            if (currentValue is null)
            {
                ___propObject_5 = null;
            }
            else
            {
                ___propObject_5 = currentValue.JSObject;
            }

            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnionAsNullable(___argsArray_0.JSObject, 1, ___propObject_5);

            // Argument 3
            double ___marshalledValue_6;
            ___marshalledValue_6 = Convert.ToDouble(index);
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsDoubleV2(___argsArray_0.JSObject, 2, ___marshalledValue_6);

            using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

            global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyNonVoidFunction(JSObject, null, ___argsArray_0.JSObject, ___resOwner_1.JSObject);

            // Return Value
            global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>? ___res_2;
            global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_7;
            ___propObject_7 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsUnionV2AsNullable(___resOwner_1.JSObject, "value");
            if (___propObject_7 is null)
            {
                ___res_2 = null;
            }
            else
            {
                ___res_2 = new global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>(___propObject_7);
            }
            return ___res_2;
        };
        return true;
    }
    
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(ReducerManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject, global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (___args_0, ___res_9) =>
        {
            using (___args_0)
            using (___res_9)
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

                // Argument 2
                global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>? ___arg_4;
                global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_5;
                ___propObject_5 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsUnionV2AsNullable(___args_0, 1);
                if (___propObject_5 is null)
                {
                    ___arg_4 = null;
                }
                else
                {
                    ___arg_4 = new global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>(___propObject_5);
                }

                // Argument 3
                ulong ___arg_6;
                double ___res_7 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsDoubleV2(___args_0, 2);
                ___arg_6 = Convert.ToUInt64(___res_7);

                global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.StdWeb.GenericMarshaller.Union>? ___managedRes_10 = input(___arg_2, ___arg_4, ___arg_6);

                global::System.Runtime.InteropServices.JavaScript.JSObject? ___propObject_11;
                if (___managedRes_10 is null)
                {
                    ___propObject_11 = null;
                }
                else
                {
                    ___propObject_11 = ___managedRes_10.JSObject;
                }

                global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnionAsNullable(___res_9, "value", ___propObject_11);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject ___funcObj_8 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsNonVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(___funcObj_8, input); 

        return ___funcObj_8;
    }
}

#nullable disable