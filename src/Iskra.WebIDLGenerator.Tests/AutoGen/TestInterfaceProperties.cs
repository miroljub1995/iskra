// ReSharper disable All

namespace Iskra.WebIDLGenerator.Tests;

#nullable enable

public partial class TestInterfaceProperties: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public TestInterfaceProperties(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.WebIDLGenerator.Tests.TestInterfacePropertiesInterface Value
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.WebIDLGenerator.Tests.TestInterfacePropertiesInterface, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "value");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.WebIDLGenerator.Tests.TestInterfacePropertiesInterface, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "value", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.WebIDLGenerator.Tests.TestInterfacePropertiesInterface? ValueNullable
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.WebIDLGenerator.Tests.TestInterfacePropertiesInterface?, global::Iskra.WebIDLGenerator.Tests.PropertyAccessorNullable>(JSObject, "valueNullable");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.WebIDLGenerator.Tests.TestInterfacePropertiesInterface?, global::Iskra.WebIDLGenerator.Tests.PropertyAccessorNullable>(JSObject, "valueNullable", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.WebIDLGenerator.Tests.TestInterfacePropertiesInterface? ValueNullableReadonlyAsNotNull
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.WebIDLGenerator.Tests.TestInterfacePropertiesInterface?, global::Iskra.WebIDLGenerator.Tests.PropertyAccessorNullable>(JSObject, "valueNullableReadonlyAsNotNull");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.WebIDLGenerator.Tests.TestInterfacePropertiesInterface? ValueNullableReadonlyAsNull
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.WebIDLGenerator.Tests.TestInterfacePropertiesInterface?, global::Iskra.WebIDLGenerator.Tests.PropertyAccessorNullable>(JSObject, "valueNullableReadonlyAsNull");
    }
}

#nullable disable