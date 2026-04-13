using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class BdoProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class BdoEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Bdo() : BaseNonVoidDomComponent<HTMLElement, BdoProps, BdoEvents>("bdo")
{
}
