// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class AudioSinkInfo: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public AudioSinkInfo(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.AudioSinkType Type
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.AudioSinkType, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "type");
    }
}

#nullable disable