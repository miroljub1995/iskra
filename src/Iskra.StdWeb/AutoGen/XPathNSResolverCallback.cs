// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public delegate string? XPathNSResolverCallbackManaged(string? prefix);

public partial class XPathNSResolverCallback: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XPathNSResolverCallback(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XPathNSResolverCallback(XPathNSResolverCallbackManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator XPathNSResolverCallback(XPathNSResolverCallbackManaged input)
    {
        return new global::Iskra.StdWeb.XPathNSResolverCallback(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.StdWeb.XPathNSResolverCallbackManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.StdWeb.XPathNSResolverCallbackManaged;
        if (managed is not null)
        {
            return true;
        }

        if (!allowConversion)
        {
            return false;
        }

        managed = (prefix) =>
        {
            int ___argsArrayLength_3 = 1;

            using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_3);

            // Argument 1
            string? ___marshalledValue_4;
            if (prefix is null)
            {
                ___marshalledValue_4 = null;
            }
            else
            {
                string ___notNullable_5 = (string)prefix;
                ___marshalledValue_4 = ___notNullable_5;
            }
            global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2AsNullable(___argsArray_0.JSObject, 0, ___marshalledValue_4);

            using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

            global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyNonVoidFunction(JSObject, null, ___argsArray_0.JSObject, ___resOwner_1.JSObject);

            // Return Value
            string? ___res_2;
            string? ___res_6 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsStringV2AsNullable(___resOwner_1.JSObject, "value");
            if (___res_6 is null)
            {
                ___res_2 = null;
            }
            else
            {
                string ___notNullable_7 = (string)___res_6;
                ___res_2 = ___notNullable_7;
            }
            return ___res_2;
        };
        return true;
    }
    
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(XPathNSResolverCallbackManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject, global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (___args_0, ___res_6) =>
        {
            using (___args_0)
            using (___res_6)
            {
                // Argument 1
                string? ___arg_2;
                string? ___res_3 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsStringV2AsNullable(___args_0, 0);
                if (___res_3 is null)
                {
                    ___arg_2 = null;
                }
                else
                {
                    string ___notNullable_4 = (string)___res_3;
                    ___arg_2 = ___notNullable_4;
                }

                string? ___managedRes_7 = input(___arg_2);

                string? ___marshalledValue_8;
                if (___managedRes_7 is null)
                {
                    ___marshalledValue_8 = null;
                }
                else
                {
                    string ___notNullable_9 = (string)___managedRes_7;
                    ___marshalledValue_8 = ___notNullable_9;
                }
                global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2AsNullable(___res_6, "value", ___marshalledValue_8);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject ___funcObj_5 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsNonVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(___funcObj_5, input); 

        return ___funcObj_5;
    }
}

#nullable disable