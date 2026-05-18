using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.Server.Tests.Tests;

public class TeleportTests
{
    // Realistic layout: Teleport is nested inside an inner Div; TeleportSlot sits at the
    // end of the outer Div (the common modal-overlay / portal pattern).
    // This exercises the queuing path in TeleportFeature because TeleportSlot is mounted
    // after the inner Div (which contains the Teleport component).
    private static IDisposable BuildHost(
        SsrRenderRoot root,
        bool clientOnly,
        IReadOnlySignal<bool>? disabled = null) =>
        new IskraHostBuilder()
            .UseRootRenderer(root)
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
                                    ClientOnly = clientOnly,
                                    Disabled = disabled,
                                    Children = [new Span { Children = [new DomText { Text = new Signal<string>("content") }] }],
                                },
                            ],
                        },
                        teleportSlot,
                    ],
                };
            })
            .Build()
            .Mount();

    [Test]
    public async Task ClientOnly_false_teleports_children_to_slot_position()
    {
        var root = new SsrRenderRoot();
        using var _ = BuildHost(root, clientOnly: false);

        var output = await SsrHelpers.RenderAsync(root);

        // Content appears at TeleportSlot position (after the inner div), not inside the inner div.
        await Assert.That(output).IsEqualTo("<div><div><span>neighbor</span></div><span>content</span></div>");
    }

    [Test]
    public async Task ClientOnly_true_suppresses_children_in_ssr_output()
    {
        var root = new SsrRenderRoot();
        using var _ = BuildHost(root, clientOnly: true);

        var output = await SsrHelpers.RenderAsync(root);

        // No content rendered; inner div contains only the neighbor span.
        await Assert.That(output).IsEqualTo("<div><div><span>neighbor</span></div></div>");
    }

    [Test]
    public async Task Disabled_true_renders_children_in_place()
    {
        var root = new SsrRenderRoot();
        using var _ = BuildHost(root, clientOnly: false, disabled: new Signal<bool>(true));

        var output = await SsrHelpers.RenderAsync(root);

        // Content stays inside the inner div (after neighbor), not at the outer TeleportSlot position.
        await Assert.That(output).IsEqualTo("<div><div><span>neighbor</span><span>content</span></div></div>");
    }

    [Test]
    public async Task Slot_before_teleport_in_tree_teleports_correctly()
    {
        // TeleportSlot is mounted BEFORE the inner Div that contains Teleport —
        // exercises the immediate-delivery path in TeleportFeature (slot already registered
        // when Teleport calls OnSlotSet).
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
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
                                    ClientOnly = false,
                                    Children = [new Span { Children = [new DomText { Text = new Signal<string>("content") }] }],
                                },
                            ],
                        },
                    ],
                };
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        // Content appears right after TeleportSlot (at the start of outer div), before the inner div.
        await Assert.That(output).IsEqualTo("<div><span>content</span><div><span>neighbor</span></div></div>");
    }
}
