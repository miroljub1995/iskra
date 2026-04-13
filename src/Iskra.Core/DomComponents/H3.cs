using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class H3Props : GlobalHtmlComponentProps<HTMLHeadingElement>
{
}

public class H3Events : HtmlElementComponentEvents<HTMLHeadingElement>
{
}

public class H3() : BaseNonVoidDomComponent<HTMLHeadingElement, H3Props, H3Events>("h3")
{
}
