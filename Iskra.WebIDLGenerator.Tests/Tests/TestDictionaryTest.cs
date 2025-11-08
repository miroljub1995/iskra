namespace Iskra.WebIDLGenerator.Tests.Tests;

public class TestDictionaryTest() : BaseTest<TestDictionary>("testDictionary")
{
    [Test]
    public async Task TestDictionaryProcessing()
    {
        var sut = GetSut();

        var dict = new TestDictionaryDict
        {
            Name = "John",
            Age = 30,
            Active = true
        };

        var result = sut.ProcessDictionary(dict);

        await Assert.That(result).IsEqualTo("{\"active\":true,\"age\":30,\"name\":\"John\"}");
    }

    [Test]
    public async Task TestDictionaryProcessingWithPartialData()
    {
        var sut = GetSut();

        var dict = new TestDictionaryDict
        {
            Name = "Jane",
            Age = 25
        };

        var result = sut.ProcessDictionary(dict);

        await Assert.That(result).IsEqualTo("{\"age\":25,\"name\":\"Jane\"}");
    }
}
