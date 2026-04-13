using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class FigureProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class FigureEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Figure() : BaseNonVoidDomComponent<HTMLElement, FigureProps, FigureEvents>("figure")
{
}
