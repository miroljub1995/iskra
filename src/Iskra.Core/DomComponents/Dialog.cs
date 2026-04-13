using System.Runtime.Versioning;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class DialogProps : GlobalHtmlComponentProps<HTMLDialogElement>
{
    public IReadOnlySignal<bool>? Open { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLDialogElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Open != null)
        {
            register(el => el.Open = Open.Value);
        }
    }
}

public class DialogEvents : HtmlElementComponentEvents<HTMLDialogElement>
{
}

public class Dialog() : BaseNonVoidDomComponent<HTMLDialogElement, DialogProps, DialogEvents>("dialog")
{
}
