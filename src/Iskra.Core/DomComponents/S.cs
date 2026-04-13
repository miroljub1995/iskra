using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class SProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class SEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class S() : BaseNonVoidDomComponent<HTMLElement, SProps, SEvents>("s")
{
}
