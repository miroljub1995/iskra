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
            new H2
            {
                Props = new H2Props(),
                Children = [new DomText { Text = new Signal<string>("Home") }],
            },
            new P
            {
                Props = new PProps(),
                Children = [new DomText { Text = new Signal<string>("Welcome to Iskra — a reactive UI framework for .NET.") }],
            },
        ];
    }
}
