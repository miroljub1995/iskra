// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class RTCIceCandidatePair: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public RTCIceCandidatePair(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.RTCIceCandidate Local
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.RTCIceCandidate, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "local");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.RTCIceCandidate Remote
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.RTCIceCandidate, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "remote");
    }
}

#nullable disable