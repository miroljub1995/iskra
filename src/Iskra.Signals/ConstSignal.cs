namespace Iskra.Signals;

public class ConstSignal<T>(T value) : IReadOnlySignal<T>
{
    public T Value => value;
}
