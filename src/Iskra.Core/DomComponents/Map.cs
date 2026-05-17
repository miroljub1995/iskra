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

    protected internal override void RegisterServerEffects(SsrElementNode el)
    {
        base.RegisterServerEffects(el);

        if (Name != null)
        {
            el.SetAttribute("name", Name);
        }
    }
}

public class MapEvents : HtmlElementComponentEvents<HTMLMapElement>
{
}

public class Map() : BaseNonVoidDomComponent<HTMLMapElement, MapProps, MapEvents>("map")
{
}
