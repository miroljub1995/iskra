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
                Props = new HtmlProps { Lang = "en".ToConstSignal() },
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
                                    HttpEquiv = "Content-Type".ToConstSignal(),
                                    Content = "text/html; charset=utf-8".ToConstSignal(),
                                },
                            },
                            new Title
                            {
                                Props = new TitleProps(),
                                Children = [new DomText { Text = "Iskra Docs (SSR)".ToConstSignal() }],
                            },
                            new MainScript(),
                            new HydrationStateScript(),
                            new Style
                            {
                                Props = new StyleProps(),
                                Children = [new DomText { Text = Styles.GetCss().ToConstSignal() }],
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
                                Props = new DivProps { Id = "app".ToConstSignal() },
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
