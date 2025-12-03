using Iskra.Core;
using Iskra.Core.Instances;
using Iskra.Signals;
using Iskra.StdWeb;

namespace Iskra.CoreExample.Components;

public class SimpleComponent : IComponent<SimpleComponent, SimpleComponent.SimpleComponentPropsInit,
    SimpleComponent.SimpleComponentExpose>
{
    public class SimpleComponentPropsInit
    {
        public required Func<string> Name { get; init; }
        public Func<string?> Surname { get; init; } = static () => null;
    }

    private class SimpleComponentProps(SimpleComponentPropsInit props)
    {
        private readonly Computed<string> _name = new(props.Name);
        public string Name => _name.Value;

        private readonly Computed<string?> _surname = new(props.Surname);
        public string? Surname => _surname.Value;
    }

    public record SimpleComponentExpose();

    public static SimpleComponent CreateComponent(SimpleComponentPropsInit props)
    {
        var propsForComponent = new SimpleComponentProps(props);

        var render = Setup(propsForComponent);

        return new SimpleComponent()
        {
            Expose = new SimpleComponentExpose(),
            Render = render,
        };
    }

    private static Func<BaseInstance[]> Setup(SimpleComponentProps props)
    {
        var middleName = new Signal<string>("");
        var fullname =
            new Computed<string>(() => props.Name + $" ({middleName.Value}) " + (props.Surname ?? "Unknown"));

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
                ChildComponent.ChildComponentExpose>(new ChildComponent.ChildComponentPropsInit
            {
                Fullname = () => fullname.Value,
            });

            var divInstance = new ElementInstance<HTMLDivElement>("div");
            new Effect(_ => { divInstance.Element.InnerText = fullname.Value; });
            divInstance.Element.AddEventListener("click", new EventListener(onClick));

            return [t, inputInstance, c, divInstance];
        };
    }

    public required SimpleComponentExpose Expose { get; init; }
    public required Func<BaseInstance[]> Render { get; init; }
}