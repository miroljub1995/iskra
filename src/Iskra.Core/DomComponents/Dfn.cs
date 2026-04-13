using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class DfnProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class DfnEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Dfn() : BaseNonVoidDomComponent<HTMLElement, DfnProps, DfnEvents>("dfn")
{
}
