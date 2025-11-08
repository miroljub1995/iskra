namespace Iskra.Reactivity;

public interface IComputedRef<out T>
{
    T Value { get; }
}