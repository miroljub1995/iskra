using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Signals;

namespace Iskra.Docs.Client.Components;

public class PrerequisitesSlots
{
    public required Func<IComponent[]> Default { get; init; }
}

public class Prerequisites : BaseComponent<NoProps, NoEvents, PrerequisitesSlots, NoExpose>
{
    protected override IComponent[] Setup(out NoExpose exposed)
    {
        exposed = default;

        return
        [
            new Div
            {
                Props = new DivProps
                {
                    Class = "my-6 border border-indigo-200 dark:border-indigo-800 rounded-lg bg-indigo-50/60 dark:bg-indigo-950/40 p-6".ToConstSignal(),
                },
                Children =
                [
                    // Header with info icon
                    new Div
                    {
                        Props = new DivProps
                        {
                            Class = "flex items-center gap-2 mb-4".ToConstSignal(),
                        },
                        Children =
                        [
                            new Span
                            {
                                Props = new SpanProps
                                {
                                    Class = "inline-flex items-center justify-center w-6 h-6 rounded-full border-2 border-indigo-400 text-indigo-600 dark:text-indigo-400 text-sm font-bold".ToConstSignal(),
                                },
                                Children = [new DomText { Text = "i".ToConstSignal() }],
                            },
                            new Span
                            {
                                Props = new SpanProps
                                {
                                    Class = "text-lg font-semibold text-gray-900 dark:text-white".ToConstSignal(),
                                },
                                Children = [new DomText { Text = "Prerequisites".ToConstSignal() }],
                            },
                        ],
                    },
                    // Slot content (list items)
                    new Ul
                    {
                        Props = new UlProps
                        {
                            Class = "list-disc list-inside space-y-2 text-gray-600 dark:text-gray-400".ToConstSignal(),
                        },
                        Children = Slots?.Default() ?? [],
                    },
                ],
            },
        ];
    }
}
