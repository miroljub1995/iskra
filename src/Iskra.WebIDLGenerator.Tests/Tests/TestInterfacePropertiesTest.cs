namespace Iskra.WebIDLGenerator.Tests.Tests;

public class TestInterfacePropertiesTest() : BaseTest<TestInterfaceProperties>("testInterfaceProperties")
{
    [Test]
    public async Task TestInterfaceProperty()
    {
        var sut = GetSut();

        await Assert.That(sut.Value).IsNotNull();
        await Assert.That(sut.Value).IsEqualTo(sut.Value).Because("it should return equal object");

        await Assert.That(sut.Value.Value).IsEqualTo(3);

        await Assert.That(sut.ValueNullable?.Value).IsEqualTo(3);
        await Assert.That(sut.ValueNullable = null).IsNull();

        await Assert.That(sut.ValueNullableReadonlyAsNotNull?.Value).IsEqualTo(4);
        await Assert.That(sut.ValueNullableReadonlyAsNull).IsNull();
    }
}