using System.Runtime.Versioning;
using Iskra.Core.RenderRoot;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class FormProps : GlobalHtmlComponentProps<HTMLFormElement>
{
    public IReadOnlySignal<string>? Action { get; init; }
    public IReadOnlySignal<string>? Autocomplete { get; init; }
    public IReadOnlySignal<string>? Enctype { get; init; }
    public IReadOnlySignal<string>? Method { get; init; }
    public IReadOnlySignal<string>? Name { get; init; }
    public IReadOnlySignal<bool>? NoValidate { get; init; }
    public IReadOnlySignal<string>? Target { get; init; }
    public IReadOnlySignal<string>? Rel { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLFormElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Action != null)
        {
            register(el => el.Action = Action.Value);
        }

        if (Autocomplete != null)
        {
            register(el => el.Autocomplete = Autocomplete.Value);
        }

        if (Enctype != null)
        {
            register(el => el.Enctype = Enctype.Value);
        }

        if (Method != null)
        {
            register(el => el.Method = Method.Value);
        }

        if (Name != null)
        {
            register(el => el.Name = Name.Value);
        }

        if (NoValidate != null)
        {
            register(el => el.NoValidate = NoValidate.Value);
        }

        if (Target != null)
        {
            register(el => el.Target = Target.Value);
        }

        if (Rel != null)
        {
            register(el => el.Rel = Rel.Value);
        }
    }

    protected internal override void RegisterServerEffects(Action<Action<SsrElementNode>> register)
    {
        base.RegisterServerEffects(register);

        if (Action != null)
        {
            register(el => el.SetAttribute("action", Action.Value));
        }

        if (Autocomplete != null)
        {
            register(el => el.SetAttribute("autocomplete", Autocomplete.Value));
        }

        if (Enctype != null)
        {
            register(el => el.SetAttribute("enctype", Enctype.Value));
        }

        if (Method != null)
        {
            register(el => el.SetAttribute("method", Method.Value));
        }

        if (Name != null)
        {
            register(el => el.SetAttribute("name", Name.Value));
        }

        if (NoValidate != null)
        {
            register(el => SsrAttributes.SetBoolean(el, "novalidate", NoValidate.Value));
        }

        if (Target != null)
        {
            register(el => el.SetAttribute("target", Target.Value));
        }

        if (Rel != null)
        {
            register(el => el.SetAttribute("rel", Rel.Value));
        }
    }
}

public class FormEvents : HtmlElementComponentEvents<HTMLFormElement>
{
}

public class Form() : BaseNonVoidDomComponent<HTMLFormElement, FormProps, FormEvents>("form")
{
}
