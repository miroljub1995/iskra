using System.Runtime.Versioning;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.Core.DomComponents;

public class ObjectProps : GlobalHtmlComponentProps<HTMLObjectElement>
{
    public new IReadOnlySignal<string>? Data { get; init; }
    public IReadOnlySignal<string>? Type { get; init; }
    public IReadOnlySignal<string>? Name { get; init; }
    public IReadOnlySignal<string>? Width { get; init; }
    public IReadOnlySignal<string>? Height { get; init; }

    [SupportedOSPlatform("browser")]
    protected internal override void RegisterClientEffects(Action<Action<HTMLObjectElement>> register)
    {
        base.RegisterClientEffects(register);

        if (Data != null)
        {
            register(el => el.Data = Data.Value);
        }

        if (Type != null)
        {
            register(el => el.Type = Type.Value);
        }

        if (Name != null)
        {
            register(el => el.Name = Name.Value);
        }

        if (Width != null)
        {
            register(el => el.Width = Width.Value);
        }

        if (Height != null)
        {
            register(el => el.Height = Height.Value);
        }
    }
}

public class ObjectEvents : HtmlElementComponentEvents<HTMLObjectElement>
{
}

public class Object() : BaseNonVoidDomComponent<HTMLObjectElement, ObjectProps, ObjectEvents>("object")
{
}
