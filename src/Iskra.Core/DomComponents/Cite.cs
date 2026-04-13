using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class CiteProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class CiteEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Cite() : BaseNonVoidDomComponent<HTMLElement, CiteProps, CiteEvents>("cite")
{
}
