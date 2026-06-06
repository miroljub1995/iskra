using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class SectionProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class SectionEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Section() : BaseNonVoidDomComponent<HTMLElement, SectionProps, SectionEvents>("section")
{
}
