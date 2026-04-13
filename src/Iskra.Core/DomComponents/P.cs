using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class PProps : GlobalHtmlComponentProps<HTMLParagraphElement>
{
}

public class PEvents : HtmlElementComponentEvents<HTMLParagraphElement>
{
}

public class P() : BaseNonVoidDomComponent<HTMLParagraphElement, PProps, PEvents>("p")
{
}
