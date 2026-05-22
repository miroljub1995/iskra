using Iskra.Core.Components;
using Iskra.Core.DomComponents;
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
            new Main
            {
                Props = new MainProps(),
                Children =
                [
                    new Header
                    {
                        Props = new HeaderProps(),
                    },
                    new P
                    {
                        Props = new PProps(),
                        Children = [new DomText { Text = new Signal<string>("Welcome to Iskra — a reactive UI framework for .NET.") }],
                    },
                ],
            },
        ];
    }
}
