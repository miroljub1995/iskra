using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class SampProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class SampEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Samp() : BaseNonVoidDomComponent<HTMLElement, SampProps, SampEvents>("samp")
{
}
