namespace Iskra.StdWeb.Tests.TestApi;

public class TestApiPropertiesTest() : BaseTest<TestApiProperties>("testApiProperties")
{
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

        await Assert.That(sut.ReadOnlyStringProperty).IsEqualTo("read only string property");
    }

    [Test]
    public async Task TestReadOnlyStringPropertySetNotExists()
    {
        await Assert.That(PropertyIsReadOnly(nameof(TestApiProperties.ReadOnlyStringProperty))).IsTrue();
    }
}