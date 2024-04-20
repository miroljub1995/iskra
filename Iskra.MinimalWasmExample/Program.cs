using System.Runtime.InteropServices.JavaScript;
using Iskra.JSFunction;

string res = await new HttpClient().GetStringAsync("https://api.mydesigns.io/healthz");
Console.WriteLine($"res: {res}");

string fetchType = JSHost.GlobalThis.GetTypeOfProperty("fetch");
Console.WriteLine($"Fetch type: {fetchType}");

// System.Runtime.InteropServices.JavaScript.JSFunctionBinding.InvokeJS

JSHost.GlobalThis.GetPropertyAsJSObject("console").GetPropertyAsJSObject("log").AsJSFunction()
    .Call("this is test and should work", JSHost.GlobalThis);

Console.WriteLine("Hello, World!");