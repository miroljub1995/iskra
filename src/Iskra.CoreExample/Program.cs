using System.Runtime.InteropServices.JavaScript;
using Iskra.Core;
using Iskra.Core.Instances;
using Iskra.Core.RenderRoot;
using Iskra.CoreExample;
using Iskra.CoreExample.Components;
using Iskra.JSCore;
using Iskra.StdWeb;
using Exception = System.Exception;

// new App()
//     .WithRootAnchor(new DomAnchor())
//     .WithRootComponent(x => new HelloWorld(x).Setup(new()))
//     .Start();

await StdWebProxyFactory.InitializeAsync();

var root = new DomRenderRoot(JSObjectProxyFactory.GetProxy<Window>(JSHost.GlobalThis).Document.GetElementById("app") ??
                             throw new Exception("App element not found."));

var rootComponentInstance = new ComponentInstance<SimpleComponent, SimpleComponent.SimpleComponentPropsInit,
    SimpleComponent.SimpleComponentExpose>(new SimpleComponent.SimpleComponentPropsInit
{
    Name = () => "John",
    Surname = () => "Doe",
});

rootComponentInstance.Mount(root.GetNextSlot());

await Task.Delay(Timeout.Infinite);