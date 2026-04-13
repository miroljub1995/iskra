using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class UProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class UEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class U() : BaseNonVoidDomComponent<HTMLElement, UProps, UEvents>("u")
{
}
