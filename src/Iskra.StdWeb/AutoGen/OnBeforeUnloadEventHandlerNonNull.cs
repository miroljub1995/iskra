// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public delegate string? OnBeforeUnloadEventHandlerNonNullManaged(global::Iskra.StdWeb.Event @event);

public partial class OnBeforeUnloadEventHandlerNonNull: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public OnBeforeUnloadEventHandlerNonNull(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public OnBeforeUnloadEventHandlerNonNull(OnBeforeUnloadEventHandlerNonNullManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator OnBeforeUnloadEventHandlerNonNull(OnBeforeUnloadEventHandlerNonNullManaged input)
    {
        return new global::Iskra.StdWeb.OnBeforeUnloadEventHandlerNonNull(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.StdWeb.OnBeforeUnloadEventHandlerNonNullManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.StdWeb.OnBeforeUnloadEventHandlerNonNullManaged;
        if (managed is not null)
        {
            return true;
        }

        if (!allowConversion)
        {
            return false;
        }

        managed = (@event) =>
        {
            int ___argsArrayLength_3 = 1;

            using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

            // Argument 1
            global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_4;
            ___marshalledValue_4 = @event.JSObject;
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 0, ___marshalledValue_4);

            using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

            global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyNonVoidFunction(JSObject, null, ___argsArray_0.JSObject, ___resOwner_1.JSObject);

            // Return Value
            string? ___res_2;
            string? ___res_5 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsStringV2AsNullable(___resOwner_1.JSObject, "value");
            if (___res_5 is null)
            {
                ___res_2 = null;
            }
            else
            {
                string ___notNullable_6 = (string)___res_5;
                ___res_2 = ___notNullable_6;
            }
            return ___res_2;
        };
        return true;
    }
    
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(OnBeforeUnloadEventHandlerNonNullManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject, global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (__args_524, __res_529) =>
        {
            using (__args_524)
            using (__res_529)
            {
                // Argument 1
                global::Iskra.StdWeb.Event __arg_526;
                global::System.Runtime.InteropServices.JavaScript.JSObject __res_527 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(__args_524, 0);
                __arg_526 = global::Iskra.JSCore.JSObjectProxyFactory.GetProxy<global::Iskra.StdWeb.Event>(__res_527);

                string? __managedRes_530 = input(__arg_526);

                string? __marshalledValue_531;
                if (__managedRes_530 is null)
                {
                    __marshalledValue_531 = null;
                }
                else
                {
                    string __notNullable_532 = (string)__managedRes_530;
                    __marshalledValue_531 = __notNullable_532;
                }
                global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2AsNullable(__res_529, "value", __marshalledValue_531);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject __funcObj_528 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsNonVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(__funcObj_528, input); 

        return __funcObj_528;
    }
}

#nullable disable