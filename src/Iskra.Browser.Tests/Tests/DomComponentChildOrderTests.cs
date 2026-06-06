using Iskra.Core.Components;
using Iskra.Dom.Components;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Browser.Tests;

/// <summary>
/// Verifies that when a non-void DOM component (e.g. &lt;div&gt;) has children
/// that expand into multiple slots (such as a <see cref="BaseComponent{TProps,TEvents,TSlots,TExpose}"/>
/// whose Setup returns several elements), subsequent sibling children are
/// rendered in the correct DOM order — both on initial mount and after
/// reactive re-renders.
/// </summary>
public class DomComponentChildOrderTests
{
    private sealed class MultiNodeProps;

    /// <summary>
    /// A component whose Setup returns two <c>&lt;span&gt;</c> elements,
    /// causing it to occupy multiple slots in the parent's render root.
    /// </summary>
    private sealed class MultiNodeComponent : BaseComponent<MultiNodeProps, NoEvents, NoSlots, NoExpose>
    {
        protected override IComponent[] Setup(out NoExpose exposed)
        {
            exposed = default;
            return
            [
                new Span { Children = [new DomText { Text = new Signal<string>("a") }] },
                new Span { Children = [new DomText { Text = new Signal<string>("b") }] },
            ];
        }
    }

    [Test]
    public async Task Children_after_multi_slot_component_appear_in_correct_order()
    {
        var container = DomHelpers.CreateContainer();

        using var host = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new Div
            {
                Children =
                [
                    new MultiNodeComponent { Props = new MultiNodeProps() },
                    new Span { Children = [new DomText { Text = new Signal<string>("c") }] },
                ],
            })
            .Build()
            .Mount();

        var div = container.QuerySelector("div")!;
        var spans = div.QuerySelectorAll("span");

        await Assert.That(spans.Length).IsEqualTo(3u);
        await Assert.That(spans.Item(0)!.TextContent).IsEqualTo("a");
        await Assert.That(spans.Item(1)!.TextContent).IsEqualTo("b");
        await Assert.That(spans.Item(2)!.TextContent).IsEqualTo("c");
    }

    [Test]
    public async Task Toggling_If_after_multi_slot_component_preserves_sibling_order()
    {
        var container = DomHelpers.CreateContainer();
        var condition = new Signal<bool>(true);

        using var host = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new Div
            {
                Children =
                [
                    new MultiNodeComponent { Props = new MultiNodeProps() },
                    new Span { Children = [new DomText { Text = new Signal<string>("sep") }] },
                    new If
                    {
                        Condition = condition,
                        Then = () =>
                        [
                            new Span { Children = [new DomText { Text = new Signal<string>("then") }] },
                        ],
                    },
                ],
            })
            .Build()
            .Mount();

        var div = container.QuerySelector("div")!;

        // Initial: a, b, sep, then
        var spans = div.QuerySelectorAll("span");
        await Assert.That(spans.Length).IsEqualTo(4u);
        await Assert.That(spans.Item(0)!.TextContent).IsEqualTo("a");
        await Assert.That(spans.Item(1)!.TextContent).IsEqualTo("b");
        await Assert.That(spans.Item(2)!.TextContent).IsEqualTo("sep");
        await Assert.That(spans.Item(3)!.TextContent).IsEqualTo("then");

        // Toggle off
        condition.Value = false;

        spans = div.QuerySelectorAll("span");
        await Assert.That(spans.Length).IsEqualTo(3u);
        await Assert.That(spans.Item(0)!.TextContent).IsEqualTo("a");
        await Assert.That(spans.Item(1)!.TextContent).IsEqualTo("b");
        await Assert.That(spans.Item(2)!.TextContent).IsEqualTo("sep");

        // Toggle back on — the "then" span must appear after "sep", not before "a"
        condition.Value = true;

        spans = div.QuerySelectorAll("span");
        await Assert.That(spans.Length).IsEqualTo(4u);
        await Assert.That(spans.Item(0)!.TextContent).IsEqualTo("a");
        await Assert.That(spans.Item(1)!.TextContent).IsEqualTo("b");
        await Assert.That(spans.Item(2)!.TextContent).IsEqualTo("sep");
        await Assert.That(spans.Item(3)!.TextContent).IsEqualTo("then");
    }
}
