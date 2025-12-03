using Iskra.Core;
using Iskra.Core.Instances;
using Iskra.Signals;

namespace Iskra.CoreExample.Components;

public class ChildComponent : IComponent<ChildComponent, ChildComponent.ChildComponentPropsInit,
    ChildComponent.ChildComponentExpose>
{
    public class ChildComponentPropsInit
    {
        public required Func<string> Fullname { get; init; }
    }

    private class ChildComponentProps(ChildComponentPropsInit props)
    {
        private readonly Computed<string> _fullname = new(props.Fullname);
        public string Fullname => _fullname.Value;
    }

    public record ChildComponentExpose();

    public static ChildComponent CreateComponent(ChildComponentPropsInit props)
    {
        var propsForComponent = new ChildComponentProps(props);

        var render = Setup(propsForComponent, out var expose);

        return new ChildComponent()
        {
            Expose = expose,
            Render = render,
        };
    }

    private static Func<BaseInstance[]> Setup(ChildComponentProps props, out ChildComponentExpose expose)
    {
        var textSignal = new Computed<string>(() => props.Fullname + " from child component");
        expose = new ChildComponentExpose();

        return () =>
        {
            var text = new TextInstance(textSignal.Value);
            new Effect(_ => { text.Node.Data = textSignal.Value; });

            return [text];
        };
    }

    public required ChildComponentExpose Expose { get; init; }
    public required Func<BaseInstance[]> Render { get; init; }
}