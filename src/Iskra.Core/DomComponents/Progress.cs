using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class ProgressProps : GlobalHtmlComponentProps<HTMLProgressElement>
{
    public IReadOnlySignal<double>? Value { get; init; }
    public IReadOnlySignal<double>? Max { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLProgressElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Value != null)
        {
            register(el => el.Value = Value.Value);
        }

        if (Max != null)
        {
            register(el => el.Max = Max.Value);
        }
    }

    protected internal override void RegisterServerEffects(Action<Action<SsrElementNode>> register)
    {
        base.RegisterServerEffects(register);

        if (Value != null)
        {
            register(el => SsrAttributes.SetDouble(el, "value", Value.Value));
        }

        if (Max != null)
        {
            register(el => SsrAttributes.SetDouble(el, "max", Max.Value));
        }
    }
}

public class ProgressEvents : HtmlElementComponentEvents<HTMLProgressElement>
{
}

public class Progress() : BaseNonVoidDomComponent<HTMLProgressElement, ProgressProps, ProgressEvents>("progress")
{
}
