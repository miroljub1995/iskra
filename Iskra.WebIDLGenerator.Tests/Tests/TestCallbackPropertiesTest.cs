namespace Iskra.WebIDLGenerator.Tests.Tests;

public class TestCallbackPropertiesTest() : BaseTest<TestCallbackProperties>("testCallbackProperties")
{
    [Test]
    public async Task TestCallbackInvocationCastToJS()
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
    public async Task TestCallbackInvocationCastToManaged()
    {
        var sut = GetSut();

        var wasCalled = false;
        var receivedValue = 0;

        void Callback(int value)
        {
            wasCalled = true;
            receivedValue = value;
        }

        sut.VoidCallback = (TestCallbackPropertiesCallbackManaged)Callback;

        // Trigger the callback via the setter
        sut.CallVoidCallbackOnSet = 42;

        await Assert.That(wasCalled).IsTrue();
        await Assert.That(receivedValue).IsEqualTo(42);
    }

    [Test]
    public async Task TestCallbackInvocationConstructorJS()
    {
        var sut = GetSut();

        var wasCalled = false;
        var receivedValue = 0;

        void Callback(int value)
        {
            wasCalled = true;
            receivedValue = value;
        }

        sut.VoidCallback = new TestCallbackPropertiesCallback(Callback);

        // Trigger the callback via the setter
        sut.CallVoidCallbackOnSet = 42;

        await Assert.That(wasCalled).IsTrue();
        await Assert.That(receivedValue).IsEqualTo(42);
    }

    [Test]
    public async Task TestCallbackInvocationConstructorManaged()
    {
        var sut = GetSut();

        var wasCalled = false;
        var receivedValue = 0;

        void Callback(int value)
        {
            wasCalled = true;
            receivedValue = value;
        }

        sut.VoidCallback = new TestCallbackPropertiesCallbackManaged(Callback);

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

    [Test]
    public async Task TestNonVoidCallback()
    {
        var sut = GetSut();

        var wasCalled = false;
        var receivedA = 0;
        var receivedB = 0;

        int NonVoidCallback(int a, int b)
        {
            wasCalled = true;
            receivedA = a;
            receivedB = b;
            return a + b;
        }

        sut.NonVoidCallback = (TestCallbackPropertiesNonVoidCallback)NonVoidCallback;

        var result = sut.NonVoidCallbackCallAndGetResult;

        await Assert.That(wasCalled).IsTrue();
        await Assert.That(receivedA).IsEqualTo(10);
        await Assert.That(receivedB).IsEqualTo(20);
        await Assert.That(result).IsEqualTo(30);
    }

    [Test]
    public async Task TestTryGetManagedAfterSet()
    {
        var sut = GetSut();

        int NonVoidCallback(int a, int b)
        {
            return a + b;
        }

        sut.NonVoidCallback = (TestCallbackPropertiesNonVoidCallback)NonVoidCallback;
        var success = sut.NonVoidCallback.TryGetManaged(out var callback);

        await Assert.That(success).IsTrue();
        await Assert.That(callback).IsNotNull();
        await Assert.That(callback).IsEqualTo(NonVoidCallback);
    }

    [Test]
    public async Task TestTryGetManaged()
    {
        var sut = GetSut();

        var success = sut.NonVoidCallback.TryGetManaged(out var callback);

        await Assert.That(success).IsFalse();
        await Assert.That(callback).IsNull();
    }

    [Test]
    public async Task TestTryGetManagedConversion()
    {
        var sut = GetSut();

        var success = sut.NonVoidCallback.TryGetManaged(out var callback, true);

        await Assert.That(success).IsTrue();
        await Assert.That(callback).IsNotNull();

        var res = callback?.Invoke(1, 2);
        await Assert.That(res).IsEqualTo(7);
    }
}