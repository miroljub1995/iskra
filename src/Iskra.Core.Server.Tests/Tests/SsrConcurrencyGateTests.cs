using Iskra.Core.Components;
using Iskra.Core.Features;
using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.Server.Tests.Tests;

public class SsrConcurrencyGateTests
{
    private sealed class HarnessProps
    {
        public required Action<IFeatureCollection> Setup { get; init; }
    }

    private sealed class Harness : BaseComponent<HarnessProps, BaseEmits, object?>
    {
        protected override IComponent[] Setup(HarnessProps props, BaseEmits? events, out object? exposed)
        {
            props.Setup(AppFeatures.Features);
            exposed = null;
            return [];
        }
    }

    private static IskraHost BuildHost(
        ServerPrefetchFeature prefetch,
        ISsrConcurrencyGateFeature gate,
        Action<IFeatureCollection> setup)
    {
        return new IskraHostBuilder()
            .UseRootRenderer(new SsrRenderRoot())
            .SetFeature<IServerPrefetchFeature>(prefetch)
            .SetFeature<ISsrConcurrencyGateFeature>(gate)
            .UseRootComponent(() => new Harness { Props = new HarnessProps { Setup = setup } })
            .Build();
    }

    [Test]
    public async Task Parallel_async_writers_under_gate_serialize_to_correct_final_value()
    {
        const int writers = 32;
        const int incrementsPerWriter = 50;

        var prefetch = new ServerPrefetchFeature();
        using var gate = new SsrConcurrencyGateFeature();
        var counter = new Signal<int>(0);

        using var _ = BuildHost(prefetch, gate, f =>
        {
            // The gate serializes any await whose continuation is captured by
            // its SerialSynchronizationContext. Plain async methods (no
            // Task.Run wrapper) inherit the context from the caller, so
            // their continuations are posted back through the gate and the
            // signal mutations on each resume happen one at a time.
            f.OnServerPrefetch(() => f.Get<ISsrConcurrencyGateFeature>()!.RunExclusiveAsync(async () =>
            {
                var tasks = new Task[writers];
                for (int w = 0; w < writers; w++)
                {
                    tasks[w] = IncrementAsync();
                }

                await Task.WhenAll(tasks);
            }));

            async Task IncrementAsync()
            {
                for (int i = 0; i < incrementsPerWriter; i++)
                {
                    await Task.Delay(1);
                    counter.Value = counter.Value + 1;
                }
            }
        }).Mount();

        await prefetch.WaitForCompletionAsync();

        await Assert.That(counter.Value).IsEqualTo(writers * incrementsPerWriter);
    }

    [Test]
    public async Task Effect_reruns_serially_under_parallel_async_writers()
    {
        const int writers = 16;
        const int incrementsPerWriter = 25;

        var prefetch = new ServerPrefetchFeature();
        using var gate = new SsrConcurrencyGateFeature();
        var trigger = new Signal<int>(0);
        var observed = new List<int>();
        var faults = new List<Exception>();
        gate.UnhandledException += faults.Add;

        using var _ = BuildHost(prefetch, gate, f =>
        {
            new Effect(_ => observed.Add(trigger.Value));

            f.OnServerPrefetch(() => f.Get<ISsrConcurrencyGateFeature>()!.RunExclusiveAsync(async () =>
            {
                var tasks = new Task[writers];
                for (int w = 0; w < writers; w++)
                {
                    tasks[w] = IncrementAsync();
                }

                await Task.WhenAll(tasks);
            }));

            async Task IncrementAsync()
            {
                for (int i = 0; i < incrementsPerWriter; i++)
                {
                    await Task.Delay(1);
                    trigger.Value = trigger.Value + 1;
                }
            }
        }).Mount();

        await prefetch.WaitForCompletionAsync();

        await Assert.That(faults).IsEmpty();
        await Assert.That(trigger.Value).IsEqualTo(writers * incrementsPerWriter);
        // Initial run + one re-run per write.
        await Assert.That(observed.Count).IsEqualTo(writers * incrementsPerWriter + 1);
        // Strictly increasing: every set was ordered against every effect re-run.
        for (int i = 1; i < observed.Count; i++)
        {
            await Assert.That(observed[i]).IsGreaterThan(observed[i - 1]);
        }
    }

    [Test]
    public async Task Cascading_registration_after_async_hop_is_drained()
    {
        var prefetch = new ServerPrefetchFeature();
        using var gate = new SsrConcurrencyGateFeature();
        var ran = new List<string>();

        using var _ = BuildHost(prefetch, gate, f =>
        {
            f.OnServerPrefetch(() => f.Get<ISsrConcurrencyGateFeature>()!.RunExclusiveAsync(async () =>
            {
                await Task.Delay(1);
                ran.Add("first");

                f.OnServerPrefetch(() => f.Get<ISsrConcurrencyGateFeature>()!.RunExclusiveAsync(async () =>
                {
                    await Task.Delay(1);
                    ran.Add("second");
                }));
            }));
        }).Mount();

        await prefetch.WaitForCompletionAsync();

        await Assert.That(ran).IsEquivalentTo(new[] { "first", "second" });
    }

    [Test]
    public async Task TaskRun_bypasses_gate_unless_re_entered()
    {
        // Documents the contract: Task.Run does NOT flow SynchronizationContext.
        // A signal write performed on a Task.Run worker is NOT gated. Real
        // SSR code that needs to fan out to background work must re-enter the
        // gate inside the Task.Run body (or stick to plain async methods).
        var prefetch = new ServerPrefetchFeature();
        using var gate = new SsrConcurrencyGateFeature();
        var counter = new Signal<int>(0);

        using var _ = BuildHost(prefetch, gate, f =>
        {
            var g = f.Get<ISsrConcurrencyGateFeature>()!;
            f.OnServerPrefetch(() => g.RunExclusiveAsync(async () =>
            {
                var tasks = new Task[16];
                for (int w = 0; w < tasks.Length; w++)
                {
                    // Re-enter the gate from inside Task.Run. Without this
                    // wrap, increments race and the assertion below fails.
                    tasks[w] = Task.Run(() => g.RunExclusiveAsync(async () =>
                    {
                        for (int i = 0; i < 25; i++)
                        {
                            await Task.Delay(1);
                            counter.Value = counter.Value + 1;
                        }
                    }));
                }

                await Task.WhenAll(tasks);
            }));
        }).Mount();

        await prefetch.WaitForCompletionAsync();

        await Assert.That(counter.Value).IsEqualTo(16 * 25);
    }
}
