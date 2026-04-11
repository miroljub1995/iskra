// ReSharper disable All

namespace Iskra.WebIDLGenerator.Tests;

#nullable enable

public partial class TestRecordLong: global::Iskra.JSCore.JSObjectProxy
{
    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public TestRecordLong(global::System.Runtime.InteropServices.JavaScript.JSObject obj): base(obj)
    {
    }

    [global::System.Runtime.Versioning.SupportedOSPlatform("browser")]
    public global::Iskra.JSCore.Generics.Record<int, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor> CreateTestRecordLong()
    {
        using global::Iskra.JSCore.FunctionResPool.Owner ___resOwner_1 = global::Iskra.JSCore.FunctionResPool.Shared.Rent();

        global::Iskra.JSCore.Extensions.JSFunctionExtensions.CallEmptyNonVoidFunctionProperty(JSObject, "createTestRecordLong", JSObject, ___resOwner_1.JSObject);

        // Return Value
        return global::Iskra.JSCore.Generics.PropertyAccessor.Get<global::Iskra.JSCore.Generics.Record<int, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>, global::Iskra.WebIDLGenerator.Tests.PropertyAccessor>(___resOwner_1.JSObject, "value");
    }
}

#nullable disable