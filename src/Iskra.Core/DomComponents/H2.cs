using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class H2Props : GlobalHtmlComponentProps<HTMLHeadingElement>
{
}

public class H2Events : HtmlElementComponentEvents<HTMLHeadingElement>
{
}

public class H2() : BaseNonVoidDomComponent<HTMLHeadingElement, H2Props, H2Events>("h2")
{
}
