using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class TrProps : GlobalHtmlComponentProps<HTMLTableRowElement>
{
}

public class TrEvents : HtmlElementComponentEvents<HTMLTableRowElement>
{
}

public class Tr() : BaseNonVoidDomComponent<HTMLTableRowElement, TrProps, TrEvents>("tr")
{
}
