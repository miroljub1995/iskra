using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class RubyProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class RubyEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Ruby() : BaseNonVoidDomComponent<HTMLElement, RubyProps, RubyEvents>("ruby")
{
}
