using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Core.Features;
using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.Server.Tests.Tests;

public class ServerPrefetchTests
{
    private sealed class HarnessProps
    {
        public required Action<IFeatureCollection> Setup { get; init; }
        public IComponent[] Children { get; init; } = [];
    }

    /// <summary>
    /// Generic component: invokes <see cref="HarnessProps.Setup"/> with the
    /// ambient features during Setup and renders any child components.
    /// </summary>
    private sealed class Harness : BaseComponent<HarnessProps, BaseEmits, object?>
    {
        protected override IComponent[] Setup(HarnessProps props, BaseEmits? events, out object? exposed)
        {
            props.Setup(AppFeatures.Features);
            exposed = null;
            return props.Children;
        }
    }

    /// <summary>
    /// Component that reads a string signal and renders it as text. Used to
    /// confirm prefetched values made it into the rendered output.
    /// </summary>
    private sealed class TextFromSignal : BaseComponent<ISignal<string>, BaseEmits, object?>
    {
        protected override IComponent[] Setup(ISignal<string> props, BaseEmits? events, out object? exposed)
        {
            exposed = null;
            return [new DomText { Text = props }];
        }
    }

    [Test]
    public async Task Single_component_prefetch_is_awaited_before_render()
    {
        var prefetch = new ServerPrefetchFeature();
        var root = new SsrRenderRoot();
        var text = new Signal<string>("loading");

        var host = new IskraHostBuilder()
            .UseRootRenderer(root)
            .SetFeature<IServerPrefetchFeature>(prefetch)
            .UseRootComponent(() => new Harness
            {
                Props = new HarnessProps
                {
                    Setup = f => f.OnServerPrefetch(async () =>
                    {
                        await Task.Yield();
                        text.Value = "hello";
                    }),
                    Children = [new Div { Children = [new TextFromSignal { Props = text }] }],
                },
            })
            .Build();

        using var _ = host.Mount();
        await prefetch.WaitForCompletionAsync();

        var output = await SsrHelpers.RenderAsync(root);
        await Assert.That(output).IsEqualTo("<div>hello</div>");
    }

    [Test]
    public async Task Multiple_components_register_and_all_complete()
    {
        var prefetch = new ServerPrefetchFeature();
        var counts = new List<string>();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(new SsrRenderRoot())
            .SetFeature<IServerPrefetchFeature>(prefetch)
            .UseRootComponent(() => new Harness
            {
                Props = new HarnessProps
                {
                    Setup = f => f.OnServerPrefetch(async () =>
                    {
                        await Task.Yield();
                        lock (counts) counts.Add("root");
                    }),
                    Children =
                    [
                        new Harness
                        {
                            Props = new HarnessProps
                            {
                                Setup = f => f.OnServerPrefetch(async () =>
                                {
                                    await Task.Yield();
                                    lock (counts) counts.Add("childA");
                                }),
                            },
                        },
                        new Harness
                        {
                            Props = new HarnessProps
                            {
                                Setup = f => f.OnServerPrefetch(async () =>
                                {
                                    await Task.Yield();
                                    lock (counts) counts.Add("childB");
                                }),
                            },
                        },
                    ],
                },
            })
            .Build()
            .Mount();

        await prefetch.WaitForCompletionAsync();

        await Assert.That(counts).Contains("root");
        await Assert.That(counts).Contains("childA");
        await Assert.That(counts).Contains("childB");
        await Assert.That(counts.Count).IsEqualTo(3);
    }

    [Test]
    public async Task Cascading_registrations_during_drain_are_awaited()
    {
        var prefetch = new ServerPrefetchFeature();
        var ran = new List<string>();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(new SsrRenderRoot())
            .SetFeature<IServerPrefetchFeature>(prefetch)
            .UseRootComponent(() => new Harness
            {
                Props = new HarnessProps
                {
                    Setup = f =>
                    {
                        f.OnServerPrefetch(async () =>
                        {
                            await Task.Yield();
                            ran.Add("first");
                            // Cascading registration during drain.
                            f.OnServerPrefetch(async () =>
                            {
                                await Task.Yield();
                                ran.Add("second");
                                f.OnServerPrefetch(async () =>
                                {
                                    await Task.Yield();
                                    ran.Add("third");
                                });
                            });
                        });
                    },
                },
            })
            .Build()
            .Mount();

        await prefetch.WaitForCompletionAsync();

        await Assert.That(ran).IsEquivalentTo(new[] { "first", "second", "third" });
    }

