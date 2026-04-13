using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class VarProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class VarEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Var() : BaseNonVoidDomComponent<HTMLElement, VarProps, VarEvents>("var")
{
}
