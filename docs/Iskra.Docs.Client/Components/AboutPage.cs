using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Signals;

namespace Iskra.Docs.Client.Components;

public class AboutPageProps { }

public class AboutPage : BaseComponent<AboutPageProps, NoEvents, NoSlots, NoExpose>
{
    protected override IComponent[] Setup(out NoExpose exposed)
    {
        exposed = default;

        return
        [
            new H2
            {
                Props = new H2Props(),
                Children = [new DomText { Text = new Signal<string>("About") }],
            },
            new P
            {
                Props = new PProps(),
                Children = [new DomText { Text = new Signal<string>("Iskra is a reactive UI framework for .NET that supports both server-side rendering and client-side interactivity.") }],
            },
        ];
    }
}
