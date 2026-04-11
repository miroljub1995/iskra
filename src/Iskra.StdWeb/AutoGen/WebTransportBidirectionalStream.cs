// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class WebTransportBidirectionalStream: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public WebTransportBidirectionalStream(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.WebTransportReceiveStream Readable
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.WebTransportReceiveStream, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "readable");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.WebTransportSendStream Writable
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.WebTransportSendStream, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "writable");
    }
}

#nullable disable