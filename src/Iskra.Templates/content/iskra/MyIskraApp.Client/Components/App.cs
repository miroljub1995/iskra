using Iskra.Core.Components;
using Iskra.Dom.Components;
using Iskra.Core.Features.Routing;
using Iskra.Signals;

namespace MyIskraApp.Client.Components;

public class AppProps { }

public class App : BaseComponent<AppProps, NoEvents, NoSlots, NoExpose>
{
    protected override IComponent[] Setup(out NoExpose exposed)
    {
        exposed = default;

        return
        [
            new AppHeader
            {
                Props = new AppHeaderProps(),
            },
            new Main
            {
                Props = new MainProps
                {
                    Class = "min-h-[calc(100vh-4rem)] bg-white dark:bg-gray-950".ToConstSignal(),
                },
                Children =
                [
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
