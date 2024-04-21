using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWeb.Dom;

namespace Iskra.MinimalWasmExample;

public static class Program
{
    static async Task Main(string[] args)
    {
        // string res = await new HttpClient().GetStringAsync("https://api.mydesigns.io/healthz");
        // Console.WriteLine($"res: {res}");
        //
        // string fetchType = JSHost.GlobalThis.GetTypeOfProperty("fetch");
        // Console.WriteLine($"Fetch type: {fetchType}");

// System.Runtime.InteropServices.JavaScript.JSFunctionBinding.InvokeJS

        // JSHost.GlobalThis.GetPropertyAsJSObject("console").GetPropertyAsJSObject("log").AsJSFunction()
        //     .Call("this is test and should work", () => { return 1; });

        // JSHost.GlobalThis.GetPropertyAsJSObject("console").GetPropertyAsJSFunction("log").Call("some testtttt");


        Console.WriteLine("Is good contructor ");


        HtmlInputElement element = new Window(JSHost.GlobalThis)
                                       .Document
                                       .GetElementById<HtmlInputElement>("test-input")
                                   ?? throw new("Element not found.");

        Console.WriteLine($"Element value {element.Value}");

        element.AddEventListener("input", (ev) =>
        {
            if (ev.Target?.JSObject.InstanceOf(out HtmlInputElement? input) == true)
            {
                Console.WriteLine($"Got event from input with value '{input.Value}'");
            }
        });

        // JSHost.GlobalThis
        //     .GetPropertyAsJSObject("console")
        //     .GetPropertyAsJSFunction("log")
        //     .Call("found input", input);
        //
        // Action<object?> cb = (e) =>
        //     Console.WriteLine(
        //         $"Got event in c#: {((JSObject)e)
        //             .GetPropertyAsJSObject("target")
        //             .GetPropertyAsString("value")}");
        //
        // JSObject jsCb = cb.ToJSObject();
        //
        // input
        //     .GetPropertyAsJSFunction("addEventListener")
        //     .Call("input", jsCb);

        Console.WriteLine("Hello, World!");
    }
}