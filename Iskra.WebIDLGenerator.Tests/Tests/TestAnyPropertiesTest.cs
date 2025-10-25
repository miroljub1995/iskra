using System.Numerics;
using System.Runtime.InteropServices.JavaScript;

namespace Iskra.WebIDLGenerator.Tests.Tests;

public partial class TestAnyPropertiesTest() : BaseTest<TestAnyProperties>("testAnyProperties")
{
    [JSImport("construct", "iskra")]
    private static partial JSObject ConstructAsObject(JSObject obj, string constructorName);

    [Test]
    public async Task TestAnyPropertyGetDouble()
    {
        var sut = GetSut();

        await Assert.That(sut.AnyValue).IsNotNull();
        await Assert.That(sut.AnyValue!.TryCast(out double val)).IsTrue();
        await Assert.That(val).IsEqualTo(123.45);
    }

    [Test]
    public async Task TestAnyPropertySetAndGetDouble()
    {
        var sut = GetSut();

        sut.AnyValue = 543.21;

        await Assert.That(sut.AnyValue).IsNotNull();
        await Assert.That(sut.AnyValue!.TryCast(out double val)).IsTrue();
        await Assert.That(val).IsEqualTo(543.21);
    }

    [Test]
    public async Task TestAnyPropertySetAndGetBool()
    {
        var sut = GetSut();

        sut.AnyValue = true;

        await Assert.That(sut.AnyValue).IsNotNull();
        await Assert.That(sut.AnyValue.TryCast(out bool val)).IsTrue();
        await Assert.That(val).IsTrue();
    }

    [Test]
    public async Task TestAnyPropertySetAndGetString()
    {
        var sut = GetSut();

        sut.AnyValue = "this is some string";

        await Assert.That(sut.AnyValue).IsNotNull();
        await Assert.That(sut.AnyValue.TryCast(out string? val)).IsTrue();
        await Assert.That(val).IsEqualTo("this is some string");
    }

    [Test]
    public async Task TestAnyPropertySetAndGetJSObject()
    {
        var sut = GetSut();

        var obj = ConstructAsObject(JSHost.GlobalThis, "Object");
        sut.AnyValue = obj;

        await Assert.That(sut.AnyValue).IsNotNull();
        await Assert.That(sut.AnyValue.TryCast(out JSObject? val)).IsTrue();
        await Assert.That(val).IsEqualTo(obj);
    }

    [Test]
    public async Task TestAnyPropertySetAndGetManagedObject()
    {
        var sut = GetSut();

        var obj = new object();
        sut.AnyValue = obj;

        await Assert.That(sut.AnyValue).IsNotNull();
        await Assert.That(sut.AnyValue.TryCast(out object? val)).IsTrue();
        await Assert.That(val).IsSameReferenceAs(obj);
    }
}