using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Signals;

namespace Iskra.Docs.Client.Components;

public class SetupPageProps { }

public class SetupPage : BaseComponent<SetupPageProps, NoEvents, NoSlots, NoExpose>
{
    protected override IComponent[] Setup(out NoExpose exposed)
    {
        exposed = default;

        return
        [
            new H2
            {
                Props = new H2Props(),
                Children = [new DomText { Text = "Setup".ToConstSignal() }],
            },
            new P
            {
                Props = new PProps(),
                Children = [new DomText { Text = "Iskra is a reactive UI framework for .NET that supports both server-side rendering and client-side interactivity.".ToConstSignal() }],
            },
        ];
    }
}
