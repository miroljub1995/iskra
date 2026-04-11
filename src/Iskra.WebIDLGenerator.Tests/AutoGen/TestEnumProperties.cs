// ReSharper disable All

namespace Iskra.WebIDLGenerator.Tests;

#nullable enable

public partial class TestEnumProperties: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public TestEnumProperties(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.WebIDLGenerator.Tests.TestEnumPropertiesEnum Value
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.WebIDLGenerator.Tests.TestEnumPropertiesEnum, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "value");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.WebIDLGenerator.Tests.TestEnumPropertiesEnum, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "value", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.WebIDLGenerator.Tests.TestEnumPropertiesEnum? ValueNullable
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.WebIDLGenerator.Tests.TestEnumPropertiesEnum?, global::Iskra.WebIDLGenerator.Tests.PropertyAccessorNullable>(JSObject, "valueNullable");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.WebIDLGenerator.Tests.TestEnumPropertiesEnum?, global::Iskra.WebIDLGenerator.Tests.PropertyAccessorNullable>(JSObject, "valueNullable", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.WebIDLGenerator.Tests.TestEnumPropertiesEnum? ValueNullableReadonlyAsNotNull
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.WebIDLGenerator.Tests.TestEnumPropertiesEnum?, global::Iskra.WebIDLGenerator.Tests.PropertyAccessorNullable>(JSObject, "valueNullableReadonlyAsNotNull");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.WebIDLGenerator.Tests.TestEnumPropertiesEnum? ValueNullableReadonlyAsNull
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.WebIDLGenerator.Tests.TestEnumPropertiesEnum?, global::Iskra.WebIDLGenerator.Tests.PropertyAccessorNullable>(JSObject, "valueNullableReadonlyAsNull");
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.WebIDLGenerator.Tests.TestEnumPropertiesEnum? ValueInvalid
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.WebIDLGenerator.Tests.TestEnumPropertiesEnum?, global::Iskra.WebIDLGenerator.Tests.PropertyAccessorNullable>(JSObject, "valueInvalid");
    }
}

#nullable disable