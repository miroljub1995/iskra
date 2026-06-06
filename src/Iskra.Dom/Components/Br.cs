using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class BrProps : GlobalHtmlComponentProps<HTMLBRElement>
{
}

public class BrEvents : HtmlElementComponentEvents<HTMLBRElement>
{
}

public class Br() : BaseVoidDomComponent<HTMLBRElement, BrProps, BrEvents>("br")
{
}
