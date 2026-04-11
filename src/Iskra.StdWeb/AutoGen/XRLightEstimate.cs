// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class XRLightEstimate: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XRLightEstimate(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Float32Array SphericalHarmonicsCoefficients
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Float32Array, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "sphericalHarmonicsCoefficients");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.DOMPointReadOnly PrimaryLightDirection
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.DOMPointReadOnly, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "primaryLightDirection");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.DOMPointReadOnly PrimaryLightIntensity
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.DOMPointReadOnly, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "primaryLightIntensity");
    }
}

#nullable disable