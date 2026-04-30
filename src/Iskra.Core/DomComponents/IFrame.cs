using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

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

    protected internal override void RegisterServerEffects(Action<Action<SsrElementNode>> register)
    {
        base.RegisterServerEffects(register);

        if (Src != null)
        {
            register(el => el.SetAttribute("src", Src.Value));
        }

        if (Name != null)
        {
            register(el => el.SetAttribute("name", Name.Value));
        }

        if (Allow != null)
        {
            register(el => el.SetAttribute("allow", Allow.Value));
        }

        if (AllowFullscreen != null)
        {
            register(el => SsrAttributes.SetBoolean(el, "allowfullscreen", AllowFullscreen.Value));
        }

        if (Width != null)
        {
            register(el => el.SetAttribute("width", Width.Value));
        }

        if (Height != null)
        {
            register(el => el.SetAttribute("height", Height.Value));
        }

        if (ReferrerPolicy != null)
        {
            register(el => el.SetAttribute("referrerpolicy", ReferrerPolicy.Value));
        }

        if (Loading != null)
        {
            register(el => el.SetAttribute("loading", Loading.Value));
        }

        if (Sandbox != null)
        {
            register(el => el.SetAttribute("sandbox", Sandbox.Value));
        }

        if (SrcDoc != null)
        {
            register(el => el.SetAttribute("srcdoc", SrcDoc.Value));
        }
    }
}

public class IFrameEvents : HtmlElementComponentEvents<HTMLIFrameElement>
{
}

public class IFrame() : BaseNonVoidDomComponent<HTMLIFrameElement, IFrameProps, IFrameEvents>("iframe")
{
}
