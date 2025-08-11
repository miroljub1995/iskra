using Iskra.Core;
using Iskra.CoreExample;
using Iskra.CoreExample.Components;

new App()
    .WithRootAnchor(new DomAnchor())
    .WithRootComponent(x => new HelloWorld(x).Setup(new()))
    .Start();