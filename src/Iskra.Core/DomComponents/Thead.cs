using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class TheadProps : GlobalHtmlComponentProps<HTMLTableSectionElement>
{
}

public class TheadEvents : HtmlElementComponentEvents<HTMLTableSectionElement>
{
}

public class Thead() : BaseNonVoidDomComponent<HTMLTableSectionElement, TheadProps, TheadEvents>("thead")
{
}
