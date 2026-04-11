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
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (__args_459) =>
        {
            using (__args_459)
            {
                // Argument 1
                double? __arg_461;
                double? __res_462 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsDoubleV2AsNullable(__args_459, 0);
                if (__res_462 is null)
                {
                    __arg_461 = null;
                }
                else
                {
                    double __notNullable_463 = (double)__res_462;
                    __arg_461 = __notNullable_463;
                }

                // Argument 2
                global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.CSSPseudoElement, global::Iskra.StdWeb.GenericMarshaller.Union> __arg_464;
                global::System.Runtime.InteropServices.JavaScript.JSObject __propObject_465;
                __propObject_465 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsUnionV2(__args_459, 1);
                __arg_464 = new global::Iskra.JSCore.Generics.Union<global::Iskra.StdWeb.Element, global::Iskra.StdWeb.CSSPseudoElement, global::Iskra.StdWeb.GenericMarshaller.Union>(__propObject_465);

                // Argument 3
                global::Iskra.StdWeb.Animation __arg_466;
                global::System.Runtime.InteropServices.JavaScript.JSObject __res_467 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(__args_459, 2);
                __arg_466 = global::Iskra.JSCore.JSObjectProxyFactory.GetProxy<global::Iskra.StdWeb.Animation>(__res_467);

                input(__arg_461, __arg_464, __arg_466);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject __funcObj_468 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(__funcObj_468, input);

        return __funcObj_468;
    }
}

#nullable disable