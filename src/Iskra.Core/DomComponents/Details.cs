using System.Runtime.Versioning;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class DetailsProps : GlobalHtmlComponentProps<HTMLDetailsElement>
{
    public IReadOnlySignal<string>? Name { get; init; }
    public IReadOnlySignal<bool>? Open { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLDetailsElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Name != null)
        {
            register(el => el.Name = Name.Value);
        }

        if (Open != null)
        {
            register(el => el.Open = Open.Value);
        }
    }
}

public class DetailsEvents : HtmlElementComponentEvents<HTMLDetailsElement>
{
}

public class Details() : BaseNonVoidDomComponent<HTMLDetailsElement, DetailsProps, DetailsEvents>("details")
{
}
