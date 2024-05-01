using System.Runtime.InteropServices.JavaScript;
using Iskra.App;
using Iskra.App.Elements;
using Iskra.Reactivity;
using Iskra.StdWeb.Dom;

namespace Iskra.AppExample;

public record AppProps();

public class App : IIskraComponent<AppProps>
{
    public RenderCallback Setup(AppProps props)
    {
        Ref<int> counter = 0.ToRef();

        new Window(JSHost.GlobalThis)
            .SetInterval(() =>
            {
                Console.WriteLine("Incrementing counter...");
                counter.Value++;
            }, 1_000);

        // System.Timers.Timer timer = new()
        // {
        //     Interval = 1000,
        //     AutoReset = true,
        // };
        // timer.Elapsed += (_, _) =>
        // {
        //     Console.WriteLine("Incrementing counter...");
        //     counter.Value++;
        // };
        // timer.Enabled = true;

        return () => new RenderNodeElement<HtmlDivElement, HtmlDivElementProps>(
            Key: null,
            Props: new(
                Class: "class-1 class-2",
                ChildNodes: [new RenderNodeText($"Counter value: {counter.Value}")]
            )
        );
    }
}