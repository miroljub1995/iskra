using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class RubyProps : GlobalHtmlComponentProps<HTMLElement>
{
}

public class RubyEvents : HtmlElementComponentEvents<HTMLElement>
{
}

public class Ruby() : BaseNonVoidDomComponent<HTMLElement, RubyProps, RubyEvents>("ruby")
{
}
