using System.Text.Json.Nodes;
using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Core.Features.HydrationState;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.Client.Tests;

public class HydrationTests
{
    /// <summary>
    /// Simple wrapper component that returns a single child element.
    /// When mounted, BaseComponent emits <!--[-->...<!--]--> comment markers.
    /// </summary>
    private class WrapperProps;

    private class Wrapper : BaseComponent<WrapperProps, BaseEmits, object>
    {
        public required Func<IComponent[]> Body { get; init; }

        protected override IComponent[] Setup(WrapperProps props, BaseEmits? events, out object exposed)
        {
            exposed = new object();
            return Body();
        }
    }

    private sealed class TestHydrationState : IClientHydrationStateFeature
    {
        public JsonObject Value { get; } = new() { ["hydrate"] = true };
    }

    private static Element CreateContainerWithHtml(string html)
    {
        var container = DomHelpers.CreateContainer();
        container.InnerHTML = html;
        return container;
    }

    private static IskraHostBuilder CreateHydrationBuilder(Element container)
    {
        return new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .SetFeature<IClientHydrationStateFeature>(new TestHydrationState());
    }

    [Test]
    public async Task Hydrates_single_element()
    {
        var container = CreateContainerWithHtml("<p>hello</p>");

        using var _ = CreateHydrationBuilder(container)
            .UseRootComponent(() => new P
            {
                Props = new PProps(),
                Children = [new DomText { Text = new Signal<string>("hello") }],
            })
            .Build()
            .Mount();

        await Assert.That(container.TextContent).IsEqualTo("hello");
        await Assert.That(container.ChildNodes.Length).IsEqualTo(1u);
    }

    [Test]
    public async Task Hydrates_BaseComponent_with_comment_markers()
    {
        // SSR output for a BaseComponent: <!--[--><span>content</span><!--]-->
        var container = CreateContainerWithHtml("<!--[--><span>content</span><!--]-->");

        using var _ = CreateHydrationBuilder(container)
            .UseRootComponent(() => new Wrapper
            {
                Props = new WrapperProps(),
                Body = () =>
                [
                    new Span
                    {
                        Props = new SpanProps(),
                        Children = [new DomText { Text = new Signal<string>("content") }],
                    },
                ],
            })
            .Build()
            .Mount();

        // Should reuse existing DOM nodes without inserting extras
        await Assert.That(container.ChildNodes.Length).IsEqualTo(3u); // <!--[--> <span> <!--]-->
        await Assert.That(container.ChildElementCount).IsEqualTo(1u);
    }

    [Test]
    public async Task Hydrates_BaseComponent_sibling_after_BaseComponent()
    {
        // This is the exact pattern that caused the hydration bug:
        // A parent element contains a child BaseComponent followed by a sibling DOM element.
        // SSR output: <div><!--[--><h1>title</h1><!--]--><p>body</p></div>
        var container = CreateContainerWithHtml("<div><!--[--><h1>title</h1><!--]--><p>body</p></div>");

        using var _ = CreateHydrationBuilder(container)
            .UseRootComponent(() => new Div
            {
                Props = new DivProps(),
                Children =
                [
                    new Wrapper
                    {
                        Props = new WrapperProps(),
                        Body = () =>
                        [
                            new H1
                            {
                                Props = new H1Props(),
                                Children = [new DomText { Text = new Signal<string>("title") }],
                            },
                        ],
                    },
                    new P
                    {
                        Props = new PProps(),
                        Children = [new DomText { Text = new Signal<string>("body") }],
                    },
                ],
            })
            .Build()
            .Mount();

        // The <div> should still have exactly 4 child nodes: <!--[-->, <h1>, <!--]-->, <p>
        var div = container.ChildNodes.Item(0)!;
        await Assert.That(div.ChildNodes.Length).IsEqualTo(4u);
        // <h1> should appear before <p>
        await Assert.That(div.ChildNodes.Item(1)!.NodeName).IsEqualTo("H1", StringComparison.OrdinalIgnoreCase);
        await Assert.That(div.ChildNodes.Item(3)!.NodeName).IsEqualTo("P", StringComparison.OrdinalIgnoreCase);
    }

