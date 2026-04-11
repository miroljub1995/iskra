// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class RTCReceivedRtpStreamStats: global::Iskra.StdWeb.RTCRtpStreamStats
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public RTCReceivedRtpStreamStats(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public RTCReceivedRtpStreamStats(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ulong PacketsReceived
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ulong, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "packetsReceived");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<ulong, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "packetsReceived", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ulong PacketsReceivedWithEct1
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ulong, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "packetsReceivedWithEct1");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<ulong, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "packetsReceivedWithEct1", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ulong PacketsReceivedWithCe
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ulong, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "packetsReceivedWithCe");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<ulong, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "packetsReceivedWithCe", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ulong PacketsReportedAsLost
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ulong, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "packetsReportedAsLost");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<ulong, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "packetsReportedAsLost", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ulong PacketsReportedAsLostButRecovered
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ulong, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "packetsReportedAsLostButRecovered");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<ulong, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "packetsReportedAsLostButRecovered", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public long PacketsLost
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<long, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "packetsLost");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<long, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "packetsLost", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double Jitter
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "jitter");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "jitter", value);
    }
}

#nullable disable