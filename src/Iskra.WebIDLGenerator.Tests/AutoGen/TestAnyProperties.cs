// ReSharper disable All

namespace Iskra.WebIDLGenerator.Tests;

#nullable enable

public partial class TestAnyProperties: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public TestAnyProperties(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.WebIDLGenerator.Tests.GenericMarshaller.Union>? AnyValue
    {
        get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.WebIDLGenerator.Tests.GenericMarshaller.Union>?, global::Iskra.WebIDLGenerator.Tests.PropertyAccessorNullable>(JSObject, "anyValue");
        set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<global::Iskra.JSCore.Generics.Union<double, global::System.Numerics.BigInteger, string, bool, global::System.Runtime.InteropServices.JavaScript.JSObject, object, global::Iskra.WebIDLGenerator.Tests.GenericMarshaller.Union>?, global::Iskra.WebIDLGenerator.Tests.PropertyAccessorNullable>(JSObject, "anyValue", value);
    }
}

#nullable disable