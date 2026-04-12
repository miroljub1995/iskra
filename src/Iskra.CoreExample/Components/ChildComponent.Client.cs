using System.Runtime.Versioning;
using Iskra.Core;
using Iskra.Core.Fallthrough;
using Iskra.Core.Instances;
using Iskra.Core.Sfc;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.CoreExample.Components;

public partial class ChildComponent : ISfcClientComponent<
    ChildComponent,
    ChildComponent.ChildComponentPropsInit,
    ChildComponent.ChildComponentProps,
    ChildComponent.ChildComponentExpose,
    ChildComponent.ChildComponentFallthrough
>
{
    public record Props
    {
        public required IReadOnlySignal<string> Fullname { get; init; }
    }

    public partial class Emits
    {
        public partial void ObjectCreated(object obj);
        public partial void ObjectChanged(object obj);
    }

    public partial class Emits
    {
        // ObjectCreated
        public delegate void ObjectCreatedHandler(object obj);

        public ObjectCreatedHandler? OnObjectCreated { get; init; } = null;

        public partial void ObjectCreated(object obj)
        {
            OnObjectCreated?.Invoke(obj);
        }

        // ObjectChanged
        public delegate void ObjectChangedHandler(object obj);

        public ObjectChangedHandler? OnObjectChanged { get; init; } = null;

        public partial void ObjectChanged(object obj)
        {
            OnObjectChanged?.Invoke(obj);
        }
    }

    public class ChildComponentFallthrough
    {
        public ElementFallthrough<HTMLDivElement> Default { get; init; } = new();
    }

    public class ChildComponentPropsInit
    {
        public required Func<string> Fullname { get; init; }
    }

    public class ChildComponentProps(ChildComponentPropsInit props)
        : ISetupProps<ChildComponentPropsInit, ChildComponentProps>
    {
        private readonly Computed<string> _fullname = new(props.Fullname);
        public string Fullname => _fullname.Value;

        public static ChildComponentProps Init(ChildComponentPropsInit initProps) => new(initProps);
    }

    public record ChildComponentExpose();

    [SupportedOSPlatform("browser")]
    public static Func<BaseInstance[]> SetupClient(ChildComponentProps props, ChildComponentFallthrough fallthrough,
        out ChildComponentExpose expose)
    {
        var textSignal = new Computed<string>(() => props.Fullname + " from child component");
        expose = new ChildComponentExpose();

        return () =>
        {
            var text = new TextInstance(textSignal.Value);
            new Effect(_ => { text.Node.Data = textSignal.Value; });

            var div = new ElementInstance<HTMLDivElement>("div", [text]);
            div.Element.ClassName = "flex col";

            new Effect(onCleanup => fallthrough.Default.ElementEffect(div.Element, onCleanup));

            return [div];
        };
    }

    public static ClientComponent<ChildComponentExpose>
        SetupClientComponent(ChildComponentPropsInit props, ChildComponentFallthrough fallthrough) =>
        SfcClientComponentFactory
            .SetupClientComponent<ChildComponent, ChildComponentPropsInit, ChildComponentProps, ChildComponentExpose,
                ChildComponentFallthrough>(props, fallthrough);
}