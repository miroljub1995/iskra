// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class CSSFunctionDescriptors: global::Iskra.StdWeb.CSSStyleDeclaration
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public CSSFunctionDescriptors(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string Result
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "result");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "result", value);
    }
}

#nullable disable