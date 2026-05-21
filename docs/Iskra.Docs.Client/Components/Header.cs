using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Signals;

namespace Iskra.Docs.Client.Components;

public class HeaderProps { }

public class Header : BaseComponent<HeaderProps, BaseEmits, object>
{
    protected override IComponent[] Setup(HeaderProps props, BaseEmits? events, out object exposed)
    {
        exposed = new object();

        return
        [
            new H1
            {
                Props = new H1Props(),
                Children = [new DomText { Text = new Signal<string>("Iskra Documentation") }],
            },
        ];
    }
}
