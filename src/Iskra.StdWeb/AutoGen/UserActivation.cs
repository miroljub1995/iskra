// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class UserActivation: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public UserActivation(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool HasBeenActive
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "hasBeenActive");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool IsActive
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isActive");
    }
}

#nullable disable