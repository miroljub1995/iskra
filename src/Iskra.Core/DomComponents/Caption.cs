using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class CaptionProps : GlobalHtmlComponentProps<HTMLTableCaptionElement>
{
}

public class CaptionEvents : HtmlElementComponentEvents<HTMLTableCaptionElement>
{
}

public class Caption() : BaseNonVoidDomComponent<HTMLTableCaptionElement, CaptionProps, CaptionEvents>("caption")
{
}
