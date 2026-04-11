// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class CSSFunctionDeclarations: global::Iskra.StdWeb.CSSRule
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public CSSFunctionDeclarations(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.CSSFunctionDescriptors Style
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.CSSFunctionDescriptors, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "style");
    }
}

#nullable disable