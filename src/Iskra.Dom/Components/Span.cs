using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class SpanProps : GlobalHtmlComponentProps<HTMLSpanElement>
{
}

public class SpanEvents : HtmlElementComponentEvents<HTMLSpanElement>
{
}

public class Span() : BaseNonVoidDomComponent<HTMLSpanElement, SpanProps, SpanEvents>("span")
{
}
