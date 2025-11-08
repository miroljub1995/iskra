namespace Iskra.WebIDLGenerator.Tests.Tests;

public class TestCallbackInterfaceTest() : BaseTest<TestCallbackInterface>("testCallbackInterface")
{
    [Test]
    public async Task TestCallbackInterfaceInvocationUsingProperty()
    {
        var sut = GetSut();

        var wasCalled = false;
        var receivedValue = 0;

        string ProcessValue(int value)
        {
            wasCalled = true;
            receivedValue = value;
            return $"Processed: {value}";
        }

        var callbackInterface = new TestCallbackInterfaceCallback
        {
            ProcessValue = new TestCallbackInterfaceCallbackCallback(ProcessValue)
        };

        var result = sut.InvokeCallback(callbackInterface);

        await Assert.That(wasCalled).IsTrue();
        await Assert.That(receivedValue).IsEqualTo(TestCallbackInterfaceCallback.EXPECTED_VALUE);
        await Assert.That(result).IsEqualTo(TestCallbackInterfaceCallback.EXPECTED_RESULT);
    }

    [Test]
    public async Task TestCallbackInterfaceInvocationUsingConstructor()
    {
        var sut = GetSut();

        var wasCalled = false;
        var receivedValue = 0;

        string ProcessValue(int value)
        {
            wasCalled = true;
            receivedValue = value;
            return $"Processed: {value}";
        }

        var result = sut.InvokeCallback(new TestCallbackInterfaceCallback(ProcessValue));

        await Assert.That(wasCalled).IsTrue();
        await Assert.That(receivedValue).IsEqualTo(TestCallbackInterfaceCallback.EXPECTED_VALUE);
        await Assert.That(result).IsEqualTo(TestCallbackInterfaceCallback.EXPECTED_RESULT);
    }
}