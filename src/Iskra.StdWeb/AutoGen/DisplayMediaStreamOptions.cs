// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class DisplayMediaStreamOptions: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public DisplayMediaStreamOptions(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public DisplayMediaStreamOptions(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.Union<bool, global::Iskra.StdWeb.MediaTrackConstraints, global::Iskra.StdWeb.GenericMarshaller.Union> Video
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Union<bool, global::Iskra.StdWeb.MediaTrackConstraints, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "video");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.Union<bool, global::Iskra.StdWeb.MediaTrackConstraints, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "video", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.Union<bool, global::Iskra.StdWeb.MediaTrackConstraints, global::Iskra.StdWeb.GenericMarshaller.Union> Audio
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Union<bool, global::Iskra.StdWeb.MediaTrackConstraints, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "audio");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.Union<bool, global::Iskra.StdWeb.MediaTrackConstraints, global::Iskra.StdWeb.GenericMarshaller.Union>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "audio", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.CaptureController Controller
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.CaptureController, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "controller");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.CaptureController, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "controller", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SelfCapturePreferenceEnum SelfBrowserSurface
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SelfCapturePreferenceEnum, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "selfBrowserSurface");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.SelfCapturePreferenceEnum, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "selfBrowserSurface", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SystemAudioPreferenceEnum SystemAudio
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SystemAudioPreferenceEnum, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "systemAudio");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.SystemAudioPreferenceEnum, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "systemAudio", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.WindowAudioPreferenceEnum WindowAudio
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.WindowAudioPreferenceEnum, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "windowAudio");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.WindowAudioPreferenceEnum, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "windowAudio", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SurfaceSwitchingPreferenceEnum SurfaceSwitching
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SurfaceSwitchingPreferenceEnum, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "surfaceSwitching");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.SurfaceSwitchingPreferenceEnum, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "surfaceSwitching", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.MonitorTypeSurfacesEnum MonitorTypeSurfaces
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.MonitorTypeSurfacesEnum, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "monitorTypeSurfaces");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.MonitorTypeSurfacesEnum, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "monitorTypeSurfaces", value);
    }
}

#nullable disable