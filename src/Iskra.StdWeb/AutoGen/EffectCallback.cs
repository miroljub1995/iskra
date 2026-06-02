// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public delegate void EffectCallbackManaged(double? progress, global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.CSSPseudoElement, global::Iskra.StdWeb.GenericMarshaller.Union> currentTarget, global::Iskra.StdWeb.Animation animation);

public partial class EffectCallback: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public EffectCallback(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public EffectCallback(EffectCallbackManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator EffectCallback(EffectCallbackManaged input)
    {
        return new global::Iskra.StdWeb.EffectCallback(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.StdWeb.EffectCallbackManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.StdWeb.EffectCallbackManaged;
        if (managed is not null)
        {
            return true;
        }

        if (!allowConversion)
        {
            return false;
        }

        managed = (progress, currentTarget, animation) =>
        {
            int ___argsArrayLength_3 = 3;

            using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

            // Argument 1
            double? ___marshalledValue_4;
            if (progress is null)
            {
                ___marshalledValue_4 = null;
            }
            else
            {
                double ___notNullable_5 = (double)progress;
                ___marshalledValue_4 = ___notNullable_5;
            }
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsDoubleV2AsNullable(___argsArray_0.JSObject, 0, ___marshalledValue_4);

            // Argument 2
            global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_6 = currentTarget.JSObject;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsUnion(___argsArray_0.JSObject, 1, ___propObject_6);

            // Argument 3
            global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_7;
            ___marshalledValue_7 = animation.JSObject;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 2, ___marshalledValue_7);

            global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyVoidFunction(JSObject, null, ___argsArray_0.JSObject);
        };
        return true;
    }
    
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(EffectCallbackManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (___args_0) =>
        {
            using (___args_0)
            {
                // Argument 1
                double? ___arg_2;
                double? ___res_3 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsDoubleV2AsNullable(___args_0, 0);
                if (___res_3 is null)
                {
                    ___arg_2 = null;
                }
                else
                {
                    double ___notNullable_4 = (double)___res_3;
                    ___arg_2 = ___notNullable_4;
                }

                // Argument 2
                global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.CSSPseudoElement, global::Iskra.StdWeb.GenericMarshaller.Union> ___arg_5;
                global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_6;
                ___propObject_6 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsUnionV2(___args_0, 1);
                ___arg_5 = new global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.CSSPseudoElement, global::Iskra.StdWeb.GenericMarshaller.Union>(___propObject_6);

                // Argument 3
                global::Iskra.StdWeb.Animation ___arg_7;
                global::System.Runtime.InteropServices.JavaScript.JSObject ___res_8 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(___args_0, 2);
                ___arg_7 = global::Iskra.JSCore.JSObjectProxyFactory.GetProxy<global::Iskra.StdWeb.Animation>(___res_8);

                input(___arg_2, ___arg_5, ___arg_7);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject ___funcObj_9 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(___funcObj_9, input);

        return ___funcObj_9;
    }
}

#nullable disable