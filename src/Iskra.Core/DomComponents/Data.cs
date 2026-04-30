using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class DataProps : GlobalHtmlComponentProps<HTMLDataElement>
{
    public IReadOnlySignal<string>? Value { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLDataElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Value != null)
        {
            register(el => el.Value = Value.Value);
        }
    }

    protected internal override void RegisterServerEffects(Action<Action<SsrElementNode>> register)
    {
        base.RegisterServerEffects(register);

        if (Value != null)
        {
            register(el => el.SetAttribute("value", Value.Value));
        }
    }
}

public class DataEvents : HtmlElementComponentEvents<HTMLDataElement>
{
}

public class Data() : BaseNonVoidDomComponent<HTMLDataElement, DataProps, DataEvents>("data")
{
}
