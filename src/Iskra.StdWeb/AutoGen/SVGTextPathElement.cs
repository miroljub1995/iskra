// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class SVGTextPathElement: global::Iskra.StdWeb.SVGTextContentElement
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SVGTextPathElement(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    public const ushort TEXTPATH_METHODTYPE_UNKNOWN = 0;

    public const ushort TEXTPATH_METHODTYPE_ALIGN = 1;

    public const ushort TEXTPATH_METHODTYPE_STRETCH = 2;

    public const ushort TEXTPATH_SPACINGTYPE_UNKNOWN = 0;

    public const ushort TEXTPATH_SPACINGTYPE_AUTO = 1;

    public const ushort TEXTPATH_SPACINGTYPE_EXACT = 2;

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedLength StartOffset
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedLength, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "startOffset");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedEnumeration Method
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedEnumeration, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "method");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedEnumeration Spacing
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedEnumeration, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "spacing");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedString Href
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedString, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "href");
    }
}

#nullable disable