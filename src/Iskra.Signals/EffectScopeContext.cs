namespace Iskra.Signals;

public static class EffectScopeContext
{
    private static readonly ThreadLocal<IEffectScope?> ValueLocal = new();

    public static IEffectScope? Active
    {
        get => ValueLocal.Value;
        set => ValueLocal.Value = value;
    }
}