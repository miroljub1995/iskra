// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class SVGFEBlendElement: global::Iskra.StdWeb.SVGElement
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SVGFEBlendElement(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    public const ushort SVG_FEBLEND_MODE_UNKNOWN = 0;

    public const ushort SVG_FEBLEND_MODE_NORMAL = 1;

    public const ushort SVG_FEBLEND_MODE_MULTIPLY = 2;

    public const ushort SVG_FEBLEND_MODE_SCREEN = 3;

    public const ushort SVG_FEBLEND_MODE_DARKEN = 4;

    public const ushort SVG_FEBLEND_MODE_LIGHTEN = 5;

    public const ushort SVG_FEBLEND_MODE_OVERLAY = 6;

    public const ushort SVG_FEBLEND_MODE_COLOR_DODGE = 7;

    public const ushort SVG_FEBLEND_MODE_COLOR_BURN = 8;

    public const ushort SVG_FEBLEND_MODE_HARD_LIGHT = 9;

    public const ushort SVG_FEBLEND_MODE_SOFT_LIGHT = 10;

    public const ushort SVG_FEBLEND_MODE_DIFFERENCE = 11;

    public const ushort SVG_FEBLEND_MODE_EXCLUSION = 12;

    public const ushort SVG_FEBLEND_MODE_HUE = 13;

    public const ushort SVG_FEBLEND_MODE_SATURATION = 14;

    public const ushort SVG_FEBLEND_MODE_COLOR = 15;

    public const ushort SVG_FEBLEND_MODE_LUMINOSITY = 16;

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedString In1
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedString, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "in1");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedString In2
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedString, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "in2");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedEnumeration Mode
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedEnumeration, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "mode");
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