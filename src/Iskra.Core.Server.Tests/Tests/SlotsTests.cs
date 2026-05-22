using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.Server.Tests.Tests;

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
                new Header
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
                new Footer
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
    public async Task Single_slot_renders_content()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
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

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo(
            "<!--[--><div><span>hello</span></div><!--]-->");
    }

    [Test]
    public async Task Multiple_named_slots_render_in_correct_positions()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
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

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo(
            "<!--[--><header>head</header><div>body</div><footer>foot</footer><!--]-->");
    }

    [Test]
    public async Task Optional_slot_renders_nothing_when_not_provided()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new CardWithNamedSlots
            {
                Props = new CardProps { Title = new Signal<string>("body") },
                Slots = new MultiSlots
                {
                    Header = () =>
                    [
                        new DomText { Text = new Signal<string>("head") },
                    ],
                    // Footer intentionally omitted
                },
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo(
            "<!--[--><header>head</header><div>body</div><footer></footer><!--]-->");
    }

    [Test]
    public async Task No_slots_provided_renders_empty_fallback()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new CardWithDefault
            {
                Props = new CardProps(),
                // Slots intentionally omitted
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo(
            "<!--[--><div></div><!--]-->");
    }

    [Test]
    public async Task Nested_components_with_slots()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new CardWithDefault
            {
                Props = new CardProps(),
                Slots = new SingleSlot
                {
                    Default = () =>
                    [
                        new CardWithDefault
                        {
                            Props = new CardProps(),
                            Slots = new SingleSlot
                            {
                                Default = () =>
                                [
                                    new DomText { Text = new Signal<string>("nested") },
                                ],
                            },
                        },
                    ],
                },
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo(
            "<!--[--><div><!--[--><div>nested</div><!--]--></div><!--]-->");
    }

    [Test]
    public async Task Slot_receives_readonly_signal_and_renders_text()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new CardWithDefaultSignal
            {
                Props = new NoProps(),
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

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo(
            "<!--[--><div>initial</div><!--]-->");
    }
}
