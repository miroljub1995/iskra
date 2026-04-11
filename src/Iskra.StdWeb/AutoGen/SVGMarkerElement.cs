// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class SVGMarkerElement: global::Iskra.StdWeb.SVGElement
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SVGMarkerElement(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    public const ushort SVG_MARKERUNITS_UNKNOWN = 0;

    public const ushort SVG_MARKERUNITS_USERSPACEONUSE = 1;

    public const ushort SVG_MARKERUNITS_STROKEWIDTH = 2;

    public const ushort SVG_MARKER_ORIENT_UNKNOWN = 0;

    public const ushort SVG_MARKER_ORIENT_AUTO = 1;

    public const ushort SVG_MARKER_ORIENT_ANGLE = 2;

    public const ushort SVG_MARKER_ORIENT_AUTO_START_REVERSE = 3;

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedLength RefX
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedLength, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "refX");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedLength RefY
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedLength, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "refY");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedEnumeration MarkerUnits
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedEnumeration, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "markerUnits");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedLength MarkerWidth
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedLength, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "markerWidth");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedLength MarkerHeight
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedLength, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "markerHeight");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedEnumeration OrientType
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedEnumeration, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "orientType");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedAngle OrientAngle
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedAngle, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "orientAngle");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Orient
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "orient");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "orient", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public void SetOrientToAuto()
    {
        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallEmptyVoidFunctionProperty(JSObject, "setOrientToAuto", JSObject);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public void SetOrientToAngle(global::Iskra.StdWeb.SVGAngle angle)
    {
        int ___argsArrayLength_2 = 1;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_2);

        // Argument 1
        global::System.Runtime.InteropServices.JavaScript.JSObject ___marshalledValue_3;
        ___marshalledValue_3 = angle.JSObject;
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2(___argsArray_0.JSObject, 0, ___marshalledValue_3);

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyVoidFunctionProperty(JSObject, "setOrientToAngle", JSObject, ___argsArray_0.JSObject);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedRect ViewBox
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedRect, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "viewBox");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedPreserveAspectRatio PreserveAspectRatio
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedPreserveAspectRatio, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "preserveAspectRatio");
    }
}

#nullable disable