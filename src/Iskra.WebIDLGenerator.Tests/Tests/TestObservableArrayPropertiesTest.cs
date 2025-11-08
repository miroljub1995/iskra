namespace Iskra.WebIDLGenerator.Tests.Tests;

public class TestObservableArrayPropertiesTest()
    : BaseTest<TestObservableArrayProperties>("testObservableArrayProperties")
{
    // bool[]
    [Test]
    public async Task TestBoolPropertyGet()
    {
        var sut = GetSut();

        await Assert.That(sut.BoolObservableArray).IsNotNull();

        await Assert.That((bool[])sut.BoolObservableArray is [true, false]).IsTrue();
        sut.BoolObservableArray = (bool[])[false, true, false, true, true];
        await Assert.That((bool[])sut.BoolObservableArray is [false, true, false, true, true]).IsTrue();
    }

    [Test]
    public async Task TestBoolArrayElementGet()
    {
        var sut = GetSut();

        await Assert.That(sut.BoolObservableArray[0]).IsTrue();
        await Assert.That(sut.BoolObservableArray[1]).IsFalse();
    }

    [Test]
    public async Task TestBoolArrayLength()
    {
        var sut = GetSut();

        await Assert.That(sut.BoolObservableArray.Length).IsEqualTo(2);
        await Assert.That(sut.BoolObservableArray.Length = 3).IsEqualTo(3);
    }
}