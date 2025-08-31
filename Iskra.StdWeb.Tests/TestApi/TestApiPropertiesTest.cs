namespace Iskra.StdWeb.Tests.TestApi;

public class TestApiPropertiesTest() : BaseTest<TestApiProperties>("testApiProperties")
{
    [Test]
    public async Task TestIntPropertyGet()
    {
        var sut = GetSut();

        await Assert.That(sut.IntProperty).IsEqualTo(1);
    }

    [Test]
    public async Task TestIntPropertySet()
    {
        var sut = GetSut();

        sut.IntProperty = 3;

        await Assert.That(sut.IntProperty).IsEqualTo(3);
    }

    [Test]
    public async Task TestReadOnlyIntPropertyGet()
    {
        var sut = GetSut();

        await Assert.That(sut.IntPropertyReadOnly).IsEqualTo(2);
    }

    [Test]
    public async Task TestReadOnlyIntPropertyIsReadOnly()
    {
        await Assert.That(PropertyIsReadOnly(nameof(TestApiProperties.IntPropertyReadOnly))).IsTrue();
    }

    [Test]
    public async Task TestStringPropertyGet()
    {
        var sut = GetSut();

        await Assert.That(sut.StringProperty).IsEqualTo("string property");
    }

    [Test]
    public async Task TestStringPropertySet()
    {
        var sut = GetSut();

        sut.StringProperty = "set string property";

        await Assert.That(sut.StringProperty).IsEqualTo("set string property");
    }

    [Test]
    public async Task TestReadOnlyStringPropertyGet()
    {
        var sut = GetSut();

        await Assert.That(sut.StringPropertyReadOnly).IsEqualTo("string property read only");
    }

    [Test]
    public async Task TestReadOnlyStringPropertyIsReadOnly()
    {
        await Assert.That(PropertyIsReadOnly(nameof(TestApiProperties.StringPropertyReadOnly))).IsTrue();
    }
}