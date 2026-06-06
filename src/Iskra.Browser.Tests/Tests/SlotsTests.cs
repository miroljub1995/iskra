using Iskra.Browser.Tests.TestUtils;
using Iskra.Core.Components;
using Iskra.Dom.Components;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Browser.Tests;

public class SlotsTests
{
    // -- Slots definitions ------------------------------------------------

    private sealed class SingleSlot
    {
        public required Func<IComponent[]> Default { get; init; }
    }

    private sealed class MultiSlots
    {
        public required Func<IComponent[]> Header { get; init; }
        public Func<IComponent[]>? Footer { get; init; }
    }

    private sealed class SingleSlotWithSignal
    {
        public required Func<IReadOnlySignal<string>, IComponent[]> Default { get; init; }
    }

    // -- Components using slots -------------------------------------------

    private sealed class CardProps
    {
        public IReadOnlySignal<string>? Title { get; init; }
    }

    private sealed class CardWithDefault : BaseComponent<CardProps, NoEvents, SingleSlot, NoExpose>
    {
        protected override IComponent[] Setup(out NoExpose exposed)
        {
            exposed = default;
            return
            [
                new Div
                {
                    Children = Slots?.Default() ?? [],
                },
            ];
        }
    }

    private sealed class CardWithNamedSlots : BaseComponent<CardProps, NoEvents, MultiSlots, NoExpose>
    {
        protected override IComponent[] Setup(out NoExpose exposed)
        {
            exposed = default;
            return
            [
                new Div
                {
                    Children = Slots?.Header() ?? [],
                },
                new Div
                {
                    Children =
                    [
                        new DomText { Text = Props.Title ?? new Signal<string>("") },
                    ],
                },
                new Div
                {
                    Children = Slots?.Footer?.Invoke() ?? [],
                },
            ];
        }
    }

    private sealed record CardWithDefaultSignalExpose(Signal<string> Title);

    private sealed class CardWithDefaultSignal : BaseComponent<NoProps, NoEvents, SingleSlotWithSignal, CardWithDefaultSignalExpose>
    {
        protected override IComponent[] Setup(out CardWithDefaultSignalExpose exposed)
        {
            var title = new Signal<string>("initial");
            exposed = new CardWithDefaultSignalExpose(title);
            return
            [
                new Div
                {
                    Children = Slots?.Default(title) ?? [],
                },
            ];
        }
    }

    // -- Tests ------------------------------------------------------------

    [Test]
    public async Task Slot_content_mounts_in_dom()
    {
        var container = DomHelpers.CreateContainer();

        using var host = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new CardWithDefault
            {
                Props = new CardProps(),
                Slots = new SingleSlot
                {
                    Default = () =>
                    [
                        new Span
                        {
                            Children = [new DomText { Text = new Signal<string>("hello") }],
                        },
                    ],
                },
            })
            .Build()
            .Mount();

        await Assert.That(container.TextContent).IsEqualTo("hello");
        await Assert.That(container.QuerySelector("span")).IsNotNull();
    }

    [Test]
    public async Task Slot_content_unmounts_on_dispose()
    {
        var container = DomHelpers.CreateContainer();
        var mounted = 0;
        var unmounted = 0;

        var host = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new CardWithDefault
            {
                Props = new CardProps(),
                Slots = new SingleSlot
                {
                    Default = () =>
                    [
                        new LifecycleProbe
                        {
                            Props = new LifecycleProbeProps
                            {
                                OnMounted = () => mounted++,
                                OnUnmounted = () => unmounted++,
                            },
                        },
                    ],
                },
            })
            .Build()
            .Mount();

        await Assert.That(mounted).IsEqualTo(1);
        await Assert.That(unmounted).IsEqualTo(0);

        host.Dispose();

        await Assert.That(unmounted).IsEqualTo(1);
    }

    [Test]
    public async Task Reactive_signal_in_slot_updates_dom()
    {
        var container = DomHelpers.CreateContainer();
        var text = new Signal<string>("before");

        using var host = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new CardWithDefault
            {
                Props = new CardProps(),
                Slots = new SingleSlot
                {
                    Default = () =>
                    [
                        new DomText { Text = text },
                    ],
                },
            })
            .Build()
            .Mount();

        await Assert.That(container.TextContent).IsEqualTo("before");

        text.Value = "after";

        await Assert.That(container.TextContent).IsEqualTo("after");
    }

    [Test]
    public async Task Multiple_named_slots_render_in_correct_positions()
    {
        var container = DomHelpers.CreateContainer();

        using var host = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new CardWithNamedSlots
            {
                Props = new CardProps { Title = new Signal<string>("body") },
                Slots = new MultiSlots
                {
                    Header = () =>
                    [
                        new DomText { Text = new Signal<string>("head") },
                    ],
                    Footer = () =>
                    [
                        new DomText { Text = new Signal<string>("foot") },
                    ],
                },
            })
            .Build()
            .Mount();

        await Assert.That(container.TextContent).IsEqualTo("headbodyfoot");

        // Verify order: 3 divs (header, body, footer)
        var divs = container.QuerySelectorAll("div");
        await Assert.That(divs.Length).IsEqualTo(3u);
        await Assert.That(divs.Item(0)!.TextContent).IsEqualTo("head");
        await Assert.That(divs.Item(1)!.TextContent).IsEqualTo("body");
        await Assert.That(divs.Item(2)!.TextContent).IsEqualTo("foot");
    }

    [Test]
    public async Task No_slots_provided_renders_empty_fallback()
    {
        var container = DomHelpers.CreateContainer();

        using var host = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new CardWithDefault
            {
                Props = new CardProps(),
                // Slots intentionally omitted
            })
            .Build()
            .Mount();

        // The component renders a <div> with no children
        await Assert.That(container.TextContent).IsEqualTo("");
        await Assert.That(container.QuerySelector("div")).IsNotNull();
    }

    [Test]
    public async Task Slot_receives_readonly_signal_and_renders_text()
    {
        var container = DomHelpers.CreateContainer();
        var cardRef = new Signal<CardWithDefaultSignalExpose?>(null);

        using var host = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new CardWithDefaultSignal
            {
                Props = new NoProps(),
                Ref = cardRef,
                Slots = new SingleSlotWithSignal
                {
                    Default = (text) =>
                    [
                        new DomText { Text = text },
                    ],
                },
            })
            .Build()
            .Mount();

        await Assert.That(container.TextContent).IsEqualTo("initial");

        cardRef.Value!.Title.Value = "updated";

        await Assert.That(container.TextContent).IsEqualTo("updated");
    }
}
