// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class SVGFEGaussianBlurElement: global::Iskra.StdWeb.SVGElement
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SVGFEGaussianBlurElement(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    public const ushort SVG_EDGEMODE_UNKNOWN = 0;

    public const ushort SVG_EDGEMODE_DUPLICATE = 1;

    public const ushort SVG_EDGEMODE_WRAP = 2;

    public const ushort SVG_EDGEMODE_NONE = 3;

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedString In1
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedString, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "in1");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedNumber StdDeviationX
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedNumber, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "stdDeviationX");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedNumber StdDeviationY
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedNumber, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "stdDeviationY");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.SVGAnimatedEnumeration EdgeMode
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.SVGAnimatedEnumeration, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "edgeMode");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public void SetStdDeviation(float stdDeviationX, float stdDeviationY)
    {
        int ___argsArrayLength_2 = 2;

        using global::Iskra.JSCore.ArgsArrayPool.Owner ___argsArray_0 = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent(___argsArrayLength_2);

        // Argument 1
        double ___marshalledValue_3;
        ___marshalledValue_3 = Convert.ToDouble(stdDeviationX);
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsDoubleV2(___argsArray_0.JSObject, 0, ___marshalledValue_3);

        // Argument 2
        double ___marshalledValue_4;
        ___marshalledValue_4 = Convert.ToDouble(stdDeviationY);
        global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsDoubleV2(___argsArray_0.JSObject, 1, ___marshalledValue_4);

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallNonEmptyVoidFunctionProperty(JSObject, "setStdDeviation", JSObject, ___argsArray_0.JSObject);
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