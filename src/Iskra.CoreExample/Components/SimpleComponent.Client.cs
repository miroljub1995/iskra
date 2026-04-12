using System.Runtime.Versioning;
using Iskra.Core;
using Iskra.Core.Instances;
using Iskra.Core.Sfc;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.CoreExample.Components;

public partial class SimpleComponent : ISfcClientComponent<
    SimpleComponent,
    SimpleComponent.SimpleComponentPropsInit,
    SimpleComponent.SimpleComponentProps,
    SimpleComponent.SimpleComponentExpose,
    SimpleComponent.SimpleComponentFallthrough
>
{
    public class SimpleComponentFallthrough
    {
        // No fallthrough elements for SimpleComponent
    }

    public class SimpleComponentPropsInit
    {
        public required Func<string> Name { get; init; }
        public Func<string?> Surname { get; init; } = static () => null;
    }

    public class SimpleComponentProps(SimpleComponentPropsInit props)
        : ISetupProps<SimpleComponentPropsInit, SimpleComponentProps>
    {
        private readonly Computed<string> _name = new(props.Name);
        public string Name => _name.Value;

        private readonly Computed<string?> _surname = new(props.Surname);
        public string? Surname => _surname.Value;

        public static SimpleComponentProps Init(SimpleComponentPropsInit initProps) => new(initProps);
    }

    public record SimpleComponentExpose();

    [SupportedOSPlatform("browser")]
    public static Func<BaseInstance[]> SetupClient(SimpleComponentProps props, SimpleComponentFallthrough fallthrough,
        out SimpleComponentExpose expose)
    {
        var middleName = new Signal<string>("");
        var fullname =
            new Computed<string>(() => props.Name + $" ({middleName.Value}) " + (props.Surname ?? "Unknown"));
        expose = new SimpleComponentExpose();

        EventListenerCallbackManaged onClick = ev =>
        {
            Console.WriteLine(ev.Target is HTMLElement target ? target.InnerText : "null");
        };

        EventListenerCallbackManaged onInput = ev =>
        {
            if (ev.Target is HTMLInputElement input)
            {
                (input.Value, middleName.Value) = (middleName.Value, input.Value);
            }
        };

        return () =>
        {
            var t = new TextInstance("Please enter the middle name:");

            var inputInstance = new ElementInstance<HTMLInputElement>("input");
            new Effect(_ => { inputInstance.Element.Value = middleName.Value; });
            inputInstance.Element.AddEventListener("input", new EventListener(onInput));

            var c = new ComponentInstance<ChildComponent, ChildComponent.ChildComponentPropsInit,
                ChildComponent.ChildComponentExpose, ChildComponent.ChildComponentFallthrough>(
                new ChildComponent.ChildComponentPropsInit
                {
                    Fullname = () => fullname.Value,
                },
                new ChildComponent.ChildComponentFallthrough
                {
                    Default = new()
                    {
                        ElementEffect = (el, onCleanup) =>
                        {
                            el.ClassName += " custom-from-parent";
                            var listener = new EventListener(onClick);
                            el.AddEventListener("click", listener);
                            onCleanup(() => el.RemoveEventListener("click", listener));
                        }
                    }
                });

            var divInstance = new ElementInstance<HTMLDivElement>("div");
            new Effect(_ => { divInstance.Element.InnerText = fullname.Value; });
            divInstance.Element.AddEventListener("click", new EventListener(onClick));

            return [t, inputInstance, c, divInstance];
        };
    }

    public static ClientComponent<SimpleComponentExpose>
        SetupClientComponent(SimpleComponentPropsInit props, SimpleComponentFallthrough fallthrough) =>
        SfcClientComponentFactory
            .SetupClientComponent<
                SimpleComponent,
                SimpleComponentPropsInit,
                SimpleComponentProps,
                SimpleComponentExpose,
                SimpleComponentFallthrough
            >(props, fallthrough);
}