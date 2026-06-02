// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class LanguageModelTool: global::Iskra.JSCore.JSObjectProxy
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public LanguageModelTool(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public LanguageModelTool(): base(global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "Object"))
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required string Name
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "name");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "name", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required string Description
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "description");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "description", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::System.Runtime.InteropServices.JavaScript.JSObject InputSchema
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::System.Runtime.InteropServices.JavaScript.JSObject, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "inputSchema");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::System.Runtime.InteropServices.JavaScript.JSObject, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "inputSchema", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.StdWeb.LanguageModelToolFunction Execute
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.LanguageModelToolFunction, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "execute");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.LanguageModelToolFunction, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "execute", value);
    }
}

#nullable disable