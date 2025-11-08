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

        // new Window(JSHost.GlobalThis)
        //     .SetInterval(() =>
        //     {
        //         // if (counter.Value < 3)
        //         {
        //             Console.WriteLine("Incrementing counter...");
        //             counter.Value++;
        //         }
        //     }, 1_000);

        return () => new RenderNodeElement<HtmlDivElement, HtmlDivElementProps>(
            Key: null,
            Props: new(
                Class: $"class-1 class-2 class-{counter.Value}",
                ChildNodes: [new RenderNodeText($"Counter value: {counter.Value}")]
            )
        );
    }
}