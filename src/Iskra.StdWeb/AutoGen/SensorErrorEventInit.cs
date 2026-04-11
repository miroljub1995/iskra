// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class SensorErrorEventInit: global::Iskra.StdWeb.EventInit
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SensorErrorEventInit(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SensorErrorEventInit(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.StdWeb.DOMException Error
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.DOMException, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "error");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.DOMException, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "error", value);
    }
}

#nullable disable