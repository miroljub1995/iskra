namespace Iskra.Signals;

public interface ISignal<T> : IReadOnlySignal<T>
{
    new T Value { get; set; }
}