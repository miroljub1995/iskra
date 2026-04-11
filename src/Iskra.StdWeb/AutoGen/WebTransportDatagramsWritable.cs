// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class WebTransportDatagramsWritable: global::Iskra.StdWeb.WritableStream
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public WebTransportDatagramsWritable(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.WebTransportSendGroup? SendGroup
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.WebTransportSendGroup?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "sendGroup");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.WebTransportSendGroup?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "sendGroup", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public long SendOrder
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<long, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "sendOrder");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<long, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "sendOrder", value);
    }
}

#nullable disable