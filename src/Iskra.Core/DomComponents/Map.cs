using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class MapProps : GlobalHtmlComponentProps<HTMLMapElement>
{
    public IReadOnlySignal<string>? Name { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLMapElement>> register)
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

public class MapEvents : HtmlElementComponentEvents<HTMLMapElement>
{
}

public class Map() : BaseNonVoidDomComponent<HTMLMapElement, MapProps, MapEvents>("map")
{
}
