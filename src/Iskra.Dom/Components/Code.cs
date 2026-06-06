using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class CodeProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class CodeEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Code() : BaseNonVoidDomComponent<HTMLElement, CodeProps, CodeEvents>("code")
{
}
