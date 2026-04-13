using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class H5Props : GlobalHtmlComponentProps<HTMLHeadingElement>
{
}

public class H5Events : HtmlElementComponentEvents<HTMLHeadingElement>
{
}

public class H5() : BaseNonVoidDomComponent<HTMLHeadingElement, H5Props, H5Events>("h5")
{
}
