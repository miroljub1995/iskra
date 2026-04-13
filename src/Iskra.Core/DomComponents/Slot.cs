using System.Runtime.Versioning;
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
}

public class SlotEvents : HtmlElementComponentEvents<HTMLSlotElement>
{
}

public class Slot() : BaseNonVoidDomComponent<HTMLSlotElement, SlotProps, SlotEvents>("slot")
{
}
