using System.Runtime.InteropServices.JavaScript;
using Iskra.Core.RenderRoot;
using Iskra.CoreExample.Components;
using Iskra.JSCore;
using Iskra.Signals;
using Iskra.StdWeb;
using Exception = System.Exception;

// new App()
//     .WithRootAnchor(new DomAnchor())
//     .WithRootComponent(x => new HelloWorld(x).Setup(new()))
//     .Start();

if (!OperatingSystem.IsBrowser())
{
    throw new PlatformNotSupportedException();
}

await StdWebProxyFactory.InitializeAsync();

var root = new DomRenderRoot(JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis).Document.GetElementById("app") ??
                             throw new Exception("App element not found."));

new ParentComponent
{
    Props = new ParentComponentProps(),
}.Mount(root.GetNextSlot());

await Task.Delay(Timeout.Infinite);