using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class HgroupProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class HgroupEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Hgroup() : BaseNonVoidDomComponent<HTMLElement, HgroupProps, HgroupEvents>("hgroup")
{
}
