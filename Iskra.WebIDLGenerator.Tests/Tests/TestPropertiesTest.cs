using System.Runtime.InteropServices.JavaScript;
using Iskra.JSCore;

namespace Iskra.WebIDLGenerator.Tests.Tests;

public class TestPropertiesTest() : BaseTest<TestProperties>("testProperties")
{
    [Before(Class)]
    public static void Before()
    {
        WebIDLGeneratorTestsProxyFactory.Initialize();
    }

    // Int
    [Test]
    public async Task TestIntProperty()
    {
        var sut = GetSut();

        await Assert.That(sut.IntProperty).IsEqualTo(1);
        sut.IntProperty = 3;
        await Assert.That(sut.IntProperty).IsEqualTo(3);
    }

    [Test]
    public async Task TestReadOnlyIntProperty()
    {
        var sut = GetSut();

        await Assert.That(sut.IntPropertyReadOnly).IsEqualTo(2);
        await Assert.That(PropertyIsReadOnly(nameof(TestProperties.IntPropertyReadOnly))).IsTrue();
    }

    [Test]
    public async Task TestIntPropertyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.IntPropertyNullable).IsEqualTo(null);
        sut.IntPropertyNullable = 1;
        await Assert.That(sut.IntPropertyNullable).IsEqualTo(1);
    }

    [Test]
    public async Task TestIntPropertyReadOnlyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.IntPropertyReadOnlyNullableAsNull).IsEqualTo(null);
        await Assert.That(sut.IntPropertyReadOnlyNullableAsNotNull).IsEqualTo(3);
    }

    // Double
    [Test]
    public async Task TestDoubleProperty()
    {
        var sut = GetSut();

        await Assert.That(sut.DoubleProperty).IsEqualTo(1.2);
        sut.DoubleProperty = 3.4;
        await Assert.That(sut.DoubleProperty).IsEqualTo(3.4);
    }

    [Test]
    public async Task TestReadOnlyDoubleProperty()
    {
        var sut = GetSut();

        await Assert.That(sut.DoublePropertyReadOnly).IsEqualTo(2.3);
        await Assert.That(PropertyIsReadOnly(nameof(TestProperties.DoublePropertyReadOnly))).IsTrue();
    }

    [Test]
    public async Task TestDoublePropertyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.DoublePropertyNullable).IsEqualTo(null);
        sut.DoublePropertyNullable = 1.2;
        await Assert.That(sut.DoublePropertyNullable).IsEqualTo(1.2);
    }

    [Test]
    public async Task TestDoublePropertyReadOnlyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.DoublePropertyReadOnlyNullableAsNull).IsEqualTo(null);
        await Assert.That(sut.DoublePropertyReadOnlyNullableAsNotNull).IsEqualTo(2.4);
    }

    // Bool
    [Test]
    public async Task TestBoolPropertyGet()
    {
        var sut = GetSut();

        await Assert.That(sut.BoolProperty).IsEqualTo(true);
        sut.BoolProperty = false;
        await Assert.That(sut.BoolProperty).IsEqualTo(false);
    }

    [Test]
    public async Task TestReadOnlyBoolProperty()
    {
        var sut = GetSut();

        await Assert.That(sut.BoolPropertyReadOnly).IsEqualTo(true);
        await Assert.That(PropertyIsReadOnly(nameof(TestProperties.BoolPropertyReadOnly))).IsTrue();
    }

    [Test]
    public async Task BoolPropertyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.BoolPropertyNullable).IsEqualTo(null);
        sut.BoolPropertyNullable = true;
        await Assert.That(sut.BoolPropertyNullable).IsEqualTo(true);
        sut.BoolPropertyNullable = false;
        await Assert.That(sut.BoolPropertyNullable).IsEqualTo(false);
    }

    [Test]
    public async Task BoolPropertyReadOnlyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.BoolPropertyReadOnlyNullableAsNull).IsEqualTo(null);
        await Assert.That(sut.BoolPropertyReadOnlyNullableAsTrue).IsEqualTo(true);
        await Assert.That(sut.BoolPropertyReadOnlyNullableAsFalse).IsEqualTo(false);
    }

    // String
    [Test]
    public async Task TestStringPropertyGet()
    {
        var sut = GetSut();

        await Assert.That(sut.StringProperty).IsEqualTo("string property");
        sut.StringProperty = "set string property";
        await Assert.That(sut.StringProperty).IsEqualTo("set string property");
    }

    [Test]
    public async Task TestReadOnlyStringPropertyGet()
    {
        var sut = GetSut();

        await Assert.That(sut.StringPropertyReadOnly).IsEqualTo("string property read only");
        await Assert.That(PropertyIsReadOnly(nameof(TestProperties.StringPropertyReadOnly))).IsTrue();
    }

    [Test]
    public async Task TestStringPropertyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.StringPropertyNullable).IsEqualTo(null);
        sut.StringPropertyNullable = "some new string";
        await Assert.That(sut.StringPropertyNullable).IsEqualTo("some new string");
        sut.StringPropertyNullable = "";
        await Assert.That(sut.StringPropertyNullable).IsEqualTo("");
    }

    [Test]
    public async Task TestStringPropertyReadOnlyNullable()
    {
        var sut = GetSut();

        await Assert.That(sut.StringPropertyReadOnlyNullableAsNull).IsEqualTo(null);
        await Assert.That(sut.StringPropertyReadOnlyNullableAsNotNull).IsEqualTo("this is not null string");
        await Assert.That(sut.StringPropertyReadOnlyNullableAsEmpty).IsEqualTo("");
    }
}