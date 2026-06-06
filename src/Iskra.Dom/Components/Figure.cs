using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class FigureProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class FigureEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Figure() : BaseNonVoidDomComponent<HTMLElement, FigureProps, FigureEvents>("figure")
{
}
