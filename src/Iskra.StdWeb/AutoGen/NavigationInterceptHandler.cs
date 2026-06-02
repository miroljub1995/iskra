// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public delegate global::Iskra.JSCore.Promise NavigationInterceptHandlerManaged();

public partial class NavigationInterceptHandler: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public NavigationInterceptHandler(global::System.Runtime.InteropServices.JavaScript.JSObject obj) : base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public NavigationInterceptHandler(NavigationInterceptHandlerManaged input): this(ToJSObject(input))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static implicit operator NavigationInterceptHandler(NavigationInterceptHandlerManaged input)
    {
        return new global::Iskra.StdWeb.NavigationInterceptHandler(ToJSObject(input));
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool TryGetManaged([global::System.Diagnostics.CodeAnalysis.NotNullWhenAttribute(true)] out global::Iskra.StdWeb.NavigationInterceptHandlerManaged? managed, bool allowConversion = false)
    {
        managed = global::Iskra.JSCore.Extensions.JSFunctionExtensions.GetManagedFunctionFromProperty(JSObject) as global::Iskra.StdWeb.NavigationInterceptHandlerManaged;
        if (managed is not null)
        {
            return true;
        }

        if (!allowConversion)
        {
            return false;
        }

        managed = () =>
        {


            using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

            global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallEmptyNonVoidFunction(JSObject, null, ___resOwner_1.JSObject);

            // Return Value
            global::Iskra.JSCore.Promise ___res_2;
            global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_3;
            ___propObject_3 = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(___resOwner_1.JSObject, "value");
            ___res_2 = new global::Iskra.JSCore.Promise(___propObject_3);
            return ___res_2;
        };
        return true;
    }
    
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    private static global::System.Runtime.InteropServices.JavaScript.JSObject ToJSObject(NavigationInterceptHandlerManaged input)
    {
        Action<global::System.Runtime.InteropServices.JavaScript.JSObject, global::System.Runtime.InteropServices.JavaScript.JSObject> callback = (___args_0, ___res_3) =>
        {
            using (___args_0)
            using (___res_3)
            {


                global::Iskra.JSCore.Promise ___managedRes_4 = input();

                global::System.Runtime.InteropServices.JavaScript.JSObject ___propObject_5 = ___managedRes_4.JSObject;
                global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___res_3, "value", ___propObject_5);
            }
        };

        global::System.Runtime.InteropServices.JavaScript.JSObject ___funcObj_2 = global::Iskra.JSCore.Extensions.JSFunctionExtensions.WrapAsNonVoidFunction(callback);
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.StoreManagedFunctionToProperty(___funcObj_2, input); 

        return ___funcObj_2;
    }
}

#nullable disable