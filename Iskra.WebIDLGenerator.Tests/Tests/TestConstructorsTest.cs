using Iskra.JSCore.Extensions;

namespace Iskra.WebIDLGenerator.Tests.Tests;

public class TestConstructorsTest() : BaseTest<TestConstructors>("testConstructors")
{
    [Test]
    public async Task DefaultConstructor()
    {
        var sut = TestConstructors.New();

        var value = sut.JSObject.GetPropertyAsStringV2("getArgsAsJson");

        await Assert.That(value).IsEqualTo("[]");
    }

    [Test]
    public async Task ConstructorWithIntArgument()
    {
        var sut = TestConstructors.New(12);

        var value = sut.JSObject.GetPropertyAsStringV2("getArgsAsJson");

        await Assert.That(value).IsEqualTo("[12]");
    }

    [Test]
    public async Task ConstructorWithStringAndNumber()
    {
        var sut = TestConstructors.New("hello", 42);

        var value = sut.JSObject.GetPropertyAsStringV2("getArgsAsJson");

        await Assert.That(value).IsEqualTo("""["hello",42]""");
    }

    [Test]
    public async Task ConstructorWithAllArguments()
    {
        var sut = TestConstructors.New("full test", 123, true);

        var value = sut.JSObject.GetPropertyAsStringV2("getArgsAsJson");

        await Assert.That(value).IsEqualTo("""["full test",123,true]""");
    }

    [Test]
    public async Task ConstructorWithAllArgumentsFalseBool()
    {
        var sut = TestConstructors.New("another test", -5, false);

        var value = sut.JSObject.GetPropertyAsStringV2("getArgsAsJson");

        await Assert.That(value).IsEqualTo("""["another test",-5,false]""");
    }

    [Test]
    public async Task ConstructorWithVariadicArguments1()
    {
        var sut = TestConstructors.New("another test", "second arg");

        var value = sut.JSObject.GetPropertyAsStringV2("getArgsAsJson");

        await Assert.That(value).IsEqualTo("""["another test","second arg"]""");
    }

    [Test]
    public async Task ConstructorWithVariadicArguments2()
    {
        var sut = TestConstructors.New("another test", "second arg", 1, 2, 3, 4, 5);

        var value = sut.JSObject.GetPropertyAsStringV2("getArgsAsJson");

        await Assert.That(value).IsEqualTo("""["another test","second arg",1,2,3,4,5]""");
    }
}