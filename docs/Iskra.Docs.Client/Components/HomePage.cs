using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Signals;

namespace Iskra.Docs.Client.Components;

public class HomePageProps { }

public class HomePage : BaseComponent<HomePageProps, NoEvents, NoSlots, NoExpose>
{
    protected override IComponent[] Setup(out NoExpose exposed)
    {
        exposed = default;

        return
        [
            new H1
            {
                Props = new H1Props
                {
                    Id = "home".ToConstSignal(),
                    Class = "group text-4xl font-bold text-gray-900 dark:text-white mb-6".ToConstSignal(),
                },
                Children =
                [
                    new A
                    {
                        Props = new AProps
                        {
                            Href = "#home".ToConstSignal(),
                            Class = "opacity-0 group-hover:opacity-100 text-indigo-400 dark:text-indigo-500 no-underline transition-opacity mr-2".ToConstSignal(),
                        },
                        Children = [new DomText { Text = "#".ToConstSignal() }],
                    },
                    new DomText { Text = "Home".ToConstSignal() },
                ],
            },
            new SectionTitle
            {
                Props = new SectionTitleProps
                {
                    Text = "Home".ToConstSignal(),
                    Id = "home".ToConstSignal(),
                },
                Slots = new SectionTitleSlots
                {
                    Default = () =>
                    [
                        new P
                        {
                            Props = new PProps
                            {
                                Class = "text-gray-600 dark:text-white".ToConstSignal(),
                            },
                            Children = [new DomText { Text = "Welcome to Iskra — a reactive UI framework for .NET.".ToConstSignal() }],
                        },
                    ],
                },
            },
        ];
    }
}
