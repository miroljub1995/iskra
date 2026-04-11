// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class SVGComponentTransferFunctionElement: global::Iskra.StdWeb.SVGElement
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SVGComponentTransferFunctionElement(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    public const ushort SVG_FECOMPONENTTRANSFER_TYPE_UNKNOWN = 0;

    public const ushort SVG_FECOMPONENTTRANSFER_TYPE_IDENTITY = 1;

    public const ushort SVG_FECOMPONENTTRANSFER_TYPE_TABLE = 2;

    public const ushort SVG_FECOMPONENTTRANSFER_TYPE_DISCRETE = 3;

    public const ushort SVG_FECOMPONENTTRANSFER_TYPE_LINEAR = 4;

    public const ushort SVG_FECOMPONENTTRANSFER_TYPE_GAMMA = 5;

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedEnumeration Type
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedEnumeration, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "type");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedNumberList TableValues
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedNumberList, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "tableValues");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedNumber Slope
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedNumber, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "slope");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedNumber Intercept
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedNumber, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "intercept");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedNumber Amplitude
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedNumber, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "amplitude");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedNumber Exponent
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedNumber, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "exponent");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedNumber Offset
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedNumber, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "offset");
    }
}

#nullable disable