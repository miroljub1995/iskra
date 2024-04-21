using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using Iskra.JSFunction;

namespace Iskra.MinimalWasmExample;

[SupportedOSPlatform("browser")]
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

        JSObject input = JSHost.GlobalThis
            .GetPropertyAsJSObject("document")
            .GetPropertyAsJSFunction("getElementById")
            .Call<JSObject>("test-input");

        JSHost.GlobalThis
            .GetPropertyAsJSObject("console")
            .GetPropertyAsJSFunction("log")
            .Call("found input", input);

        Action<object?> cb = (e) =>
            Console.WriteLine(
                $"Got event in c#: {((JSObject)e)
                    .GetPropertyAsJSObject("target")
                    .GetPropertyAsString("value")}");

        JSObject jsCb = cb.ToJSObject();

        input
            .GetPropertyAsJSFunction("addEventListener")
            .Call("input", jsCb);

        Console.WriteLine("Hello, World!");
    }
}