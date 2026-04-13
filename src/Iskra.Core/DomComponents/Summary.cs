using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class SummaryProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class SummaryEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Summary() : BaseNonVoidDomComponent<HTMLElement, SummaryProps, SummaryEvents>("summary")
{
}
