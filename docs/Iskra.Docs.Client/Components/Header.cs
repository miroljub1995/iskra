using Iskra.Core.Components;
using Iskra.Core.DomComponents;
using Iskra.Signals;

namespace Iskra.Docs.Client.Components;

public class HeaderProps { }

public class Header : BaseComponent<HeaderProps, NoEvents, NoSlots, NoExpose>
{
    protected override IComponent[] Setup(out NoExpose exposed)
    {
        exposed = default;

        return
        [
            new Img
            {
                Props = new ImgProps { Src = new Signal<string>(WwwRoot.Assets_Icon_Png) },
            },
            new H1
            {
                Props = new H1Props(),
                Children = [new DomText { Text = new Signal<string>("Iskra Documentation") }],
            },
        ];
    }
}
