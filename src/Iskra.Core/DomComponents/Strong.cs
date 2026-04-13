using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class StrongProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class StrongEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Strong() : BaseNonVoidDomComponent<HTMLElement, StrongProps, StrongEvents>("strong")
{
}
