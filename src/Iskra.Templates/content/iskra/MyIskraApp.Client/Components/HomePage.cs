using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Signals;

namespace MyIskraApp.Client.Components;

public class HomePageProps { }

public class HomePage : BaseComponent<HomePageProps, NoEvents, NoSlots, NoExpose>
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
                        Children = [new DomText { Text = "Build with Iskra".ToConstSignal() }],
                    },
                    new P
                    {
                        Props = new PProps
                        {
                            Class = "mt-6 text-lg text-gray-600 dark:text-gray-300".ToConstSignal(),
                        },
                        Children =
                        [
                            new DomText
                            {
                                Text = "This project was generated with the iskra template and includes server-side rendering, hydration, routing, and Tailwind CSS.".ToConstSignal(),
                            },
                        ],
                    },
                    new Div
                    {
                        Props = new DivProps
                        {
                            Class = "mt-8 rounded-xl border border-gray-200 dark:border-gray-800 bg-white/70 dark:bg-gray-900/60 p-5".ToConstSignal(),
                        },
                        Children =
                        [
                            new P
                            {
                                Props = new PProps
                                {
                                    Class = "text-sm text-gray-700 dark:text-gray-200".ToConstSignal(),
                                },
                                Children = [new DomText { Text = "Try navigating to About to verify client-side route transitions.".ToConstSignal() }],
                            },
                        ],
                    },
                ],
            },
        ];
    }
}
