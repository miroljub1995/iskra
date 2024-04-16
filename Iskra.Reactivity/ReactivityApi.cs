using Iskra.Reactivity.Effects;

namespace Iskra.Reactivity;

public static class ReactivityApi
{
    public static Ref<int> ToRef(this int value) => new(value);

    public static IComputedRef<T> Computed<T>(Func<T> func)
    {
        return new ComputedRefEffect<T>(func);
    }

    public static void WatchEffect(Action effectCallback)
    {
        IEffect _ = new WatchEffect(effectCallback);
    }
}