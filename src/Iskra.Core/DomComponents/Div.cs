using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class DivProps : GlobalHtmlComponentProps<HTMLDivElement>
{
}

public class DivEvents : HtmlElementComponentEvents<HTMLDivElement>
{
}

public class Div() : BaseNonVoidDomComponent<HTMLDivElement, DivProps, DivEvents>("div")
{
}