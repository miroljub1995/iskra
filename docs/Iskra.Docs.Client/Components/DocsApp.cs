using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Core.Features;
using Iskra.Core.Features.Routing;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Docs.Client.Components;

public class DocsAppProps { }

public class DocsApp : BaseComponent<DocsAppProps, NoEvents, NoSlots, NoExpose>
{
    protected override IComponent[] Setup(out NoExpose exposed)
    {
        exposed = default;

        var navigation = AppFeatures.Features.Get<INavigationFeature>()
            ?? throw new InvalidOperationException("INavigationFeature is not registered.");

        return
        [
            new Main
            {
                Props = new MainProps { Class = new Signal<string>("max-w-4xl mx-auto p-6") },
                Children =
                [
                    new Header
                    {
                        Props = new HeaderProps(),
                    },
                    new Nav
                    {
                        Props = new NavProps(),
                        Children =
                        [
                            new A
                            {
                                Props = new AProps { Href = new Signal<string>("/") },
                                Events = new AEvents
                                {
                                    OnClick = (e) =>
                                    {
                                        if (!OperatingSystem.IsBrowser()) return;
                                        e.PreventDefault();
                                        navigation.PushAsync("/");
                                    },
                                },
                                Children = [new DomText { Text = new Signal<string>("Home") }],
                            },
                            new A
                            {
                                Props = new AProps { Href = new Signal<string>("/about") },
                                Events = new AEvents
                                {
                                    OnClick = (e) =>
                                    {
                                        if (!OperatingSystem.IsBrowser()) return;
                                        e.PreventDefault();
                                        navigation.PushAsync("/about");
                                    },
                                },
                                Children = [new DomText { Text = new Signal<string>("About") }],
                            },
                        ],
                    },
                    new Routes
                    {
                        Items =
                        [
                            new Route
                            {
                                Pattern = "/",
                                Render = () => [new HomePage { Props = new HomePageProps() }],
                            },
                            new Route
                            {
                                Pattern = "/about",
                                Render = () => [new AboutPage { Props = new AboutPageProps() }],
                            },
                        ],
                    },
                ],
            },
        ];
    }
}
