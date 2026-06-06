using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Ssr.Abstractions.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Dom.Components;

public class IFrameProps : GlobalHtmlComponentProps<HTMLIFrameElement>
{
    public IReadOnlySignal<string>? Src { get; init; }
    public IReadOnlySignal<string>? Name { get; init; }
    public IReadOnlySignal<string>? Allow { get; init; }
    public IReadOnlySignal<bool>? AllowFullscreen { get; init; }
    public IReadOnlySignal<string>? Width { get; init; }
    public IReadOnlySignal<string>? Height { get; init; }
    public IReadOnlySignal<string>? ReferrerPolicy { get; init; }
    public IReadOnlySignal<string>? Loading { get; init; }
    public IReadOnlySignal<string>? Sandbox { get; init; }
    public IReadOnlySignal<string>? SrcDoc { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLIFrameElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Src != null)
        {
            register(el => el.Src = Src.Value);
        }

        if (Name != null)
        {
            register(el => el.Name = Name.Value);
        }

        if (Allow != null)
        {
            register(el => el.Allow = Allow.Value);
        }

        if (AllowFullscreen != null)
        {
            register(el => el.AllowFullscreen = AllowFullscreen.Value);
        }

        if (Width != null)
        {
            register(el => el.Width = Width.Value);
        }

        if (Height != null)
        {
            register(el => el.Height = Height.Value);
        }

        if (ReferrerPolicy != null)
        {
            register(el => el.ReferrerPolicy = ReferrerPolicy.Value);
        }

        if (Loading != null)
        {
            register(el => el.Loading = Loading.Value);
        }

        if (Sandbox != null)
        {
            register(el => el.Sandbox.Value = Sandbox.Value);
        }

        if (SrcDoc != null)
        {
            register(el => el.Srcdoc = SrcDoc.Value);
        }
    }

    protected internal override void RegisterServerEffects(SsrElementNode el)
    {
        base.RegisterServerEffects(el);

        if (Src != null)
        {
            el.SetAttribute("src", Src);
        }

        if (Name != null)
        {
            el.SetAttribute("name", Name);
        }

        if (Allow != null)
        {
            el.SetAttribute("allow", Allow);
        }

        if (AllowFullscreen != null)
        {
            el.SetBoolean("allowfullscreen", AllowFullscreen);
        }

        if (Width != null)
        {
            el.SetAttribute("width", Width);
        }

        if (Height != null)
        {
            el.SetAttribute("height", Height);
        }

        if (ReferrerPolicy != null)
        {
            el.SetAttribute("referrerpolicy", ReferrerPolicy);
        }

        if (Loading != null)
        {
            el.SetAttribute("loading", Loading);
        }

        if (Sandbox != null)
        {
            el.SetAttribute("sandbox", Sandbox);
        }

        if (SrcDoc != null)
        {
            el.SetAttribute("srcdoc", SrcDoc);
        }
    }
}

public class IFrameEvents : HtmlElementComponentEvents<HTMLIFrameElement>
{
}

public class IFrame() : BaseNonVoidDomComponent<HTMLIFrameElement, IFrameProps, IFrameEvents>("iframe")
{
}
