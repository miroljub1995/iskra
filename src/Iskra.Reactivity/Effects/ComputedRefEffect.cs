using System.Diagnostics.CodeAnalysis;

namespace Iskra.Reactivity.Effects;

internal class ComputedRefEffect<T>(Func<T> func) : IEffect, IComputedRef<T>
{
    public void Dispose()
    {
        DepsTracking.RemoveEffect(this);
    }

    public void Trigger()
    {
        IsCached = false;
        DepsTracking.Trigger(this, nameof(Value));
    }

    private T ComputeValue()
    {
        IEffect? oldActive = Effect.Active;
        Effect.Active = this;
        try
        {
            DepsTracking.RemoveEffect(this);
            _cachedValue = func();
            IsCached = true;
            return _cachedValue;
        }
        finally
        {
            Effect.Active = oldActive;
        }
    }

    [MemberNotNullWhen(true, nameof(_cachedValue))]
    private bool IsCached { get; set; }

    private T? _cachedValue = default;

    public T Value
    {
        get
        {
            DepsTracking.Track(this, nameof(Value));
            return IsCached ? _cachedValue : ComputeValue();
        }
    }
}