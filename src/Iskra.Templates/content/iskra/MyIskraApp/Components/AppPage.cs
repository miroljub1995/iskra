using Iskra.Core.Components;
using Iskra.Dom.Components;
using Iskra.Ssr.Features.HydrationState;
using Iskra.Ssr.HotReload;
using Iskra.Ssr.Components;
using MyIskraApp.Client;
using MyIskraApp.Client.Components;
using Iskra.Signals;

namespace MyIskraApp.Components;

public class AppPageProps
{
}

public class AppPage : BaseComponent<AppPageProps, NoEvents, NoSlots, NoExpose>
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
                                Children = [new DomText { Text = "MyIskraApp".ToConstSignal() }],
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
                        Props = new BodyProps
                        {
                            Class = "bg-white dark:bg-gray-950 text-gray-900 dark:text-gray-100".ToConstSignal(),
                        },
                        Children =
                        [
                            new Div
                            {
                                Props = new DivProps { Id = "app".ToConstSignal() },
                                Children = [new App { Props = new AppProps() }],
                            },
                            new BrowserRefreshScript(),
                        ],
                    },
                ],
            },
        ];
    }

}
