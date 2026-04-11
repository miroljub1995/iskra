// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class AbstractRange: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public AbstractRange(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.Node StartContainer
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.Node, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "startContainer");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint StartOffset
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "startOffset");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.Node EndContainer
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.Node, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "endContainer");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public uint EndOffset
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<uint, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "endOffset");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool Collapsed
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "collapsed");
    }
}

#nullable disable