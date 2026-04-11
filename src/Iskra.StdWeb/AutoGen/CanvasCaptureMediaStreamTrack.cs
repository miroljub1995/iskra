// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class CanvasCaptureMediaStreamTrack: global::Iskra.StdWeb.MediaStreamTrack
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public CanvasCaptureMediaStreamTrack(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.HTMLCanvasElement Canvas
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.HTMLCanvasElement, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "canvas");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public void RequestFrame()
    {
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallEmptyVoidFunctionProperty(JSObject, "requestFrame", JSObject);
    }
}

#nullable disable