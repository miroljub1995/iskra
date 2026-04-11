// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class SnapEventInit: global::Iskra.StdWeb.EventInit
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SnapEventInit(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SnapEventInit(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.Node? SnapTargetBlock
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.Node?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "snapTargetBlock");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.Node?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "snapTargetBlock", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.Node? SnapTargetInline
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.Node?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "snapTargetInline");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.Node?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "snapTargetInline", value);
    }
}

#nullable disable