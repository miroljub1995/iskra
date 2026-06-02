using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Signals;

namespace Iskra.Docs.Client.Components;

public class QuickStartProps { }

public class QuickStart : BaseComponent<QuickStartProps, NoEvents, NoSlots, NoExpose>
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
                    Id = "quick-start".ToConstSignal(),
                    Class = "group text-4xl font-bold text-gray-900 dark:text-white mb-6".ToConstSignal(),
                },
                Children =
                [
                    new A
                    {
                        Props = new AProps
                        {
                            Href = "#quick-start".ToConstSignal(),
                            Class = "opacity-0 group-hover:opacity-100 text-indigo-400 dark:text-indigo-500 no-underline transition-opacity mr-2".ToConstSignal(),
                        },
                        Children = [new DomText { Text = "#".ToConstSignal() }],
                    },
                    new DomText { Text = "Quick Start".ToConstSignal() },
                ],
            },
            new SectionTitle
            {
                Props = new SectionTitleProps
                {
                    Text = "Creating a Iskra Application".ToConstSignal(),
                    Id = "creating-a-iskra-application".ToConstSignal(),
                },
                Slots = new SectionTitleSlots
                {
                    Default = () =>
                    [
                        new P
                        {
                            Props = new PProps
                            {
                                Class = "mb-4 text-gray-600 dark:text-white".ToConstSignal(),
                            },
                            Children = [new DomText { Text = "In this section we will introduce you to scaffold an Iskra application on your local machine.".ToConstSignal() }],
                        },
                        new Prerequisites
                        {
                            Props = new NoProps(),
                            Slots = new PrerequisitesSlots
                            {
                                Default = () =>
                                [
                                    new Li
                                    {
                                        Props = new LiProps(),
                                        Children =
                                        [
                                            new DomText { Text = "Install ".ToConstSignal() },
                                            new A
                                            {
                                                Props = new AProps
                                                {
                                                    Href = "https://dotnet.microsoft.com/download".ToConstSignal(),
                                                    Class = "text-indigo-600 dark:text-indigo-400 hover:underline".ToConstSignal(),
                                                },
                                                Children = [new DomText { Text = ".NET".ToConstSignal() }],
                                            },
                                            new DomText { Text = " version ".ToConstSignal() },
                                            new Code
                                            {
                                                Props = new CodeProps
                                                {
                                                    Class = "bg-gray-100 dark:bg-gray-800 px-1.5 py-0.5 rounded text-sm".ToConstSignal(),
                                                },
                                                Children = [new DomText { Text = "9.0".ToConstSignal() }],
                                            },
                                            new DomText { Text = " or ".ToConstSignal() },
                                            new Code
                                            {
                                                Props = new CodeProps
                                                {
                                                    Class = "bg-gray-100 dark:bg-gray-800 px-1.5 py-0.5 rounded text-sm".ToConstSignal(),
                                                },
                                                Children = [new DomText { Text = "10.0".ToConstSignal() }],
                                            },
                                        ],
                                    },
                                ],
                            },
                        },
                    ],
                },
            },
        ];
    }
}
