using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWeb;

namespace Iskra.MinimalWasmExample;

public static class Program
{
    static async Task Main(string[] args)
    {
        var w = WrapperFactory.GetWrapper<Window>(JSHost.GlobalThis);
        w.Console.Log("this is from console", w, w.Document);

        var opt = new ElementGetHTMLOptions()
        {
            ShadowRoots = []
        };
        w.Console.Log("ElementGetHTMLOptions opt", opt);

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
        w.Document.Body?.AppendChild(newDiv);
        w.Console.Log("Appended child", newDiv);
        newDiv.InnerHTML = "<p>Hello World!</p>";
        newDiv.InnerHTML += "<p>Adding new p</p>";

        var inputContent = w.Document.CreateElement("div");
        w.Document.Body?.AppendChild(inputContent);

        var newInput = (HTMLTextAreaElement)w.Document.CreateElement("textarea");
        w.Document.Body?.AppendChild(newInput);
        newInput.AddEventListener("input", OnClick, false);

        var button = w.Document.CreateElement("button");
        button.TextContent = "Enter fullscreen mode";
        w.Document.Body?.AppendChild(button);
        button.AddEventListener("click", async (e) =>
        {
            w.Console.Log("before full screen", e);
            await newInput.RequestFullscreen(null);
            w.Console.Log("after full screen");
        }, false);

        await Task.Delay(Timeout.Infinite);
        return;

        void OnClick(Event e)
        {
            if (e.Target is HTMLTextAreaElement target)
            {
                inputContent.TextContent = target.Value;
            }
            var someNewDiv = w.Document.CreateElement("div");
            someNewDiv.TextContent = "this is some div";
            w.Document.Body?.Append(someNewDiv);
        }
    }

    static void SomeListener(Event e)
    {
        var w = WrapperFactory.GetWrapper<Window>(JSHost.GlobalThis);
        w.Console.Log("this is from listener", e);
    }
}