using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class TfootProps : GlobalHtmlComponentProps<HTMLTableSectionElement>
{
}

public class TfootEvents : HtmlElementComponentEvents<HTMLTableSectionElement>
{
}

public class Tfoot() : BaseNonVoidDomComponent<HTMLTableSectionElement, TfootProps, TfootEvents>("tfoot")
{
}
