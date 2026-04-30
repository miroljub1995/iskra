using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
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

    protected internal override void RegisterServerEffects(Action<Action<SsrElementNode>> register)
    {
        base.RegisterServerEffects(register);

        if (Open != null)
        {
            register(el => SsrAttributes.SetBoolean(el, "open", Open.Value));
        }
    }
}

public class DialogEvents : HtmlElementComponentEvents<HTMLDialogElement>
{
}

public class Dialog() : BaseNonVoidDomComponent<HTMLDialogElement, DialogProps, DialogEvents>("dialog")
{
}
