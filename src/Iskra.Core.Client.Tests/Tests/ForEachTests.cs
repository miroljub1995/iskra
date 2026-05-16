using Iskra.Core.Client.Tests.TestUtils;
using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Core.RenderRoot;
using Iskra.JSCore;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.Client.Tests;

public class ForEachTests
{
    private sealed class Harness : IDisposable
    {
        public required Element Container { get; init; }
        public required Signal<IList<string>> Items { get; init; }
        public required Dictionary<string, int> MountedCounts { get; init; }
        public required Dictionary<string, int> UnmountedCounts { get; init; }
        public required Dictionary<string, int> SetupCounts { get; init; }
        public required IDisposable Host { get; init; }

        public void Dispose() => Host.Dispose();
    }

    private static Harness BuildHost(IList<string> initial)
    {
        var container = DomHelpers.CreateContainer();
        var items = new Signal<IList<string>>(initial);
        var mounted = new Dictionary<string, int>();
        var unmounted = new Dictionary<string, int>();
        var setupCounts = new Dictionary<string, int>();

        var host = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new ForEach<string, string>
            {
                Items = items,
                Key = s => s,
                ElementSetup = s =>
                {
                    var key = s.Value;
                    setupCounts[key] = setupCounts.GetValueOrDefault(key) + 1;
                    return
                    [
                        new Span
                        {
                            Children = [new DomText { Text = new Computed<string>(() => s.Value) }],
                        },
                        new LifecycleProbe
                        {
                            Props = new LifecycleProbeProps
                            {
                                OnMounted = () =>
                                {
                                    mounted[key] = mounted.GetValueOrDefault(key) + 1;
                                },
                                OnUnmounted = () =>
                                {
                                    unmounted[key] = unmounted.GetValueOrDefault(key) + 1;
                                },
                            },
                        },
                    ];
                },
            })
            .Build()
            .Mount();

