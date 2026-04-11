// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class BackgroundFetchEventInit: global::Iskra.StdWeb.ExtendableEventInit
{
#pragma warning disable CS8618 // When constructing using obj, we assume that all members are initialized.
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public BackgroundFetchEventInit(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }
#pragma warning restore CS8618

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public BackgroundFetchEventInit(): base()
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public required global::Iskra.StdWeb.BackgroundFetchRegistration Registration
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.BackgroundFetchRegistration, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "registration");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.StdWeb.BackgroundFetchRegistration, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "registration", value);
    }
}

#nullable disable