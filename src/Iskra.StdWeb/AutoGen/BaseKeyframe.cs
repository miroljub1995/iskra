// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class BaseKeyframe: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public BaseKeyframe(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public BaseKeyframe(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public double? Offset
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<double?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "offset");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<double?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "offset", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Easing
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "easing");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "easing", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.CompositeOperationOrAuto Composite
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.CompositeOperationOrAuto, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "composite");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.CompositeOperationOrAuto, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "composite", value);
    }
}

#nullable disable