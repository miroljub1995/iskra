using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class CodeProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class CodeEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Code() : BaseNonVoidDomComponent<HTMLElement, CodeProps, CodeEvents>("code")
{
}
