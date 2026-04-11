// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class InterestGroupScriptRunnerGlobalScope: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public InterestGroupScriptRunnerGlobalScope(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.PrivateAggregation? PrivateAggregation
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.PrivateAggregation?, global::Iskra.StdWeb.PropertyAccessorNullable>(JSObject, "privateAggregation");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.ProtectedAudienceUtilities ProtectedAudience
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.StdWeb.ProtectedAudienceUtilities, global::Iskra.StdWeb.PropertyAccessor>(JSObject, "protectedAudience");
    }
}

#nullable disable