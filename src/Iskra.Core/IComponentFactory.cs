namespace Iskra.Core;

public interface IComponentFactory<out TComponent, in TPropsInit>
{
    TComponent CreateComponent(TPropsInit props);
}