    [Test]
    public async Task Hydrates_multiple_BaseComponents_in_sequence()
    {
        // Two BaseComponents as siblings inside a parent element.
        // SSR: <div><!--[--><h1>first</h1><!--]--><!--[--><p>second</p><!--]--></div>
        var container = CreateContainerWithHtml(
            "<div><!--[--><h1>first</h1><!--]--><!--[--><p>second</p><!--]--></div>");

        using var _ = CreateHydrationBuilder(container)
            .UseRootComponent(() => new Div
            {
                Props = new DivProps(),
                Children =
                [
                    new Wrapper
                    {
                        Props = new WrapperProps(),
                        Body = () =>
                        [
                            new H1
                            {
                                Props = new H1Props(),
                                Children = [new DomText { Text = new Signal<string>("first") }],
                            },
                        ],
                    },
                    new Wrapper
                    {
                        Props = new WrapperProps(),
                        Body = () =>
                        [
                            new P
                            {
                                Props = new PProps(),
                                Children = [new DomText { Text = new Signal<string>("second") }],
                            },
                        ],
                    },
                ],
            })
            .Build()
            .Mount();

        var div = container.ChildNodes.Item(0)!;
        // 6 child nodes: <!--[-->, <h1>, <!--]-->, <!--[-->, <p>, <!--]-->
        await Assert.That(div.ChildNodes.Length).IsEqualTo(6u);
        await Assert.That(div.ChildNodes.Item(1)!.NodeName).IsEqualTo("H1", StringComparison.OrdinalIgnoreCase);
        await Assert.That(div.ChildNodes.Item(4)!.NodeName).IsEqualTo("P", StringComparison.OrdinalIgnoreCase);
    }

    [Test]
    public async Task Hydrates_BaseComponent_between_dom_elements()
    {
        // DOM element, then BaseComponent, then DOM element.
        // SSR: <div><span>before</span><!--[--><h1>middle</h1><!--]--><span>after</span></div>
        var container = CreateContainerWithHtml(
            "<div><span>before</span><!--[--><h1>middle</h1><!--]--><span>after</span></div>");

        using var _ = CreateHydrationBuilder(container)
            .UseRootComponent(() => new Div
            {
                Props = new DivProps(),
                Children =
                [
                    new Span
                    {
                        Props = new SpanProps(),
                        Children = [new DomText { Text = new Signal<string>("before") }],
                    },
                    new Wrapper
                    {
                        Props = new WrapperProps(),
                        Body = () =>
                        [
                            new H1
                            {
                                Props = new H1Props(),
                                Children = [new DomText { Text = new Signal<string>("middle") }],
                            },
                        ],
                    },
                    new Span
                    {
                        Props = new SpanProps(),
                        Children = [new DomText { Text = new Signal<string>("after") }],
                    },
                ],
            })
            .Build()
            .Mount();

        var div = container.ChildNodes.Item(0)!;
        // 5 nodes: <span>, <!--[-->, <h1>, <!--]-->, <span>
        await Assert.That(div.ChildNodes.Length).IsEqualTo(5u);
        await Assert.That(div.ChildNodes.Item(0)!.TextContent).IsEqualTo("before");
        await Assert.That(div.ChildNodes.Item(2)!.NodeName).IsEqualTo("H1", StringComparison.OrdinalIgnoreCase);
        await Assert.That(div.ChildNodes.Item(4)!.TextContent).IsEqualTo("after");
    }

    [Test]
    public async Task Throws_on_hydration_mismatch_wrong_element()
    {
        // SSR has <span> but component expects <p>
        var container = CreateContainerWithHtml("<span>text</span>");

        var act = () =>
        {
            using var _ = CreateHydrationBuilder(container)
                .UseRootComponent(() => new P
                {
                    Props = new PProps(),
                    Children = [new DomText { Text = new Signal<string>("text") }],
                })
                .Build()
                .Mount();
        };

        await Assert.That(act).Throws<HydrationMismatchException>();
    }

    [Test]
    public async Task Throws_on_hydration_mismatch_wrong_text()
    {
        // SSR has "hello" but component expects "world"
        var container = CreateContainerWithHtml("<p>hello</p>");

        var act = () =>
        {
            using var _ = CreateHydrationBuilder(container)
                .UseRootComponent(() => new P
                {
                    Props = new PProps(),
                    Children = [new DomText { Text = new Signal<string>("world") }],
                })
                .Build()
                .Mount();
        };

        await Assert.That(act).Throws<HydrationMismatchException>();
    }
}
