using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.Server.Tests.Tests;

public class DivTests
{
    [Test]
    public async Task Renders_empty_div()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Div())
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<div></div>");
    }

    [Test]
    public async Task Renders_div_with_attributes()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Div
            {
                Props = new DivProps
                {
                    Id = new Signal<string>("main"),
                    Class = new Signal<string>("container"),
                },
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<div class=\"container\" id=\"main\"></div>");
    }

    [Test]
    public async Task Renders_div_with_children()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Div
            {
                Children =
                [
                    new DomText { Text = new Signal<string>("hello ") },
                    new DomText { Text = new Signal<string>("world") },
                ],
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<div>hello world</div>");
    }

    [Test]
    public async Task Renders_div_with_attributes_and_children()
    {
        var root = new SsrRenderRoot();

        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Div
            {
                Props = new DivProps
                {
                    Id = new Signal<string>("outer"),
                    Class = new Signal<string>("box"),
                },
                Children =
                [
                    new Div
                    {
                        Props = new DivProps { Class = new Signal<string>("inner") },
                        Children = [new DomText { Text = new Signal<string>("nested") }],
                    },
                ],
            })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo(
            "<div class=\"box\" id=\"outer\"><div class=\"inner\">nested</div></div>");
    }

    [Test]
    public async Task Reflects_signal_updates_in_attributes_and_text()
    {
        var root = new SsrRenderRoot();

        var id = new Signal<string>("a");
        var text = new Signal<string>("first");
        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new Div
            {
                Props = new DivProps { Id = id },
                Children = [new DomText { Text = text }],
            })
            .Build()
            .Mount();

        id.Value = "b";
        text.Value = "second";

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("<div id=\"b\">second</div>");
    }
}
