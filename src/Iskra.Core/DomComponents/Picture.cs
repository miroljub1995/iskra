using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class PictureProps : GlobalHtmlComponentProps<HTMLPictureElement>
{
}

public class PictureEvents : HtmlElementComponentEvents<HTMLPictureElement>
{
}

public class Picture() : BaseNonVoidDomComponent<HTMLPictureElement, PictureProps, PictureEvents>("picture")
{
}
