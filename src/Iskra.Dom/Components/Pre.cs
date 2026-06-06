using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class PreProps : GlobalHtmlComponentProps<HTMLPreElement>
{
}

public class PreEvents : HtmlElementComponentEvents<HTMLPreElement>
{
}

public class Pre() : BaseNonVoidDomComponent<HTMLPreElement, PreProps, PreEvents>("pre")
{
}
