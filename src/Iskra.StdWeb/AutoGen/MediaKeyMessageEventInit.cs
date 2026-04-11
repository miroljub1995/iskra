// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class MediaKeyMessageEventInit: global::Iskra.StdWeb.EventInit
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public MediaKeyMessageEventInit(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public MediaKeyMessageEventInit(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.StdWeb.MediaKeyMessageType MessageType
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.MediaKeyMessageType, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "messageType");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.MediaKeyMessageType, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "messageType", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.JSCore.ArrayBuffer Message
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.ArrayBuffer, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "message");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.ArrayBuffer, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "message", value);
    }
}

#nullable disable