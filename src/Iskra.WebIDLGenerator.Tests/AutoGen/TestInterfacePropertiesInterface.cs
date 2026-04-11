// ReSharper disable All

namespace Iskra.WebIDLGenerator.Tests;

#nullable enable

public partial class TestInterfacePropertiesInterface: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public TestInterfacePropertiesInterface(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int Value
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "value");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<int, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "value", value);
    }
}

#nullable disable