namespace Iskra.Signals;

public static class SignalExtensions
{
    public static Signal<T> ToSignal<T>(this T value) => new(value);

    public static ConstSignal<T> ToConstSignal<T>(this T value) => new(value);
}
