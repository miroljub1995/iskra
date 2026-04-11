// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class MLTriangularOptions: global::Iskra.StdWeb.MLOperatorOptions
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public MLTriangularOptions(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public MLTriangularOptions(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public bool Upper
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "upper");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<bool, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "upper", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int Diagonal
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "diagonal");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<int, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "diagonal", value);
    }
}

#nullable disable