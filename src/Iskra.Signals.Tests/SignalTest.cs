namespace Iskra.Signals.Tests;

public class SignalTest
{
    [Test]
    public async Task ShouldSetInitialValueAsync()
    {
        var signal = new Signal<string>("test");
        await Assert.That(signal.Value).IsEqualTo("test");
    }

    [Test]
    public async Task ShouldSetValueAsync()
    {
        var signal = new Signal<string>("test");

        signal.Value = "test2";

        await Assert.That(signal.Value).IsEqualTo("test2");
    }
}