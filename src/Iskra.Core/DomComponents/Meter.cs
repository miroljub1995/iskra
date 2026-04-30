using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class MeterProps : GlobalHtmlComponentProps<HTMLMeterElement>
{
    public IReadOnlySignal<double>? Value { get; init; }
    public IReadOnlySignal<double>? Min { get; init; }
    public IReadOnlySignal<double>? Max { get; init; }
    public IReadOnlySignal<double>? Low { get; init; }
    public IReadOnlySignal<double>? High { get; init; }
    public IReadOnlySignal<double>? Optimum { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLMeterElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Value != null)
        {
            register(el => el.Value = Value.Value);
        }

        if (Min != null)
        {
            register(el => el.Min = Min.Value);
        }

        if (Max != null)
        {
            register(el => el.Max = Max.Value);
        }

        if (Low != null)
        {
            register(el => el.Low = Low.Value);
        }

        if (High != null)
        {
            register(el => el.High = High.Value);
        }

        if (Optimum != null)
        {
            register(el => el.Optimum = Optimum.Value);
        }
    }

    protected internal override void RegisterServerEffects(Action<Action<SsrElementNode>> register)
    {
        base.RegisterServerEffects(register);

        if (Value != null)
        {
            register(el => SsrAttributes.SetDouble(el, "value", Value.Value));
        }

        if (Min != null)
        {
            register(el => SsrAttributes.SetDouble(el, "min", Min.Value));
        }

        if (Max != null)
        {
            register(el => SsrAttributes.SetDouble(el, "max", Max.Value));
        }

        if (Low != null)
        {
            register(el => SsrAttributes.SetDouble(el, "low", Low.Value));
        }

        if (High != null)
        {
            register(el => SsrAttributes.SetDouble(el, "high", High.Value));
        }

        if (Optimum != null)
        {
            register(el => SsrAttributes.SetDouble(el, "optimum", Optimum.Value));
        }
    }
}

public class MeterEvents : HtmlElementComponentEvents<HTMLMeterElement>
{
}

public class Meter() : BaseNonVoidDomComponent<HTMLMeterElement, MeterProps, MeterEvents>("meter")
{
}
