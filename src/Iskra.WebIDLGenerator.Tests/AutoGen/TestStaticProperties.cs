// ReSharper disable All

namespace Iskra.WebIDLGenerator.Tests;

#nullable enable

public partial class TestStaticProperties: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public TestStaticProperties(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public static int SimpleProp
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsConstructorProxy(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "TestStaticProperties"), "simpleProp");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<int, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsConstructorProxy(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, "TestStaticProperties"), "simpleProp", value);
    }
}

#nullable disable