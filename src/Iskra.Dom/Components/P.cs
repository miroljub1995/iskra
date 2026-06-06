using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class PProps : GlobalHtmlComponentProps<HTMLParagraphElement>
{
}

public class PEvents : HtmlElementComponentEvents<HTMLParagraphElement>
{
}

public class P() : BaseNonVoidDomComponent<HTMLParagraphElement, PProps, PEvents>("p")
{
}
