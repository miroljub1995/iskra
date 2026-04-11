// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class RTCTransformEvent: global::Iskra.StdWeb.Event
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public RTCTransformEvent(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.RTCRtpScriptTransformer Transformer
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.RTCRtpScriptTransformer, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "transformer");
    }
}

#nullable disable