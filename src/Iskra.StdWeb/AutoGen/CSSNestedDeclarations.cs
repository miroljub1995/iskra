// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class CSSNestedDeclarations: global::Iskra.StdWeb.CSSRule
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public CSSNestedDeclarations(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.CSSStyleProperties Style
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.CSSStyleProperties, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "style");
    }
}

#nullable disable