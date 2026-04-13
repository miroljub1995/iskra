using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class H1Props : GlobalHtmlComponentProps<HTMLHeadingElement>
{
}

public class H1Events : HtmlElementComponentEvents<HTMLHeadingElement>
{
}

public class H1() : BaseNonVoidDomComponent<HTMLHeadingElement, H1Props, H1Events>("h1")
{
}
