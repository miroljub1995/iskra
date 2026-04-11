// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class IntrinsicSizes: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public IntrinsicSizes(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double MinContentSize
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "minContentSize");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double MaxContentSize
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "maxContentSize");
    }
}

#nullable disable