namespace Iskra.Signals.Tests;

[ParallelLimiter<SingleParallelLimit>]
public class EffectScopeTest
{
    [Test]
    public async Task ShouldRunEffectImmediately()
    {
        var scope = new EffectScope();

        var runCount = 0;
        scope.Run(() => { new Effect(_ => { runCount++; }); });

        await Assert.That(runCount).IsEqualTo(1);
    }

    [Test]
    public async Task ShouldRunEffectOnChange()
    {
        var signal = new Signal<string>("test");
        var scope = new EffectScope();

        var runCount = 0;
        scope.Run(() =>
        {
            new Effect(_ =>
            {
                var __ = signal.Value;
                runCount++;
            });
        });

        signal.Value = "new test";

        await Assert.That(runCount).IsEqualTo(2);
    }

    [Test]
    public async Task ShouldNoRunDisposedEffectOnChange()
    {
        var signal = new Signal<string>("test");
        var scope = new EffectScope();

        var runCount = 0;
        scope.Run(() =>
        {
            new Effect(_ =>
            {
                var __ = signal.Value;
                runCount++;
            });
        });

        scope.Dispose();
        signal.Value = "new test";

        await Assert.That(runCount).IsEqualTo(1);
    }
}