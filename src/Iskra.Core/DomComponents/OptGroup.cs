using System.Runtime.Versioning;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class OptGroupProps : GlobalHtmlComponentProps<HTMLOptGroupElement>
{
    public IReadOnlySignal<bool>? Disabled { get; init; }
    public IReadOnlySignal<string>? Label { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLOptGroupElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Disabled != null)
        {
            register(el => el.Disabled = Disabled.Value);
        }

        if (Label != null)
        {
            register(el => el.Label = Label.Value);
        }
    }
}

public class OptGroupEvents : HtmlElementComponentEvents<HTMLOptGroupElement>
{
}

public class OptGroup() : BaseNonVoidDomComponent<HTMLOptGroupElement, OptGroupProps, OptGroupEvents>("optgroup")
{
}
