using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWeb;
using Iskra.StdWeb.Utils;

namespace Iskra.MinimalWasmExample;

public static class Program
{
    static async Task Main(string[] args)
    {
        var w = WrapperFactory.GetWrapper<Window>(JSHost.GlobalThis);
        w.Console.Log("this is from console", w, w.Document);

        w.Document.AddEventListener("test", SomeListener, false);
        w.Document.DispatchEvent(new Event("test"));
        w.Document.DispatchEvent(new Event("test"));
        w.Document.DispatchEvent(new Event("test"));

        System.Console.WriteLine("Removing event listener...");
        w.Document.RemoveEventListener("test", SomeListener, false);
        w.Document.DispatchEvent(new Event("test"));
        w.Document.DispatchEvent(new Event("test"));
        w.Document.DispatchEvent(new Event("test"));

        var newDiv = w.Document.CreateElement("div");
        w.Document.Body.AppendChild(newDiv);
        w.Console.Log("Appended child", newDiv);
        newDiv.InnerHTML = "<p>Hello World!</p>";
        newDiv.InnerHTML += "<p>Adding new p</p>";

        await Task.Delay(Timeout.Infinite);
    }

    static void SomeListener(Event e)
    {
        var w = WrapperFactory.GetWrapper<Window>(JSHost.GlobalThis);
        w.Console.Log("this is from listener", e);
    }
}