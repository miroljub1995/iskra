using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class BrProps : GlobalHtmlComponentProps<HTMLBRElement>
{
}

public class BrEvents : HtmlElementComponentEvents<HTMLBRElement>
{
}

public class Br() : BaseVoidDomComponent<HTMLBRElement, BrProps, BrEvents>("br")
{
}
