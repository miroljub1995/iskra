using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWeb.Dom;

namespace Iskra.MinimalWasmExample;

public static class Program
{
    static async Task Main(string[] args)
    {
        HtmlInputElement element = new Window(JSHost.GlobalThis)
                                       .Document
                                       .GetElementById<HtmlInputElement>("test-input")
                                   ?? throw new("Element not found.");

        Console.WriteLine($"Element value {element.Value}");

        EventSubscription? subscription = null;
        subscription = element.AddEventListener("input", ev =>
        {
            if (ev.Target?.JSObject.InstanceOf(out HtmlInputElement? input) == true)
            {
                Console.WriteLine($"Got event from input with value '{input.Value}'");

                if (input.Value.EndsWith("5"))
                {
                    subscription?.Dispose();
                }
            }
        });

        Console.WriteLine("Hello, World!");
    }
}