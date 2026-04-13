using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class FigCaptionProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class FigCaptionEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class FigCaption() : BaseNonVoidDomComponent<HTMLElement, FigCaptionProps, FigCaptionEvents>("figcaption")
{
}
