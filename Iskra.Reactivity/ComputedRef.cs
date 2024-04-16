namespace Iskra.Reactivity;

public class ComputedRef<T>
{
    private readonly Func<T> _getter;

    internal ComputedRef(Func<T> getter)
    {
        _getter = getter;
    }

    public T Value => _getter();
}