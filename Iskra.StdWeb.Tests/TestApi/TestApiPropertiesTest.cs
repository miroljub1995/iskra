namespace Iskra.StdWeb.Tests.TestApi;

public class TestApiPropertiesTest() : BaseTest<TestApiProperties>("testApiProperties")
{
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
        await Assert.That(PropertyIsReadOnly(nameof(TestApiProperties.IntPropertyReadOnly))).IsTrue();
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
        await Assert.That(sut.IntPropertyReadOnlyNullableAsNotNull).IsEqualTo(2);
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
        await Assert.That(PropertyIsReadOnly(nameof(TestApiProperties.DoublePropertyReadOnly))).IsTrue();
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
        await Assert.That(PropertyIsReadOnly(nameof(TestApiProperties.BoolPropertyReadOnly))).IsTrue();
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
        await Assert.That(PropertyIsReadOnly(nameof(TestApiProperties.StringPropertyReadOnly))).IsTrue();
    }
}