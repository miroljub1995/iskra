// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class MediaSessionActionDetails: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public MediaSessionActionDetails(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public MediaSessionActionDetails(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.StdWeb.MediaSessionAction Action
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.MediaSessionAction, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "action");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.MediaSessionAction, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "action", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double SeekOffset
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "seekOffset");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "seekOffset", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double SeekTime
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "seekTime");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "seekTime", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool FastSeek
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "fastSeek");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "fastSeek", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool IsActivating
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isActivating");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "isActivating", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.MediaSessionEnterPictureInPictureReason EnterPictureInPictureReason
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.MediaSessionEnterPictureInPictureReason, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "enterPictureInPictureReason");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.MediaSessionEnterPictureInPictureReason, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "enterPictureInPictureReason", value);
    }
}

#nullable disable