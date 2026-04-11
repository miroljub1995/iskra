// ReSharper disable All

namespace Iskra.WebIDLGenerator.Tests;

#nullable enable

public partial class TestObservableArrayProperties: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public TestObservableArrayProperties(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.ObservableArray<bool, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor> BoolObservableArray
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.ObservableArray<bool, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "boolObservableArray");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.ObservableArray<bool, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "boolObservableArray", value);
    }
}

#nullable disable