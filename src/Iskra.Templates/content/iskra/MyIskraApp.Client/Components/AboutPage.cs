using Iskra.Core.Components;
using Iskra.Dom.Components;
using Iskra.Signals;

namespace MyIskraApp.Client.Components;

public class AboutPageProps { }

public class AboutPage : BaseComponent<AboutPageProps, NoEvents, NoSlots, NoExpose>
{
    protected override IComponent[] Setup(out NoExpose exposed)
    {
        exposed = default;

        return
        [
            new Section
            {
                Props = new SectionProps
                {
                    Class = "max-w-3xl mx-auto px-4 sm:px-8 py-12".ToConstSignal(),
                },
                Children =
                [
                    new H1
                    {
                        Props = new H1Props
                        {
                            Class = "text-4xl sm:text-5xl font-bold tracking-tight text-gray-900 dark:text-white".ToConstSignal(),
                        },
                        Children = [new DomText { Text = "About".ToConstSignal() }],
                    },
                    new P
                    {
                        Props = new PProps
                        {
                            Class = "mt-6 text-lg text-gray-600 dark:text-gray-300".ToConstSignal(),
                        },
                        Children = [new DomText { Text = "Iskra is a .NET-first toolkit for building reactive browser apps with typed Web APIs.".ToConstSignal() }],
                    },
                    new P
                    {
                        Props = new PProps
                        {
                            Class = "mt-4 text-gray-700 dark:text-gray-200".ToConstSignal(),
                        },
                        Children = [new DomText { Text = "This starter keeps things minimal so you can quickly begin building your own pages and components.".ToConstSignal() }],
                    },
                ],
            },
        ];
    }
}
