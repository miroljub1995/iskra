using Iskra.Core.Client.Tests.TestUtils;
using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.Client.Tests;

public class IfTests
{
    private sealed class Harness : IDisposable
    {
        public required Element Container { get; init; }
        public required Signal<bool> Condition { get; init; }
        public required Dictionary<string, int> MountedCounts { get; init; }
        public required Dictionary<string, int> UnmountedCounts { get; init; }
        public required IDisposable Host { get; init; }

        public void Dispose() => Host.Dispose();
    }

    private static Harness BuildHost(bool initial, bool withOtherwise = true)
    {
        var container = DomHelpers.CreateContainer();
        var condition = new Signal<bool>(initial);
        var mounted = new Dictionary<string, int>();
        var unmounted = new Dictionary<string, int>();

        IComponent[] BuildBranch(string label) =>
        [
            new Span
            {
                Children = [new DomText { Text = new Computed<string>(() => label) }],
            },
            new LifecycleProbe
            {
                Props = new LifecycleProbeProps
                {
                    OnMounted = () => mounted[label] = mounted.GetValueOrDefault(label) + 1,
                    OnUnmounted = () => unmounted[label] = unmounted.GetValueOrDefault(label) + 1,
                },
            },
        ];

        var host = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new If
            {
                Condition = condition,
                Then = () => BuildBranch("then"),
                Otherwise = withOtherwise ? () => BuildBranch("else") : null,
            })
            .Build()
            .Mount();

