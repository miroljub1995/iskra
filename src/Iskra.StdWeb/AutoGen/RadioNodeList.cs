// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class RadioNodeList: global::Iskra.StdWeb.NodeList
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public RadioNodeList(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Value
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "value");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "value", value);
    }
}

#nullable disable