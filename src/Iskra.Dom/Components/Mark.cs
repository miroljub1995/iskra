using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class MarkProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class MarkEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Mark() : BaseNonVoidDomComponent<HTMLElement, MarkProps, MarkEvents>("mark")
{
}
