using Iskra.Core.DomComponents;
using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.Client.Tests;

public class DomTextTests
{
    [Test]
    public async Task Renders_text_into_dom()
    {
        var container = DomHelpers.CreateContainer();

        var text = new Signal<string>("hello");
        using var _ = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new DomText { Text = text })
            .Build()
            .Mount();

        await Assert.That(container.TextContent).IsEqualTo("hello");
    }

    [Test]
    public async Task Updates_text_when_signal_changes()
    {
        var container = DomHelpers.CreateContainer();

        var text = new Signal<string>("hello");
        using var _ = new IskraHostBuilder()
            .UseRootRenderer(new DomRenderRoot(container))
            .UseRootComponent(() => new DomText { Text = text })
            .Build()
            .Mount();

        text.Value = "world";

        await Assert.That(container.TextContent).IsEqualTo("world");
    }
}
