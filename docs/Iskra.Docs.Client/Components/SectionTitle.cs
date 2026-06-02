using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Signals;

namespace Iskra.Docs.Client.Components;

public class SectionTitleProps
{
    public required IReadOnlySignal<string> Text { get; init; }
    public required IReadOnlySignal<string> Id { get; init; }
}

public class SectionTitleSlots
{
    public required Func<IComponent[]> Default { get; init; }
}

public class SectionTitle : BaseComponent<SectionTitleProps, NoEvents, SectionTitleSlots, NoExpose>
{
    protected override IComponent[] Setup(out NoExpose exposed)
    {
        exposed = default;

        return
        [
            new H2
            {
                Props = new H2Props
                {
                    Id = Props.Id,
                    Class = "group text-2xl font-bold text-gray-900 dark:text-white mt-4 border-t border-gray-200 dark:border-gray-700 pt-4 mb-4".ToConstSignal(),
                },
                Children =
                [
                    new A
                    {
                        Props = new AProps
                        {
                            Href = new Computed<string>(() => $"#{Props.Id.Value}"),
                            Class = "opacity-0 group-hover:opacity-100 text-indigo-400 dark:text-indigo-500 no-underline transition-opacity mr-2".ToConstSignal(),
                        },
                        Children = [new DomText { Text = "#".ToConstSignal() }],
                    },
                    new DomText { Text = Props.Text },
                ],
            },
            new Div
            {
                Props = new DivProps
                {
                    Class = "pl-7".ToConstSignal(),
                },
                Children = Slots?.Default() ?? [],
            },
        ];
    }
}
