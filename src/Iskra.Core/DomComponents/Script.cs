using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class ScriptProps : GlobalHtmlComponentProps<HTMLScriptElement>
{
    public IReadOnlySignal<string>? Src { get; init; }
    public IReadOnlySignal<string>? Type { get; init; }
    public IReadOnlySignal<bool>? NoModule { get; init; }
    public IReadOnlySignal<bool>? Async { get; init; }
    public IReadOnlySignal<bool>? Defer { get; init; }
    public IReadOnlySignal<string?>? CrossOrigin { get; init; }
    public IReadOnlySignal<string>? Integrity { get; init; }
    public IReadOnlySignal<string>? ReferrerPolicy { get; init; }
    public IReadOnlySignal<string>? FetchPriority { get; init; }
    public IReadOnlySignal<string>? Blocking { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLScriptElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Src != null)
        {
            register(el => el.Src = Src.Value);
        }

        if (Type != null)
        {
            register(el => el.Type = Type.Value);
        }

        if (NoModule != null)
        {
            register(el => el.NoModule = NoModule.Value);
        }

        if (Async != null)
        {
            register(el => el.Async = Async.Value);
        }

        if (Defer != null)
        {
            register(el => el.Defer = Defer.Value);
        }

        if (CrossOrigin != null)
        {
            register(el => el.CrossOrigin = CrossOrigin.Value);
        }

        if (Integrity != null)
        {
            register(el => el.Integrity = Integrity.Value);
        }

        if (ReferrerPolicy != null)
        {
            register(el => el.ReferrerPolicy = ReferrerPolicy.Value);
        }

        if (FetchPriority != null)
        {
            register(el => el.FetchPriority = FetchPriority.Value);
        }

        if (Blocking != null)
        {
            register(el => el.Blocking.Value = Blocking.Value);
        }
    }

    protected internal override void RegisterServerEffects(SsrElementNode el)
    {
        base.RegisterServerEffects(el);

        if (Src != null)
        {
            el.SetAttribute("src", Src);
        }

        if (Type != null)
        {
            el.SetAttribute("type", Type);
        }

        if (NoModule != null)
        {
            el.SetBoolean("nomodule", NoModule);
        }

        if (Async != null)
        {
            el.SetBoolean("async", Async);
        }

        if (Defer != null)
        {
            el.SetBoolean("defer", Defer);
        }

        if (CrossOrigin != null)
        {
            el.SetNullableString("crossorigin", CrossOrigin);
        }

        if (Integrity != null)
        {
            el.SetAttribute("integrity", Integrity);
        }

        if (ReferrerPolicy != null)
        {
            el.SetAttribute("referrerpolicy", ReferrerPolicy);
        }

        if (FetchPriority != null)
        {
            el.SetAttribute("fetchpriority", FetchPriority);
        }

        if (Blocking != null)
        {
            el.SetAttribute("blocking", Blocking);
        }
    }
}

public class ScriptEvents : HtmlElementComponentEvents<HTMLScriptElement>
{
}

public class Script() : BaseNonVoidDomComponent<HTMLScriptElement, ScriptProps, ScriptEvents>("script")
{
}
