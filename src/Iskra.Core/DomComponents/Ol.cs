using System.Runtime.Versioning;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class OlProps : GlobalHtmlComponentProps<HTMLOListElement>
{
    public IReadOnlySignal<bool>? Reversed { get; init; }
    public IReadOnlySignal<int>? Start { get; init; }
    public IReadOnlySignal<string>? Type { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLOListElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Reversed != null)
        {
            register(el => el.Reversed = Reversed.Value);
        }

        if (Start != null)
        {
            register(el => el.Start = Start.Value);
        }

        if (Type != null)
        {
            register(el => el.Type = Type.Value);
        }
    }
}

public class OlEvents : HtmlElementComponentEvents<HTMLOListElement>
{
}

public class Ol() : BaseNonVoidDomComponent<HTMLOListElement, OlProps, OlEvents>("ol")
{
}
