// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class CSSFontFaceRule: global::Iskra.StdWeb.CSSRule
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public CSSFontFaceRule(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.CSSFontFaceDescriptors Style
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.CSSFontFaceDescriptors, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "style");
    }
}

#nullable disable