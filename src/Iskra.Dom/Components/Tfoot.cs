using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class TfootProps : GlobalHtmlComponentProps<HTMLTableSectionElement>
{
}

public class TfootEvents : HtmlElementComponentEvents<HTMLTableSectionElement>
{
}

public class Tfoot() : BaseNonVoidDomComponent<HTMLTableSectionElement, TfootProps, TfootEvents>("tfoot")
{
}
