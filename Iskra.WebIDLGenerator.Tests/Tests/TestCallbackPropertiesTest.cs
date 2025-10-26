namespace Iskra.WebIDLGenerator.Tests.Tests;

public class TestCallbackPropertiesTest() : BaseTest<TestCallbackProperties>("testCallbackProperties")
{
    [Test]
    public async Task TestCallbackInvocation()
    {
        var sut = GetSut();

        var wasCalled = false;
        var receivedValue = 0;

        void Callback(int value)
        {
            wasCalled = true;
            receivedValue = value;
        }

        sut.VoidCallback = (TestCallbackPropertiesCallback)Callback;

        // Trigger the callback via the setter
        sut.CallVoidCallbackOnSet = 42;

        await Assert.That(wasCalled).IsTrue();
        await Assert.That(receivedValue).IsEqualTo(42);
    }

    [Test]
    public async Task TestVariadicCallback()
    {
        var sut = GetSut();

        var wasCalled = false;
        var receivedParam1 = 0L;
        var receivedValues = Array.Empty<int>();

        void VariadicCallback(long param1, params int[] values)
        {
            wasCalled = true;
            receivedParam1 = param1;
            receivedValues = values;
        }

        sut.VariadicCallback = (TestCallbackPropertiesVariadicCallback)VariadicCallback;

        // Call with multiple arguments using the setter
        sut.CallVariadicCallbackOnSet = new[] { 1, 2, 3, 4, 5 };

        await Assert.That(wasCalled).IsTrue();
        await Assert.That(receivedParam1).IsEqualTo(999L);
        await Assert.That(receivedValues.Length).IsEqualTo(5);
        await Assert.That(receivedValues[0]).IsEqualTo(1);
        await Assert.That(receivedValues[1]).IsEqualTo(2);
        await Assert.That(receivedValues[2]).IsEqualTo(3);
        await Assert.That(receivedValues[3]).IsEqualTo(4);
        await Assert.That(receivedValues[4]).IsEqualTo(5);
    }
}