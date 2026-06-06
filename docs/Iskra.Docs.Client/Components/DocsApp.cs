using Iskra.Core.Components;
using Iskra.Dom.Components;
using Iskra.Core.Features.Routing;
using Iskra.Signals;

namespace Iskra.Docs.Client.Components;

public class DocsAppProps { }

public class DocsApp : BaseComponent<DocsAppProps, NoEvents, NoSlots, NoExpose>
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
            new Div
            {
                Props = new DivProps
                {
                    Class = "flex min-h-[calc(100vh-4rem)] bg-white dark:bg-gray-950".ToConstSignal(),
                },
                Children =
                [
                    new Sidebar
                    {
                        Props = new NoProps(),
                    },
                    // Main content
                    new Main
                    {
                        Props = new MainProps
                        {
                            Class = "flex-1 px-4 sm:px-8 py-8 max-w-4xl".ToConstSignal(),
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
                                        Pattern = "/quick-start",
                                        Render = () => [new QuickStart { Props = new QuickStartProps() }],
                                    },
                                ],
                            },
                        ],
                    },
                ],
            },
        ];
    }
}
