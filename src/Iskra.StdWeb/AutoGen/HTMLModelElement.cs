// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class HTMLModelElement: global::Iskra.StdWeb.HTMLElement
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public HTMLModelElement(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.HTMLModelElement, global::Iskra.StdWeb.PropertyAccessor> Ready
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Promise<global::Iskra.StdWeb.HTMLModelElement, global::Iskra.StdWeb.PropertyAccessor>, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "ready");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.DOMPointReadOnly BoundingBoxCenter
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.DOMPointReadOnly, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "boundingBoxCenter");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.DOMPointReadOnly BoundingBoxExtents
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.DOMPointReadOnly, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "boundingBoxExtents");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.DOMMatrixReadOnly EntityTransform
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.DOMMatrixReadOnly, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "entityTransform");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.DOMMatrixReadOnly, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "entityTransform", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string EnvironmentMap
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "environmentMap");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "environmentMap", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Promise EnvironmentMapReady
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Promise, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "environmentMapReady");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string StageMode
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "stageMode");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "stageMode", value);
    }
}

#nullable disable