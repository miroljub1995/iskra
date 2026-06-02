using Iskra.Core.Components;
using Iskra.Core.DomComponents;
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
                    Class = "flex min-h-[calc(100vh-4rem)]".ToConstSignal(),
                },
                Children =
                [
                    new Sidebar
                    {
                        Props = new SidebarProps(),
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
                                        Pattern = "/setup",
                                        Render = () => [new SetupPage { Props = new SetupPageProps() }],
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
