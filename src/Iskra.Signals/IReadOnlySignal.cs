namespace Iskra.Signals;

public interface IReadOnlySignal<out T>
{
    T Value { get; }
}