// ReSharper disable All

namespace Iskra.WebIDLGenerator.Tests;

#nullable enable

public partial class TestCallbackProperties: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public TestCallbackProperties(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.WebIDLGenerator.Tests.TestCallbackPropertiesCallback VoidCallback
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.WebIDLGenerator.Tests.TestCallbackPropertiesCallback, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "voidCallback");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.WebIDLGenerator.Tests.TestCallbackPropertiesCallback, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "voidCallback", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int CallVoidCallbackOnSet
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "callVoidCallbackOnSet");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<int, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "callVoidCallbackOnSet", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.WebIDLGenerator.Tests.TestCallbackPropertiesVariadicCallback VariadicCallback
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.WebIDLGenerator.Tests.TestCallbackPropertiesVariadicCallback, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "variadicCallback");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.WebIDLGenerator.Tests.TestCallbackPropertiesVariadicCallback, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "variadicCallback", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.JSArray<int, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor> CallVariadicCallbackOnSet
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.JSArray<int, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "callVariadicCallbackOnSet");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.JSArray<int, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "callVariadicCallbackOnSet", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.WebIDLGenerator.Tests.TestCallbackPropertiesNonVoidCallback NonVoidCallback
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.WebIDLGenerator.Tests.TestCallbackPropertiesNonVoidCallback, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "nonVoidCallback");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.WebIDLGenerator.Tests.TestCallbackPropertiesNonVoidCallback, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "nonVoidCallback", value);
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public int NonVoidCallbackCallAndGetResult
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<int, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "nonVoidCallbackCallAndGetResult");
    }
}

#nullable disable