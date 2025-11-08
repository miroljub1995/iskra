namespace Iskra.WebIDLGenerator.Tests.Tests;

public class TestFrozenArrayPropertiesTest() : BaseTest<TestFrozenArrayProperties>("testFrozenArrayProperties")
{
    // bool[]
    [Test]
    public async Task TestBoolPropertyGet()
    {
        var sut = GetSut();

        await Assert.That(sut.BoolArray).IsNotNull();

        await Assert.That((bool[])sut.BoolArray is [true, false]).IsTrue();
        sut.BoolArray = (bool[])[false, true, false, true, true];
        await Assert.That((bool[])sut.BoolArray is [false, true, false, true, true]).IsTrue();
    }
}