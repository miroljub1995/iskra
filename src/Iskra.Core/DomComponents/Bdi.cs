using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class BdiProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class BdiEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Bdi() : BaseNonVoidDomComponent<HTMLElement, BdiProps, BdiEvents>("bdi")
{
}