        return new Harness
        {
            Container = container,
            Items = items,
            MountedCounts = mounted,
            UnmountedCounts = unmounted,
            SetupCounts = setupCounts,
            Host = host,
        };
    }

    [Test]
    public async Task Renders_initial_items()
    {
        using var h = BuildHost(["a", "b", "c"]);

        await Assert.That(h.Container.TextContent).IsEqualTo("abc");
        await Assert.That(h.Container.ChildElementCount).IsEqualTo(3u);
        await Assert.That(h.MountedCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["a"] = 1,
            ["b"] = 1,
            ["c"] = 1,
        });
        await Assert.That(h.UnmountedCounts).IsEmpty();
    }

    [Test]
    public async Task Adds_new_items_at_end()
    {
        using var h = BuildHost(["a", "b"]);

        h.Items.Value = ["a", "b", "c"];

        await Assert.That(h.Container.TextContent).IsEqualTo("abc");
        await Assert.That(h.Container.ChildElementCount).IsEqualTo(3u);
        await Assert.That(h.MountedCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["a"] = 1,
            ["b"] = 1,
            ["c"] = 1,
        });
        await Assert.That(h.UnmountedCounts).IsEmpty();
    }

    [Test]
    public async Task Adds_new_items_at_start()
    {
        using var h = BuildHost(["b", "c"]);

        h.Items.Value = ["a", "b", "c"];

        await Assert.That(h.Container.TextContent).IsEqualTo("abc");
        await Assert.That(h.Container.ChildElementCount).IsEqualTo(3u);
        await Assert.That(h.MountedCounts.Count).IsEqualTo(3);
        await Assert.That(h.MountedCounts["a"]).IsEqualTo(1);
        await Assert.That(h.MountedCounts["b"]).IsEqualTo(1);
        await Assert.That(h.MountedCounts["c"]).IsEqualTo(1);
        await Assert.That(h.UnmountedCounts).IsEmpty();
    }

    [Test]
    public async Task Inserts_in_middle()
    {
        using var h = BuildHost(["a", "c"]);

        h.Items.Value = ["a", "b", "c"];

        await Assert.That(h.Container.TextContent).IsEqualTo("abc");
        await Assert.That(h.Container.ChildElementCount).IsEqualTo(3u);
        await Assert.That(h.MountedCounts.Count).IsEqualTo(3);
        await Assert.That(h.MountedCounts["a"]).IsEqualTo(1);
        await Assert.That(h.MountedCounts["b"]).IsEqualTo(1);
        await Assert.That(h.MountedCounts["c"]).IsEqualTo(1);
        await Assert.That(h.UnmountedCounts).IsEmpty();
    }

    [Test]
    public async Task Removes_from_start()
    {
        using var h = BuildHost(["a", "b", "c"]);

        h.Items.Value = ["b", "c"];

        await Assert.That(h.Container.TextContent).IsEqualTo("bc");
        await Assert.That(h.Container.ChildElementCount).IsEqualTo(2u);
        await Assert.That(h.UnmountedCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["a"] = 1,
        });
        // 'b' and 'c' must NOT have been remounted
        await Assert.That(h.MountedCounts["b"]).IsEqualTo(1);
        await Assert.That(h.MountedCounts["c"]).IsEqualTo(1);
    }

    [Test]
    public async Task Removes_from_middle()
    {
        using var h = BuildHost(["a", "b", "c"]);

        h.Items.Value = ["a", "c"];

        await Assert.That(h.Container.TextContent).IsEqualTo("ac");
        await Assert.That(h.Container.ChildElementCount).IsEqualTo(2u);
        await Assert.That(h.UnmountedCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["b"] = 1,
        });
        await Assert.That(h.MountedCounts["a"]).IsEqualTo(1);
        await Assert.That(h.MountedCounts["c"]).IsEqualTo(1);
    }

    [Test]
    public async Task Removes_from_end()
    {
        using var h = BuildHost(["a", "b", "c"]);

        h.Items.Value = ["a", "b"];

        await Assert.That(h.Container.TextContent).IsEqualTo("ab");
        await Assert.That(h.Container.ChildElementCount).IsEqualTo(2u);
        await Assert.That(h.UnmountedCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["c"] = 1,
        });
        await Assert.That(h.MountedCounts["a"]).IsEqualTo(1);
        await Assert.That(h.MountedCounts["b"]).IsEqualTo(1);
    }

    [Test]
    public async Task Reorders_preserves_dom_nodes()
    {
        using var h = BuildHost(["a", "b", "c"]);

        var nodeA = h.Container.ChildNodes.Item(1);
        var nodeB = h.Container.ChildNodes.Item(4);
        var nodeC = h.Container.ChildNodes.Item(7);

        h.Items.Value = ["c", "a", "b"];

        await Assert.That(h.Container.TextContent).IsEqualTo("cab");
        await Assert.That(h.Container.ChildElementCount).IsEqualTo(3u);
        await Assert.That(h.Container.ChildNodes.Item(1)).IsEqualTo(nodeC);
        await Assert.That(h.Container.ChildNodes.Item(4)).IsEqualTo(nodeA);
        await Assert.That(h.Container.ChildNodes.Item(7)).IsEqualTo(nodeB);
        // No remount or unmount during a pure reorder
        await Assert.That(h.UnmountedCounts).IsEmpty();
        await Assert.That(h.MountedCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["a"] = 1,
            ["b"] = 1,
            ["c"] = 1,
        });
    }

    [Test]
    public async Task Clears_all_items()
    {
        using var h = BuildHost(["a", "b"]);

        h.Items.Value = [];

        await Assert.That(h.Container.TextContent).IsEqualTo("");
        await Assert.That(h.Container.ChildElementCount).IsEqualTo(0u);
        await Assert.That(h.UnmountedCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["a"] = 1,
            ["b"] = 1,
        });
    }

    [Test]
    public async Task Throws_on_duplicate_keys()
    {
        using var h = BuildHost(["a", "b"]);

        await Assert.That(() => h.Items.Value = ["a", "a"]).Throws<InvalidOperationException>();
    }

    [Test]
    public async Task Disposing_host_unmounts_all_items()
    {
        var h = BuildHost(["a", "b", "c"]);

        h.Dispose();

        await Assert.That(h.UnmountedCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["a"] = 1,
            ["b"] = 1,
            ["c"] = 1,
        });
    }

    [Test]
    public async Task ForEach_wraps_items_in_open_and_close_comments()
    {
        using var h = BuildHost(["a", "b"]);

        // ChildNodes for ["a","b"]: [0]=<!--[--> [1]=<span>a</span> [2..3]=LifecycleProbe-a comments
        //                            [4]=<span>b</span> [5..6]=LifecycleProbe-b comments [7]=<!--]-->
        var firstNode = h.Container.ChildNodes.Item(0);
        var lastNode  = h.Container.ChildNodes.Item(7);

        await Assert.That(firstNode).IsNotNull();
        await Assert.That(lastNode).IsNotNull();

        await Assert.That(firstNode!.NodeType).IsEqualTo(Node.COMMENT_NODE);
        await Assert.That(lastNode!.NodeType).IsEqualTo(Node.COMMENT_NODE);

        var firstComment = JSObjectProxyFactory.GetProxy<CharacterData>(firstNode.JSObject);
        var lastComment  = JSObjectProxyFactory.GetProxy<CharacterData>(lastNode.JSObject);

        await Assert.That(firstComment.Data).IsEqualTo("[");
        await Assert.That(lastComment.Data).IsEqualTo("]");
    }

    [Test]
    public async Task ElementSetup_is_called_once_per_key_and_not_on_reorder_or_remove()
    {
        using var h = BuildHost(["a", "b", "c"]);

        h.Items.Value = ["c", "a", "b"];
        h.Items.Value = ["c", "b"];

        await Assert.That(h.SetupCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["a"] = 1,
            ["b"] = 1,
            ["c"] = 1,
        });
    }

    // -------------------------------------------------------------------------
    // Multi-slot reordering: each item renders TWO <span> elements so that
    // ComposedComponent internally holds multiple slots per item.
    // These tests verify that MoveRangeAfter relocates ALL slots, not just the first.
    // -------------------------------------------------------------------------

    private sealed class MultiSlotHarness : IDisposable
    {
        public required Element Container { get; init; }
        public required Signal<IList<string>> Items { get; init; }
        public required IDisposable Host { get; init; }

        public void Dispose() => Host.Dispose();
    }

    private static MultiSlotHarness BuildMultiSlotHost(IList<string> initial)
    {
        var container = DomHelpers.CreateContainer();
        var items = new Signal<IList<string>>(initial);

        var host = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new ForEach<string, string>
            {
                Items = items,
                Key = s => s,
                // Each item produces two <span> elements: one with "-first" and one with "-second" suffix.
                ElementSetup = s => [
                    new Span { Children = [new DomText { Text = new Computed<string>(() => s.Value + "-first") }] },
                    new Span { Children = [new DomText { Text = new Computed<string>(() => s.Value + "-second") }] },
                ],
            })
            .Build()
            .Mount();

        return new MultiSlotHarness
        {
            Container = container,
            Items = items,
            Host = host,
        };
    }

    [Test]
    public async Task MultiSlot_renders_initial_items()
    {
        using var h = BuildMultiSlotHost(["a", "b"]);

        await Assert.That(h.Container.TextContent).IsEqualTo("a-firsta-secondb-firstb-second");
        await Assert.That(h.Container.ChildElementCount).IsEqualTo(4u);
    }

    [Test]
    public async Task MultiSlot_reorder_moves_all_slots()
    {
        using var h = BuildMultiSlotHost(["a", "b", "c"]);

        // Capture the original DOM nodes for each span
        var aFirst  = h.Container.ChildNodes.Item(1);
        var aSecond = h.Container.ChildNodes.Item(2);
        var bFirst  = h.Container.ChildNodes.Item(3);
        var bSecond = h.Container.ChildNodes.Item(4);
        var cFirst  = h.Container.ChildNodes.Item(5);
        var cSecond = h.Container.ChildNodes.Item(6);

        h.Items.Value = ["c", "a", "b"];

        // Text order
        await Assert.That(h.Container.TextContent).IsEqualTo("c-firstc-seconda-firsta-secondb-firstb-second");
        await Assert.That(h.Container.ChildElementCount).IsEqualTo(6u);

        // All original DOM nodes must have moved — no remounts
        await Assert.That(h.Container.ChildNodes.Item(1)).IsEqualTo(cFirst);
        await Assert.That(h.Container.ChildNodes.Item(2)).IsEqualTo(cSecond);
        await Assert.That(h.Container.ChildNodes.Item(3)).IsEqualTo(aFirst);
        await Assert.That(h.Container.ChildNodes.Item(4)).IsEqualTo(aSecond);
        await Assert.That(h.Container.ChildNodes.Item(5)).IsEqualTo(bFirst);
        await Assert.That(h.Container.ChildNodes.Item(6)).IsEqualTo(bSecond);
    }

    [Test]
    public async Task MultiSlot_reorder_to_start_moves_all_slots()
    {
        using var h = BuildMultiSlotHost(["b", "c"]);

        var bFirst  = h.Container.ChildNodes.Item(1);
        var bSecond = h.Container.ChildNodes.Item(2);
        var cFirst  = h.Container.ChildNodes.Item(3);
        var cSecond = h.Container.ChildNodes.Item(4);

        h.Items.Value = ["a", "b", "c"];

        await Assert.That(h.Container.TextContent).IsEqualTo("a-firsta-secondb-firstb-secondc-firstc-second");
        await Assert.That(h.Container.ChildElementCount).IsEqualTo(6u);

        // "b" and "c" must not have been remounted — original nodes preserved
        await Assert.That(h.Container.ChildNodes.Item(3)).IsEqualTo(bFirst);
        await Assert.That(h.Container.ChildNodes.Item(4)).IsEqualTo(bSecond);
        await Assert.That(h.Container.ChildNodes.Item(5)).IsEqualTo(cFirst);
        await Assert.That(h.Container.ChildNodes.Item(6)).IsEqualTo(cSecond);
    }

    [Test]
    public async Task MultiSlot_remove_disposes_all_slots()
    {
        using var h = BuildMultiSlotHost(["a", "b", "c"]);

        h.Items.Value = ["a", "c"];

        await Assert.That(h.Container.TextContent).IsEqualTo("a-firsta-secondc-firstc-second");
        await Assert.That(h.Container.ChildElementCount).IsEqualTo(4u);
    }

    [Test]
    public async Task MultiSlot_reverse_order()
    {
        using var h = BuildMultiSlotHost(["a", "b", "c"]);

        var aFirst  = h.Container.ChildNodes.Item(1);
        var aSecond = h.Container.ChildNodes.Item(2);
        var bFirst  = h.Container.ChildNodes.Item(3);
        var bSecond = h.Container.ChildNodes.Item(4);
        var cFirst  = h.Container.ChildNodes.Item(5);
        var cSecond = h.Container.ChildNodes.Item(6);

        h.Items.Value = ["c", "b", "a"];

        await Assert.That(h.Container.TextContent).IsEqualTo("c-firstc-secondb-firstb-seconda-firsta-second");
        await Assert.That(h.Container.ChildElementCount).IsEqualTo(6u);

        await Assert.That(h.Container.ChildNodes.Item(1)).IsEqualTo(cFirst);
        await Assert.That(h.Container.ChildNodes.Item(2)).IsEqualTo(cSecond);
        await Assert.That(h.Container.ChildNodes.Item(3)).IsEqualTo(bFirst);
        await Assert.That(h.Container.ChildNodes.Item(4)).IsEqualTo(bSecond);
        await Assert.That(h.Container.ChildNodes.Item(5)).IsEqualTo(aFirst);
        await Assert.That(h.Container.ChildNodes.Item(6)).IsEqualTo(aSecond);
    }

    [Test]
    public async Task Same_key_with_updated_element_updates_signal_without_remount()
    {
        // Use (key, payload) tuples so we can change the element payload while keeping the key.
        var container = DomHelpers.CreateContainer();
        var items = new Signal<IList<(string Key, string Payload)>>(
            [("a", "A1"), ("b", "B1")]);
        var setupCounts = new Dictionary<string, int>();
        var mountedCounts = new Dictionary<string, int>();
        var unmountedCounts = new Dictionary<string, int>();

        using var host = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new ForEach<(string Key, string Payload), string>
            {
                Items = items,
                Key = item => item.Key,
                ElementSetup = item =>
                {
                    var key = item.Value.Key;
                    setupCounts[key] = setupCounts.GetValueOrDefault(key) + 1;
                    return
                    [
                        new Span
                        {
                            Children = [new DomText { Text = new Computed<string>(() => item.Value.Payload) }],
                        },
                        new LifecycleProbe
                        {
                            Props = new LifecycleProbeProps
                            {
                                OnMounted = () =>
                                {
                                    mountedCounts[key] = mountedCounts.GetValueOrDefault(key) + 1;
                                },
                                OnUnmounted = () =>
                                {
                                    unmountedCounts[key] = unmountedCounts.GetValueOrDefault(key) + 1;
                                },
                            },
                        },
                    ];
                },
            })
            .Build()
            .Mount();

        await Assert.That(container.TextContent).IsEqualTo("A1B1");

        // Capture DOM nodes to verify they are reused.
        // Layout: [0]=<!--[--> [1]=<span>A1</span> [2..3]=LifecycleProbe comments
        //         [4]=<span>B1</span> [5..6]=LifecycleProbe comments [7]=<!--]-->
        var nodeA = container.ChildNodes.Item(1);
        var nodeB = container.ChildNodes.Item(4);

        // Same keys, updated payloads.
        items.Value = [("a", "A2"), ("b", "B2")];

        await Assert.That(container.TextContent).IsEqualTo("A2B2");
        await Assert.That(container.ChildNodes.Item(1)).IsEqualTo(nodeA);
        await Assert.That(container.ChildNodes.Item(4)).IsEqualTo(nodeB);

        // Same keys reordered with updated payloads — still no remount, signals updated.
        items.Value = [("b", "B3"), ("a", "A3")];

        await Assert.That(container.TextContent).IsEqualTo("B3A3");

        // ElementSetup must have been invoked exactly once per key, despite element value changes.
        await Assert.That(setupCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["a"] = 1,
            ["b"] = 1,
        });
        await Assert.That(mountedCounts).IsEquivalentTo(new Dictionary<string, int>
        {
            ["a"] = 1,
            ["b"] = 1,
        });
        await Assert.That(unmountedCounts).IsEmpty();
    }

    [Test]
    public async Task Unmounting_ForEach_via_If_unmounts_all_items()
    {
        var container = DomHelpers.CreateContainer();
        var condition = new Signal<bool>(true);
        var items = new Signal<IList<string>>(["a", "b", "c"]);
        var mounted = new Dictionary<string, int>();
        var unmounted = new Dictionary<string, int>();

        using var host = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new If
            {
                Condition = condition,
                Then = () =>
                [
                    new ForEach<string, string>
                    {
                        Items = items,
                        Key = s => s,
                        ElementSetup = s =>
                        [
                            new Span
                            {
                                Children = [new DomText { Text = new Computed<string>(() => s.Value) }],
                            },
                            new LifecycleProbe
                            {
                                Props = new LifecycleProbeProps
                                {
                                    OnMounted = () =>
                                    {
                                        mounted[s.Value] = mounted.GetValueOrDefault(s.Value) + 1;
                                    },
                                    OnUnmounted = () =>
                                    {
                                        unmounted[s.Value] = unmounted.GetValueOrDefault(s.Value) + 1;
                                    },
                                },
                            },
                        ],
                    },
                ],
            })
            .Build()
            .Mount();

        await Assert.That(container.TextContent).IsEqualTo("abc");
        await Assert.That(container.ChildElementCount).IsEqualTo(3u);
        await Assert.That(mounted).IsEquivalentTo(new Dictionary<string, int>
        {
            ["a"] = 1,
            ["b"] = 1,
            ["c"] = 1,
        });
        await Assert.That(unmounted).IsEmpty();

        // Flip condition to false — ForEach should be unmounted, all items unmounted.
        condition.Value = false;

        await Assert.That(container.TextContent).IsEqualTo("");
        await Assert.That(container.ChildElementCount).IsEqualTo(0u);
        await Assert.That(unmounted).IsEquivalentTo(new Dictionary<string, int>
        {
            ["a"] = 1,
            ["b"] = 1,
            ["c"] = 1,
        });
    }
}
