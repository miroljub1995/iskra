using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class LegendProps : GlobalHtmlComponentProps<HTMLLegendElement>
{
}

public class LegendEvents : HtmlElementComponentEvents<HTMLLegendElement>
{
}

public class Legend() : BaseNonVoidDomComponent<HTMLLegendElement, LegendProps, LegendEvents>("legend")
{
}
