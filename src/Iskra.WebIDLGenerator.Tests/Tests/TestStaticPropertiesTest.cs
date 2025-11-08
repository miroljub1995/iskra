namespace Iskra.WebIDLGenerator.Tests.Tests;

public class TestStaticPropertiesTest() : BaseTest<TestStaticProperties>("testStaticProperties")
{
    [Test]
    public async Task TestSimpleStaticProperty()
    {
        await Assert.That(TestStaticProperties.SimpleProp).IsEqualTo(2);
        await Assert.That(TestStaticProperties.SimpleProp = 3).IsEqualTo(3);
        await Assert.That(TestStaticProperties.SimpleProp = -3).IsEqualTo(-3);
    }
}