using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class HrProps : GlobalHtmlComponentProps<HTMLHRElement>
{
}

public class HrEvents : HtmlElementComponentEvents<HTMLHRElement>
{
}

public class Hr() : BaseVoidDomComponent<HTMLHRElement, HrProps, HrEvents>("hr")
{
}
