using System.Runtime.Versioning;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class SelectProps : GlobalHtmlComponentProps<HTMLSelectElement>
{
    public IReadOnlySignal<string>? Autocomplete { get; init; }
    public IReadOnlySignal<bool>? Disabled { get; init; }
    public IReadOnlySignal<bool>? Multiple { get; init; }
    public IReadOnlySignal<string>? Name { get; init; }
    public IReadOnlySignal<bool>? Required { get; init; }
    public IReadOnlySignal<uint>? Size { get; init; }
    public IReadOnlySignal<string>? Value { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLSelectElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Autocomplete != null)
        {
            register(el => el.Autocomplete = Autocomplete.Value);
        }

        if (Disabled != null)
        {
            register(el => el.Disabled = Disabled.Value);
        }

        if (Multiple != null)
        {
            register(el => el.Multiple = Multiple.Value);
        }

        if (Name != null)
        {
            register(el => el.Name = Name.Value);
        }

        if (Required != null)
        {
            register(el => el.Required = Required.Value);
        }

        if (Size != null)
        {
            register(el => el.Size = Size.Value);
        }

        if (Value != null)
        {
            register(el => el.Value = Value.Value);
        }
    }
}

public class SelectEvents : HtmlElementComponentEvents<HTMLSelectElement>
{
}

public class Select() : BaseNonVoidDomComponent<HTMLSelectElement, SelectProps, SelectEvents>("select")
{
}
