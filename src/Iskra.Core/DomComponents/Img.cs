using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class ImgProps : GlobalHtmlComponentProps<HTMLImageElement>
{
    public IReadOnlySignal<string>? Alt { get; init; }
    public IReadOnlySignal<string>? Src { get; init; }
    public IReadOnlySignal<string>? Srcset { get; init; }
    public IReadOnlySignal<string>? Sizes { get; init; }
    public IReadOnlySignal<string?>? CrossOrigin { get; init; }
    public IReadOnlySignal<string>? UseMap { get; init; }
    public IReadOnlySignal<bool>? IsMap { get; init; }
    public IReadOnlySignal<uint>? Width { get; init; }
    public IReadOnlySignal<uint>? Height { get; init; }
    public IReadOnlySignal<string>? Decoding { get; init; }
    public IReadOnlySignal<string>? FetchPriority { get; init; }
    public IReadOnlySignal<string>? Loading { get; init; }
    public IReadOnlySignal<string>? ReferrerPolicy { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLImageElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Alt != null)
        {
            register(el => el.Alt = Alt.Value);
        }

        if (Src != null)
        {
            register(el => el.Src = Src.Value);
        }

        if (Srcset != null)
        {
            register(el => el.Srcset = Srcset.Value);
        }

        if (Sizes != null)
        {
            register(el => el.Sizes = Sizes.Value);
        }

        if (CrossOrigin != null)
        {
            register(el => el.CrossOrigin = CrossOrigin.Value);
        }

        if (UseMap != null)
        {
            register(el => el.UseMap = UseMap.Value);
        }

        if (IsMap != null)
        {
            register(el => el.IsMap = IsMap.Value);
        }

        if (Width != null)
        {
            register(el => el.Width = Width.Value);
        }

        if (Height != null)
        {
            register(el => el.Height = Height.Value);
        }

        if (Decoding != null)
        {
            register(el => el.Decoding = Decoding.Value);
        }

        if (FetchPriority != null)
        {
            register(el => el.FetchPriority = FetchPriority.Value);
        }

        if (Loading != null)
        {
            register(el => el.Loading = Loading.Value);
        }

        if (ReferrerPolicy != null)
        {
            register(el => el.ReferrerPolicy = ReferrerPolicy.Value);
        }
    }

    protected internal override void RegisterServerEffects(SsrElementNode el)
    {
        base.RegisterServerEffects(el);

        if (Alt != null)
        {
            el.SetAttribute("alt", Alt);
        }

        if (Src != null)
        {
            el.SetAttribute("src", Src);
        }

        if (Srcset != null)
        {
            el.SetAttribute("srcset", Srcset);
        }

        if (Sizes != null)
        {
            el.SetAttribute("sizes", Sizes);
        }

        if (CrossOrigin != null)
        {
            el.SetNullableString("crossorigin", CrossOrigin);
        }

        if (UseMap != null)
        {
            el.SetAttribute("usemap", UseMap);
        }

        if (IsMap != null)
        {
            el.SetBoolean("ismap", IsMap);
        }

        if (Width != null)
        {
            el.SetUInt("width", Width);
        }

        if (Height != null)
        {
            el.SetUInt("height", Height);
        }

        if (Decoding != null)
        {
            el.SetAttribute("decoding", Decoding);
        }

        if (FetchPriority != null)
        {
            el.SetAttribute("fetchpriority", FetchPriority);
        }

        if (Loading != null)
        {
            el.SetAttribute("loading", Loading);
        }

        if (ReferrerPolicy != null)
        {
            el.SetAttribute("referrerpolicy", ReferrerPolicy);
        }
    }
}

public class ImgEvents : HtmlElementComponentEvents<HTMLImageElement>
{
}

public class Img() : BaseVoidDomComponent<HTMLImageElement, ImgProps, ImgEvents>("img")
{
}
