using Iskra.JSCore.Generics;

namespace Iskra.WebIDLGenerator.Tests.Tests;

public class TestRecordLongTest() : BaseTest<TestRecordLong>("testRecordLong")
{
    [Test]
    public async Task TestRecordLong()
    {
        Record<long, PropertyAccessor> record = new()
        {
            { "first", 10 },
            { "second", 20 },
            { "third", 30 },
        };

        await Assert.That(record.ContainsKey("first")).IsTrue();
        await Assert.That(record.ContainsKey("second")).IsTrue();
        await Assert.That(record.ContainsKey("third")).IsTrue();

        await Assert.That(record["first"]).IsEqualTo(10);
        await Assert.That(record["second"]).IsEqualTo(20);
        await Assert.That(record["third"]).IsEqualTo(30);

        await Assert.That(record.ContainsKey("fourth")).IsFalse();
    }
}