using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class TemplateProps : GlobalHtmlComponentProps<HTMLTemplateElement>
{
}

public class TemplateEvents : HtmlElementComponentEvents<HTMLTemplateElement>
{
}

public class Template() : BaseNonVoidDomComponent<HTMLTemplateElement, TemplateProps, TemplateEvents>("template")
{
}
