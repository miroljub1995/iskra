using System.Runtime.Versioning;
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
}

public class MapEvents : HtmlElementComponentEvents<HTMLMapElement>
{
}

public class Map() : BaseNonVoidDomComponent<HTMLMapElement, MapProps, MapEvents>("map")
{
}
