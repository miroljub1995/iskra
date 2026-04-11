// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class WebGLShaderPrecisionFormat: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public WebGLShaderPrecisionFormat(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int RangeMin
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "rangeMin");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int RangeMax
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "rangeMax");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int Precision
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "precision");
    }
}

#nullable disable