    [Test]
    public async Task Prefetch_can_flip_If_branch_and_new_branch_prefetch_is_awaited()
    {
        var prefetch = new ServerPrefetchFeature();
        var condition = new Signal<bool>(false);
        var ran = new List<string>();
        var root = new SsrRenderRoot();
        var text = new Signal<string>("loading");

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .SetFeature<IServerPrefetchFeature>(prefetch)
            .UseRootComponent(() => new Harness
            {
                Props = new HarnessProps
                {
                    Setup = f =>
                    {
                        // Top-level prefetch: flips the If condition so the Then-branch
                        // mounts mid-drain and registers its own prefetch.
                        f.OnServerPrefetch(async () =>
                        {
                            await Task.Yield();
                            ran.Add("outer");
                            condition.Value = true;
                        });
                    },
                    Children =
                    [
                        new If
                        {
                            Condition = condition,
                            Then = () =>
                            [
                                new Harness
                                {
                                    Props = new HarnessProps
                                    {
                                        Setup = f => f.OnServerPrefetch(async () =>
                                        {
                                            await Task.Yield();
                                            ran.Add("inner");
                                            text.Value = "ready";
                                        }),
                                        Children = [new Div { Children = [new TextFromSignal { Props = text }] }],
                                    },
                                },
                            ],
                        },
                    ],
                },
            })
            .Build()
            .Mount();

        await prefetch.WaitForCompletionAsync();

        await Assert.That(ran).IsEquivalentTo(new[] { "outer", "inner" });
        var output = await SsrHelpers.RenderAsync(root);
        await Assert.That(output).IsEqualTo("<div>ready</div>");
    }

    [Test]
    public async Task OnServerPrefetch_is_no_op_when_feature_absent()
    {
        var ran = false;

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(new SsrRenderRoot())
            .UseRootComponent(() => new Harness
            {
                Props = new HarnessProps
                {
                    Setup = f => f.OnServerPrefetch(async () =>
                    {
                        await Task.Yield();
                        ran = true;
                    }),
                },
            })
            .Build()
            .Mount();

        await Assert.That(ran).IsFalse();
    }

    [Test]
    public async Task Drain_continues_past_failures_and_aggregates_errors()
    {
        var prefetch = new ServerPrefetchFeature();
        var ran = new List<string>();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(new SsrRenderRoot())
            .SetFeature<IServerPrefetchFeature>(prefetch)
            .UseRootComponent(() => new Harness
            {
                Props = new HarnessProps
                {
                    Setup = f =>
                    {
                        f.OnServerPrefetch(async () =>
                        {
                            await Task.Yield();
                            ran.Add("a");
                            throw new InvalidOperationException("a-failed");
                        });
                        f.OnServerPrefetch(async () =>
                        {
                            await Task.Yield();
                            ran.Add("b");
                        });
                        f.OnServerPrefetch(async () =>
                        {
                            await Task.Yield();
                            ran.Add("c");
                            throw new InvalidOperationException("c-failed");
                        });
                    },
                },
            })
            .Build()
            .Mount();

        var ex = await Assert.ThrowsAsync<AggregateException>(
            async () => await prefetch.WaitForCompletionAsync());

        await Assert.That(ran).IsEquivalentTo(new[] { "a", "b", "c" });
        await Assert.That(ex!.InnerExceptions.Count).IsEqualTo(2);
        await Assert.That(ex.InnerExceptions[0].Message).IsEqualTo("a-failed");
        await Assert.That(ex.InnerExceptions[1].Message).IsEqualTo("c-failed");
    }

    [Test]
    public async Task Empty_drain_completes_successfully()
    {
        var prefetch = new ServerPrefetchFeature();
        await prefetch.WaitForCompletionAsync();
    }
}
