using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class PictureProps : GlobalHtmlComponentProps<HTMLPictureElement>
{
}

public class PictureEvents : HtmlElementComponentEvents<HTMLPictureElement>
{
}

public class Picture() : BaseNonVoidDomComponent<HTMLPictureElement, PictureProps, PictureEvents>("picture")
{
}
