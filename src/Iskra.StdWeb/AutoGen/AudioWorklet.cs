// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class AudioWorklet: global::Iskra.StdWeb.Worklet
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public AudioWorklet(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.MessagePort Port
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.MessagePort, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "port");
    }
}

#nullable disable