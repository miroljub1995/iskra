using Iskra.App;
using Iskra.App.Elements;
using Iskra.AppExample;
using Iskra.StdWeb.Dom;

new IskraApp()
    .WithRootContainer("root")
    // .WithRootComponent<App, AppProps>(new())
    // .WithRootRenderNode(new RenderNodeText("some text to render"))
    .WithRootRenderNode(new RenderNodeElement<HtmlDivElement, HtmlDivElementProps>(
        Key: null,
        Props: new(
            Class: "class-1 class-2",
            ChildNodes: [new RenderNodeText("some text to render")]
        )
    ))
    .Start();