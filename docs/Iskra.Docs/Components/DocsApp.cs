using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Signals;

namespace Iskra.Docs.Components;

public class DocsAppProps { }

public class DocsApp : BaseComponent<DocsAppProps, BaseEmits, object>
{
    protected override IComponent[] Setup(DocsAppProps props, BaseEmits? events, out object exposed)
    {
        exposed = new object();

        return
        [
            new Main
            {
                Props = new MainProps(),
                Children =
                [
                    new H1
                    {
                        Props = new H1Props(),
                        Children = [new DomText { Text = new Signal<string>("Iskra Documentat") }],
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
