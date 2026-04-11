// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class Presentation: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public Presentation(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.PresentationRequest? DefaultRequest
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.PresentationRequest?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "defaultRequest");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.PresentationRequest?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "defaultRequest", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.PresentationReceiver? Receiver
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.PresentationReceiver?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "receiver");
    }
}

#nullable disable