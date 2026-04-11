// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class SVGFETurbulenceElement: global::Iskra.StdWeb.SVGElement
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SVGFETurbulenceElement(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    public const ushort SVG_TURBULENCE_TYPE_UNKNOWN = 0;

    public const ushort SVG_TURBULENCE_TYPE_FRACTALNOISE = 1;

    public const ushort SVG_TURBULENCE_TYPE_TURBULENCE = 2;

    public const ushort SVG_STITCHTYPE_UNKNOWN = 0;

    public const ushort SVG_STITCHTYPE_STITCH = 1;

    public const ushort SVG_STITCHTYPE_NOSTITCH = 2;

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedNumber BaseFrequencyX
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedNumber, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "baseFrequencyX");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedNumber BaseFrequencyY
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedNumber, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "baseFrequencyY");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedInteger NumOctaves
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedInteger, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "numOctaves");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedNumber Seed
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedNumber, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "seed");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedEnumeration StitchTiles
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedEnumeration, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "stitchTiles");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedEnumeration Type
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedEnumeration, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "type");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedLength X
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedLength, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "x");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedLength Y
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedLength, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "y");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedLength Width
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedLength, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "width");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedLength Height
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedLength, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "height");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedString Result
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedString, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "result");
    }
}

#nullable disable