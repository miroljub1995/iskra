// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class HTMLAudioElement: global::Iskra.StdWeb.HTMLMediaElement
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public HTMLAudioElement(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatformAttribute("browser")]
    public static global::Iskra.StdWeb.HTMLAudioElement New()
    {
        global::System.Runtime.InteropServices.JavaScript.JSObject ___res_2 = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "HTMLAudioElement");
        return new global::Iskra.StdWeb.HTMLAudioElement(___res_2);
    }
}

#nullable disable