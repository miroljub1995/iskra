// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class SaveFilePickerOptions: global::Iskra.StdWeb.FilePickerOptions
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SaveFilePickerOptions(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public SaveFilePickerOptions(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public string? SuggestedName
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "suggestedName");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<string?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "suggestedName", value);
    }
}

#nullable disable