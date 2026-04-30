using Iskra.Core.DomComponents;
using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.Server.Tests.Tests;

public class DomTextTests
{
    [Test]
    public async Task Renders_text_into_ssr_output()
    {
        var root = new SsrRenderRoot();

        var text = new Signal<string>("hello");
        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new DomText { Text = text })
            .Build()
            .Mount();

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("hello");
    }

    [Test]
    public async Task Updates_text_when_signal_changes()
    {
        var root = new SsrRenderRoot();

        var text = new Signal<string>("hello");
        using var _ = new IskraHostBuilder()
            .UseRootRenderer(root)
            .UseRootComponent(() => new DomText { Text = text })
            .Build()
            .Mount();

        text.Value = "world";

        var output = await SsrHelpers.RenderAsync(root);

        await Assert.That(output).IsEqualTo("world");
    }
}
