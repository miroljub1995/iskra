using Iskra.Core.Instances;

namespace Iskra.Core;

public interface IComponent<out TComponent, in TPropsInit, out TExpose>
{
    static abstract TComponent CreateComponent(TPropsInit props);
    public TExpose Expose { get; }
    public Func<BaseInstance[]> Render { get; }
}