        return new Harness
        {
            Container = container,
            Condition = condition,
            MountedCounts = mounted,
            UnmountedCounts = unmounted,
            Host = host,
        };
    }

    [Test]
    public async Task Renders_then_branch_when_condition_is_true()
    {
        using var h = BuildHost(initial: true);

        await Assert.That(h.Container.TextContent).IsEqualTo("then");
        await Assert.That(h.Container.ChildElementCount).IsEqualTo(1u);
        await Assert.That(h.MountedCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["then"] = 1,
        });
        await Assert.That(h.UnmountedCounts).IsEmpty();
    }

    [Test]
    public async Task Renders_otherwise_branch_when_condition_is_false()
    {
        using var h = BuildHost(initial: false);

        await Assert.That(h.Container.TextContent).IsEqualTo("else");
        await Assert.That(h.Container.ChildElementCount).IsEqualTo(1u);
        await Assert.That(h.MountedCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["else"] = 1,
        });
        await Assert.That(h.UnmountedCounts).IsEmpty();
    }

    [Test]
    public async Task Renders_nothing_when_condition_is_false_and_no_otherwise()
    {
        using var h = BuildHost(initial: false, withOtherwise: false);

        await Assert.That(h.Container.TextContent).IsEqualTo("");
        await Assert.That(h.Container.ChildElementCount).IsEqualTo(0u);
        await Assert.That(h.MountedCounts).IsEmpty();
        await Assert.That(h.UnmountedCounts).IsEmpty();
    }

    [Test]
    public async Task Switches_from_then_to_otherwise()
    {
        using var h = BuildHost(initial: true);

        h.Condition.Value = false;

        await Assert.That(h.Container.TextContent).IsEqualTo("else");
        await Assert.That(h.Container.ChildElementCount).IsEqualTo(1u);
        await Assert.That(h.MountedCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["then"] = 1,
            ["else"] = 1,
        });
        await Assert.That(h.UnmountedCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["then"] = 1,
        });
    }

    [Test]
    public async Task Switches_from_otherwise_to_then()
    {
        using var h = BuildHost(initial: false);

        h.Condition.Value = true;

        await Assert.That(h.Container.TextContent).IsEqualTo("then");
        await Assert.That(h.Container.ChildElementCount).IsEqualTo(1u);
        await Assert.That(h.MountedCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["then"] = 1,
            ["else"] = 1,
        });
        await Assert.That(h.UnmountedCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["else"] = 1,
        });
    }

    [Test]
    public async Task Toggles_back_and_forth_remounts_each_branch()
    {
        using var h = BuildHost(initial: true);

        h.Condition.Value = false;
        h.Condition.Value = true;
        h.Condition.Value = false;

        await Assert.That(h.Container.TextContent).IsEqualTo("else");
        await Assert.That(h.MountedCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["then"] = 2,
            ["else"] = 2,
        });
        await Assert.That(h.UnmountedCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["then"] = 2,
            ["else"] = 1,
        });
    }

    [Test]
    public async Task Condition_recomputed_with_same_result_does_not_remount()
    {
        // Drive the condition via a derivation of an int signal so that the
        // underlying signal value changes (forcing the Effect to re-run) while
        // the boolean result of Condition stays the same. This exercises the
        // `current.Value == value` short-circuit inside If.
        var container = DomHelpers.CreateContainer();
        var counter = new Signal<int>(0);
        var mounted = new Dictionary<string, int>();
        var unmounted = new Dictionary<string, int>();

        IComponent[] BuildBranch(string label) =>
        [
            new Span
            {
                Children = [new DomText { Text = new Computed<string>(() => label) }],
            },
            new LifecycleProbe
            {
                Props = new LifecycleProbeProps
                {
                    OnMounted = () => mounted[label] = mounted.GetValueOrDefault(label) + 1,
                    OnUnmounted = () => unmounted[label] = unmounted.GetValueOrDefault(label) + 1,
                },
            },
        ];

        using var host = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new If
            {
                Condition = new Computed<bool>(() => counter.Value % 2 == 0),
                Then = () => BuildBranch("then"),
                Otherwise = () => BuildBranch("else"),
            })
            .Build()
            .Mount();

        await Assert.That(container.TextContent).IsEqualTo("then");

        // Different signal values, same condition result — Effect re-runs but
        // If must not remount the branch.
        counter.Value = 2;
        counter.Value = 4;
        counter.Value = 6;

        await Assert.That(container.TextContent).IsEqualTo("then");
        await Assert.That(mounted).IsEquivalentTo(new Dictionary<string, int>
        {
            ["then"] = 1,
        });
        await Assert.That(unmounted).IsEmpty();
    }

    [Test]
    public async Task Switches_to_empty_when_no_otherwise_and_condition_false()
    {
        using var h = BuildHost(initial: true, withOtherwise: false);

        h.Condition.Value = false;

        await Assert.That(h.Container.TextContent).IsEqualTo("");
        await Assert.That(h.Container.ChildElementCount).IsEqualTo(0u);
        await Assert.That(h.UnmountedCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["then"] = 1,
        });
    }

    [Test]
    public async Task Switches_back_from_empty_when_no_otherwise()
    {
        using var h = BuildHost(initial: false, withOtherwise: false);

        h.Condition.Value = true;

        await Assert.That(h.Container.TextContent).IsEqualTo("then");
        await Assert.That(h.Container.ChildElementCount).IsEqualTo(1u);
        await Assert.That(h.MountedCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["then"] = 1,
        });
        await Assert.That(h.UnmountedCounts).IsEmpty();
    }

    [Test]
    public async Task Nested_if_is_unmounted_when_parent_branch_is_torn_down()
    {
        // Parent If has no Otherwise. Its Then branch contains a nested If.
        // Flipping the parent to false must dispose the parent branch's
        // EffectScope, which in turn must unmount the nested child branch.
        var container = DomHelpers.CreateContainer();
        var outer = new Signal<bool>(true);
        var inner = new Signal<bool>(true);
        var mounted = new Dictionary<string, int>();
        var unmounted = new Dictionary<string, int>();

        IComponent[] BuildBranch(string label) =>
        [
            new Span
            {
                Children = [new DomText { Text = new Computed<string>(() => label) }],
            },
            new LifecycleProbe
            {
                Props = new LifecycleProbeProps
                {
                    OnMounted = () => mounted[label] = mounted.GetValueOrDefault(label) + 1,
                    OnUnmounted = () => unmounted[label] = unmounted.GetValueOrDefault(label) + 1,
                },
            },
        ];

        using var host = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new If
            {
                Condition = outer,
                Then = () =>
                [
                    new If
                    {
                        Condition = inner,
                        Then = () => BuildBranch("inner-then"),
                        Otherwise = () => BuildBranch("inner-else"),
                    },
                ],
                Otherwise = null,
            })
            .Build()
            .Mount();

        await Assert.That(container.TextContent).IsEqualTo("inner-then");
        await Assert.That(mounted).IsEquivalentTo(new Dictionary<string, int>
        {
            ["inner-then"] = 1,
        });
        await Assert.That(unmounted).IsEmpty();

        // Flip inner first to ensure nested toggling works while parent is active.
        inner.Value = false;
        await Assert.That(container.TextContent).IsEqualTo("inner-else");
        await Assert.That(mounted).IsEquivalentTo(new Dictionary<string, int>
        {
            ["inner-then"] = 1,
            ["inner-else"] = 1,
        });
        await Assert.That(unmounted).IsEquivalentTo(new Dictionary<string, int>
        {
            ["inner-then"] = 1,
        });

        // Tear down the parent branch — the nested child's currently active
        // branch ("inner-else") must be unmounted as part of the cascade.
        outer.Value = false;
        await Assert.That(container.TextContent).IsEqualTo("");
        await Assert.That(container.ChildElementCount).IsEqualTo(0u);
        await Assert.That(unmounted).IsEquivalentTo(new Dictionary<string, int>
        {
            ["inner-then"] = 1,
            ["inner-else"] = 1,
        });

        // Bring the parent back — nested If is constructed fresh and mounts
        // its current ("inner-else") branch.
        outer.Value = true;
        await Assert.That(container.TextContent).IsEqualTo("inner-else");
        await Assert.That(mounted).IsEquivalentTo(new Dictionary<string, int>
        {
            ["inner-then"] = 1,
            ["inner-else"] = 2,
        });
    }

    [Test]
    public async Task Disposing_host_unmounts_active_branch()
    {
        var h = BuildHost(initial: true);

        h.Dispose();

        await Assert.That(h.UnmountedCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["then"] = 1,
        });
    }

    [Test]
    public async Task Reacts_to_signal_changes_inside_condition()
    {
        var container = DomHelpers.CreateContainer();
        var counter = new Signal<int>(0);
        var mounted = new Dictionary<string, int>();
        var unmounted = new Dictionary<string, int>();

        IComponent[] BuildBranch(string label) =>
        [
            new Span
            {
                Children = [new DomText { Text = new Computed<string>(() => label) }],
            },
            new LifecycleProbe
            {
                Props = new LifecycleProbeProps
                {
                    OnMounted = () => mounted[label] = mounted.GetValueOrDefault(label) + 1,
                    OnUnmounted = () => unmounted[label] = unmounted.GetValueOrDefault(label) + 1,
                },
            },
        ];

        using var host = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new If
            {
                Condition = new Computed<bool>(() => counter.Value % 2 == 0),
                Then = () => BuildBranch("even"),
                Otherwise = () => BuildBranch("odd"),
            })
            .Build()
            .Mount();

        await Assert.That(container.TextContent).IsEqualTo("even");

        counter.Value = 1;
        await Assert.That(container.TextContent).IsEqualTo("odd");

        // Same parity — no flip, no remount.
        counter.Value = 3;
        await Assert.That(container.TextContent).IsEqualTo("odd");

        counter.Value = 4;
        await Assert.That(container.TextContent).IsEqualTo("even");

        await Assert.That(mounted).IsEquivalentTo(new Dictionary<string, int>
        {
            ["even"] = 2,
            ["odd"] = 1,
        });
        await Assert.That(unmounted).IsEquivalentTo(new Dictionary<string, int>
        {
            ["even"] = 1,
            ["odd"] = 1,
        });
    }
}
