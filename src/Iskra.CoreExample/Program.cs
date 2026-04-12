using System.Runtime.InteropServices.JavaScript;
using Iskra.Core;
using Iskra.Core.Instances;
using Iskra.Core.RenderRoot;
using Iskra.CoreExample;
using Iskra.CoreExample.Components;
using Iskra.JSCore;
using Iskra.Signals;
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
    SimpleComponent.SimpleComponentExpose, SimpleComponent.SimpleComponentFallthrough>(
    new SimpleComponent.SimpleComponentPropsInit
    {
        Name = () => "John",
        Surname = () => "Doe",
    },
    new SimpleComponent.SimpleComponentFallthrough());

new NewComponent(new()
    {
        Fullname = new Computed<string>(() => "Petar Petrov"),
    },
    new(),
    new Signal<NewComponent.Exposed?>(null)
).Mount(root.GetNextSlot());

await Task.Delay(Timeout.Infinite);