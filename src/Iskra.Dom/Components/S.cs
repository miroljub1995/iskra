using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class SProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class SEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class S() : BaseNonVoidDomComponent<HTMLElement, SProps, SEvents>("s")
{
}
