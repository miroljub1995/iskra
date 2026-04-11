// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class RTCDataChannelStats: global::Iskra.StdWeb.RTCStats
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public RTCDataChannelStats(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public RTCDataChannelStats(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Label
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "label");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "label", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Protocol
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "protocol");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "protocol", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ushort DataChannelIdentifier
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ushort, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "dataChannelIdentifier");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<ushort, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "dataChannelIdentifier", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.StdWeb.RTCDataChannelState State
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.RTCDataChannelState, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "state");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.RTCDataChannelState, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "state", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint MessagesSent
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "messagesSent");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "messagesSent", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ulong BytesSent
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ulong, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "bytesSent");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<ulong, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "bytesSent", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint MessagesReceived
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "messagesReceived");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "messagesReceived", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public ulong BytesReceived
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<ulong, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "bytesReceived");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<ulong, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "bytesReceived", value);
    }
}

#nullable disable