using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class SlotProps : GlobalHtmlComponentProps<HTMLSlotElement>
{
    public IReadOnlySignal<string>? Name { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLSlotElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Name != null)
        {
            register(el => el.Name = Name.Value);
        }
    }

    protected internal override void RegisterServerEffects(Action<Action<SsrElementNode>> register)
    {
        base.RegisterServerEffects(register);

        if (Name != null)
        {
            register(el => el.SetAttribute("name", Name.Value));
        }
    }
}

public class SlotEvents : HtmlElementComponentEvents<HTMLSlotElement>
{
}

public class Slot() : BaseNonVoidDomComponent<HTMLSlotElement, SlotProps, SlotEvents>("slot")
{
}
