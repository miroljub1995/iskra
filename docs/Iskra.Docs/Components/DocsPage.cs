using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Core.Features.HydrationState;
using Iskra.Core.HotReload;
using Iskra.Docs.Client;
using Iskra.Docs.Client.Components;
using Iskra.Signals;

namespace Iskra.Docs.Components;

public class DocsPageProps
{
}

public class DocsPage : BaseComponent<DocsPageProps, NoEvents, NoSlots, NoExpose>
{
    protected override IComponent[] Setup(out NoExpose exposed)
    {
        exposed = default;

        return
        [
            new Html
            {
                Props = new HtmlProps { Lang = new Signal<string>("en") },
                Children =
                [
                    new Head
                    {
                        Props = new HeadProps(),
                        Children =
                        [
                            new Meta
                            {
                                Props = new MetaProps
                                {
                                    HttpEquiv = new Signal<string>("Content-Type"),
                                    Content = new Signal<string>("text/html; charset=utf-8"),
                                },
                            },
                            new Title
                            {
                                Props = new TitleProps(),
                                Children = [new DomText { Text = new Signal<string>("Iskra Docs (SSR)") }],
                            },
                            new MainScript(),
                            new HydrationStateScript(),
                            new Style
                            {
                                Props = new StyleProps(),
                                Children = [new DomText { Text = new Signal<string>(Styles.GetCss()) }],
                            },
                        ],
                    },
                    new Body
                    {
                        Props = new BodyProps(),
                        Children =
                        [
                            new Div
                            {
                                Props = new DivProps { Id = new Signal<string>("app") },
                                Children = [new DocsApp { Props = new DocsAppProps() }],
                            },
                            new BrowserRefreshScript(),
                        ],
                    },
                ],
            },
        ];
    }
}
