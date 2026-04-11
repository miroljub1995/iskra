// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class RTCConfiguration: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public RTCConfiguration(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public RTCConfiguration(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.RTCIceServer, global::Iskra.StdWeb.PropertyAccessor> IceServers
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.RTCIceServer, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "iceServers");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.RTCIceServer, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "iceServers", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.RTCIceTransportPolicy IceTransportPolicy
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.RTCIceTransportPolicy, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "iceTransportPolicy");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.RTCIceTransportPolicy, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "iceTransportPolicy", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.RTCBundlePolicy BundlePolicy
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.RTCBundlePolicy, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "bundlePolicy");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.RTCBundlePolicy, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "bundlePolicy", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.RTCRtcpMuxPolicy RtcpMuxPolicy
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.RTCRtcpMuxPolicy, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "rtcpMuxPolicy");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.RTCRtcpMuxPolicy, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "rtcpMuxPolicy", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.RTCCertificate, global::Iskra.StdWeb.PropertyAccessor> Certificates
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.RTCCertificate, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "certificates");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.JSArray<global::Iskra.StdWeb.RTCCertificate, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "certificates", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public byte IceCandidatePoolSize
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<byte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "iceCandidatePoolSize");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<byte, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "iceCandidatePoolSize", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string PeerIdentity
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "peerIdentity");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "peerIdentity", value);
    }
}

#nullable disable