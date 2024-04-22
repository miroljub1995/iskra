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

        EventListener? listener = null;
        listener = ev =>
        {
            if (ev.Target?.JSObject.InstanceOf(out HtmlInputElement? input) == true)
            {
                Console.WriteLine($"Got event from input with value '{input.Value}'");

                if (listener is not null && input.Value.EndsWith("5"))
                {
                    element.RemoveEventListener("input", listener);
                }
            }
        };

        element.AddEventListener("input", listener);

        Console.WriteLine("Hello, World!");
    }
}