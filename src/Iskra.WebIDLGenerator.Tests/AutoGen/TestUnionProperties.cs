// ReSharper disable All

namespace Iskra.WebIDLGenerator.Tests;

#nullable enable

public partial class TestUnionProperties: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public TestUnionProperties(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.Union<bool, int, string, global::Iskra.WebIDLGenerator.Tests.GenericMarshaller.Union> Value
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Union<bool, int, string, global::Iskra.WebIDLGenerator.Tests.GenericMarshaller.Union>, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "value");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.Union<bool, int, string, global::Iskra.WebIDLGenerator.Tests.GenericMarshaller.Union>, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(JSObject, "value", value);
    }
}

#nullable disable