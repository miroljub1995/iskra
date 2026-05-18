using Iskra.Core.Client.Tests.TestUtils;
using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.Client.Tests;

public class TeleportTests
{
    private sealed class Harness : IDisposable
    {
        public required Element Container { get; init; }
        public required Element InnerDiv { get; init; }
        public required Signal<bool> Disabled { get; init; }
        public required int[] MountedCount { get; init; }
        public required IDisposable Host { get; init; }

        public void Dispose() => Host.Dispose();
    }

    // Realistic layout: Teleport is nested inside an inner Div; TeleportSlot sits at the
    // end of the outer Div (the common modal-overlay / portal pattern).
    // This exercises the queuing path in TeleportFeature because TeleportSlot is mounted
    // after the inner Div (which contains the Teleport component).
    private static Harness BuildHost(bool initialDisabled = false)
    {
        var container = DomHelpers.CreateContainer();
        var disabled = new Signal<bool>(initialDisabled);
        var mountedCount = new int[1];

        var host = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() =>
            {
                var teleportSlot = Teleport.CreateTeleport();
                return new Div
                {
                    Children =
                    [
                        new Div
                        {
                            Children =
                            [
                                new Span { Children = [new DomText { Text = new Signal<string>("neighbor") }] },
                                new Teleport
                                {
                                    Disabled = disabled,
                                    Children =
                                    [
                                        new Span { Children = [new DomText { Text = new Signal<string>("content") }] },
                                        new LifecycleProbe
                                        {
                                            Props = new LifecycleProbeProps
                                            {
                                                OnMounted = () => mountedCount[0]++,
                                            },
                                        },
                                    ],
                                },
                            ],
                        },
                        teleportSlot,
                    ],
                };
            })
            .Build()
            .Mount();

        return new Harness
        {
            Container = container,
            InnerDiv = container.FirstElementChild!.FirstElementChild!,
            Disabled = disabled,
            MountedCount = mountedCount,
            Host = host,
        };
    }

    [Test]
    public async Task Teleports_children_to_slot_position()
    {
        using var h = BuildHost();

        // Content is outside the inner div (teleported to TeleportSlot at end of outer div).
        await Assert.That(h.InnerDiv.TextContent).IsEqualTo("neighbor");
        await Assert.That(h.Container.TextContent).IsEqualTo("neighborcontent");
        await Assert.That(h.MountedCount[0]).IsEqualTo(1);
    }

    [Test]
    public async Task Disabled_true_renders_children_in_place()
    {
        using var h = BuildHost(initialDisabled: true);

        // Content stays inside the inner div (Teleport's own in-place position).
        await Assert.That(h.InnerDiv.TextContent).IsEqualTo("neighborcontent");
        await Assert.That(h.MountedCount[0]).IsEqualTo(1);
    }

    [Test]
    public async Task Enabling_disabled_moves_children_to_slot_without_remounting()
    {
        using var h = BuildHost(initialDisabled: true);

        await Assert.That(h.InnerDiv.TextContent).IsEqualTo("neighborcontent");

        h.Disabled.Value = false;

        // Content moved out of the inner div to the TeleportSlot position.
        await Assert.That(h.InnerDiv.TextContent).IsEqualTo("neighbor");
        await Assert.That(h.Container.TextContent).IsEqualTo("neighborcontent");
        // Children must not have been remounted — mount count stays at 1.
        await Assert.That(h.MountedCount[0]).IsEqualTo(1);
    }

    [Test]
    public async Task Disabling_moves_children_back_in_place_without_remounting()
    {
        using var h = BuildHost(initialDisabled: false);

        await Assert.That(h.InnerDiv.TextContent).IsEqualTo("neighbor");

        h.Disabled.Value = true;

        await Assert.That(h.InnerDiv.TextContent).IsEqualTo("neighborcontent");
        await Assert.That(h.MountedCount[0]).IsEqualTo(1);
    }

    [Test]
    public async Task Toggling_disabled_multiple_times_never_remounts_children()
    {
        using var h = BuildHost(initialDisabled: false);

        h.Disabled.Value = true;
        h.Disabled.Value = false;
        h.Disabled.Value = true;

        await Assert.That(h.InnerDiv.TextContent).IsEqualTo("neighborcontent");
        await Assert.That(h.MountedCount[0]).IsEqualTo(1);
    }

    [Test]
    public async Task Slot_before_teleport_in_tree_teleports_correctly()
    {
        // TeleportSlot is mounted BEFORE the inner Div that contains Teleport —
        // exercises the immediate-delivery path in TeleportFeature (slot already registered
        // when Teleport calls OnSlotSet).
        var container = DomHelpers.CreateContainer();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() =>
            {
                var teleportSlot = Teleport.CreateTeleport();
                return new Div
                {
                    Children =
                    [
                        teleportSlot,
                        new Div
                        {
                            Children =
                            [
                                new Span { Children = [new DomText { Text = new Signal<string>("neighbor") }] },
                                new Teleport
                                {
                                    Children = [new Span { Children = [new DomText { Text = new Signal<string>("content") }] }],
                                },
                            ],
                        },
                    ],
                };
            })
            .Build()
            .Mount();

        // Content appears at TeleportSlot position (before the inner div), inner div has only neighbor.
        var outerDiv = container.FirstElementChild!;
        var innerDiv = outerDiv.LastElementChild!;
        await Assert.That(innerDiv.TextContent).IsEqualTo("neighbor");
        await Assert.That(container.TextContent).IsEqualTo("contentneighbor");
    }
}
