// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class XRTransientInputHitTestResult: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public XRTransientInputHitTestResult(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.XRInputSource InputSource
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.XRInputSource, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "inputSource");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.XRHitTestResult, global::Iskra.StdWeb.PropertyAccessor> Results
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.FrozenArray<global::Iskra.StdWeb.XRHitTestResult, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "results");
    }
}

#nullable disable