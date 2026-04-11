// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public partial class TestUtilsNamespace: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public TestUtilsNamespace(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Promise Gc()
    {
        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallEmptyNonVoidFunctionProperty(JSObject, "gc", JSObject, ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Promise, global::Iskra.StdWeb.PropertyAccessor>(___resOwner_1.JSObject, "value");
    }
}

public partial class ServiceWorkerGlobalScope
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.TestUtilsNamespace TestUtils => new global::Iskra.StdWeb.TestUtilsNamespace(global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(JSObject, "TestUtils"));
}

public partial class Window
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.TestUtilsNamespace TestUtils => new global::Iskra.StdWeb.TestUtilsNamespace(global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(JSObject, "TestUtils"));
}

public partial class DedicatedWorkerGlobalScope
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.TestUtilsNamespace TestUtils => new global::Iskra.StdWeb.TestUtilsNamespace(global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(JSObject, "TestUtils"));
}

public partial class RTCIdentityProviderGlobalScope
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.TestUtilsNamespace TestUtils => new global::Iskra.StdWeb.TestUtilsNamespace(global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(JSObject, "TestUtils"));
}

public partial class SharedWorkerGlobalScope
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.StdWeb.TestUtilsNamespace TestUtils => new global::Iskra.StdWeb.TestUtilsNamespace(global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2(JSObject, "TestUtils"));
}

#nullable disable