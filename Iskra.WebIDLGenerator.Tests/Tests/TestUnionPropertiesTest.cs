namespace Iskra.WebIDLGenerator.Tests.Tests;

public class TestUnionPropertiesTest() : BaseTest<TestUnionProperties>("testUnionProperties")
{
    [Test]
    public async Task TestBoolPropertyGet()
    {
        var sut = GetSut();

        await Assert.That(sut.Value).IsNotNull();
        await Assert.That(sut.Value.TryCast(out bool _)).IsFalse();
        await Assert.That(sut.Value.TryCast(out int val)).IsTrue();
        await Assert.That(val).IsEqualTo(3);
    }

    [Test]
    public async Task TestBoolPropertySet()
    {
        var sut = GetSut();

        sut.Value = true;

        await Assert.That(sut.Value.TryCast(out int _)).IsFalse();
        await Assert.That(sut.Value.TryCast(out bool val)).IsTrue();
        await Assert.That(val).IsEqualTo(true);
    }
}