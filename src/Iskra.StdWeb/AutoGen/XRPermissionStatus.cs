// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class XRPermissionStatus: global::Iskra.StdWeb.PermissionStatus
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XRPermissionStatus(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.FrozenArray<string, global::Iskra.StdWeb.PropertyAccessor> Granted
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.FrozenArray<string, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "granted");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.FrozenArray<string, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "granted", value);
    }
}

#nullable disable