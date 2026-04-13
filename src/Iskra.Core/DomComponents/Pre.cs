using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class PreProps : GlobalHtmlComponentProps<HTMLPreElement>
{
}

public class PreEvents : HtmlElementComponentEvents<HTMLPreElement>
{
}

public class Pre() : BaseNonVoidDomComponent<HTMLPreElement, PreProps, PreEvents>("pre")
{
}
