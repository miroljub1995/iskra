namespace Iskra.WebIDLGenerator.Tests.Tests;

public class TestDictionaryPropertiesTest() : BaseTest<TestDictionaryProperties>("testDictionaryProperties")
{
    [Test]
    public async Task TestDictionaryProperties()
    {
        var sut = GetSut();
        var dict = sut.Value;
        await Assert.That(dict).IsNotNull();

        // await Assert.That(dict.BooleanValue).IsEqualTo(true);
        // await Assert.That(dict.IntValue).IsEqualTo(42);

        // Test setting new values
        // sut.Value = new TestDictionaryPropertiesDictionary
        // {
        //     BooleanValue = false,
        //     IntValue = 100
        // };
        //
        // await Assert.That(sut.Value.BooleanValue).IsEqualTo(false);
        // await Assert.That(sut.Value.IntValue).IsEqualTo(100);
    }
}