using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class SpanProps : GlobalHtmlComponentProps<HTMLSpanElement>
{
}

public class SpanEvents : HtmlElementComponentEvents<HTMLSpanElement>
{
}

public class Span() : BaseNonVoidDomComponent<HTMLSpanElement, SpanProps, SpanEvents>("span")
{
}
