using Iskra.Core.DomComponents;
using Iskra.JSCore;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.Client.Tests;

public class DomTextTests
{
    [Test]
    public async Task Renders_text_into_dom()
    {
        var window = JSObjectProxyFactory.GetProxy<Window>(
            System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis);

        var container = window.Document.CreateElement("div");

        using var cts = new CancellationTokenSource();
        var text = new Signal<string>("hello");
        var runTask = new IskraHostBuilder()
            .UseRootElement(container)
            .UseRootComponent(() => new DomText { Text = text })
            .Build()
            .RunAsync(cts.Token);
        try
        {
            await Task.Delay(20);
            await Assert.That(container.TextContent).IsEqualTo("hello");
        }
        finally
        {
            await cts.CancelAsync();
            try { await runTask; } catch (OperationCanceledException) { }
        }
    }

    [Test]
    public async Task Updates_text_when_signal_changes()
    {
        var window = JSObjectProxyFactory.GetProxy<Window>(
            System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis);

        var container = window.Document.CreateElement("div");

        using var cts = new CancellationTokenSource();
        var text = new Signal<string>("hello");
        var runTask = new IskraHostBuilder()
            .UseRootElement(container)
            .UseRootComponent(() => new DomText { Text = text })
            .Build()
            .RunAsync(cts.Token);
        try
        {
            await Task.Delay(20);
            text.Value = "world";

            await Assert.That(container.TextContent).IsEqualTo("world");
        }
        finally
        {
            await cts.CancelAsync();
            try { await runTask; } catch (OperationCanceledException) { }
        }
    }
}
