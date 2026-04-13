using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class MarkProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class MarkEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Mark() : BaseNonVoidDomComponent<HTMLElement, MarkProps, MarkEvents>("mark")
{
}
