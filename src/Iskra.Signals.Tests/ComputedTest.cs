namespace Iskra.Signals.Tests;

public class ComputedTest
{
    [Test]
    public async Task ShouldComputeValueAsync()
    {
        var computed = new Computed<string>(() => "test");
        await Assert.That(computed.Value).IsEqualTo("test");
    }

    [Test]
    public async Task ShouldComputeValueOnlyOnceAsync()
    {
        var count = 0;
        var computed = new Computed<string>(() =>
        {
            count++;
            return "test";
        });

        _ = computed.Value;
        _ = computed.Value;
        _ = computed.Value;
        _ = computed.Value;

        await Assert.That(count).IsEqualTo(1);
        await Assert.That(computed.Value).IsEqualTo("test");
    }

    [Test]
    public async Task ShouldTrackDependenciesAsync()
    {
        var signal = new Signal<string>("test");
        var computed = new Computed<string>(() => signal.Value);

        await Assert.That(computed.Value).IsEqualTo("test");

        signal.Value = "test2";
        await Assert.That(computed.Value).IsEqualTo("test2");
    }

    [Test]
    public async Task ShouldRunComputedOnlyOnSignalDepChangeAsync()
    {
        var signal = new Signal<string>("test");
        var count = 0;
        var computed = new Computed<string>(() =>
        {
            count++;
            return signal.Value + " from computed";
        });

        await Assert.That(computed.Value).IsEqualTo("test from computed");

        signal.Value = "test";
        await Assert.That(computed.Value).IsEqualTo("test from computed");
        await Assert.That(count).IsEqualTo(1);

        signal.Value = "test";
        await Assert.That(computed.Value).IsEqualTo("test from computed");
        await Assert.That(count).IsEqualTo(1);
    }

    [Test]
    public async Task ShouldRunComputedOnlyOnComputedDepChangeAsync()
    {
        var signal = new Signal<string>("test");
        var count = 0;
        var parentComputed = new Computed<bool>(() => signal.Value.Length > 0);

        var computed = new Computed<string>(() =>
        {
            count++;
            return parentComputed.Value.ToString();
        });

        await Assert.That(computed.Value).IsEqualTo("True");

        signal.Value += " 1";
        await Assert.That(computed.Value).IsEqualTo("True");
        await Assert.That(count).IsEqualTo(1);

        signal.Value += " 2";
        await Assert.That(computed.Value).IsEqualTo("True");
        await Assert.That(count).IsEqualTo(1);
    }

    [Test]
    public async Task ShouldSupportPyramidDepsAsync()
    {
        var signal = new Signal<string>("test");
        var computed1 = new Computed<string>(() => signal.Value + 1);
        var computed2 = new Computed<string>(() => signal.Value + 2);
        var computed = new Computed<string>(() => computed1.Value + " " + computed2.Value);

        await Assert.That(computed.Value).IsEqualTo("test1 test2");

        signal.Value = "test new";
        await Assert.That(computed.Value).IsEqualTo("test new1 test new2");
    }

    [Test]
    public async Task ShouldAllowGarbageCollectionOfConsumersAsync()
    {
        var signal = new Signal<string>("test");
        var weak = await RunTestAsync(signal);

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        await Assert.That(weak.TryGetTarget(out _)).IsFalse();
        return;

        // Need this to avoid state machine capturing the computed reference
        static async Task<WeakReference<Computed<string>>> RunTestAsync(Signal<string> signal)
        {
            var computed = new Computed<string>(() => signal.Value + 1);

            await Assert.That(computed.Value).IsEqualTo("test1");

            var weak = new WeakReference<Computed<string>>(computed);

            // ReSharper disable once RedundantAssignment - need to clear strong reference
            computed = null;

            return weak;
        }
    }
}