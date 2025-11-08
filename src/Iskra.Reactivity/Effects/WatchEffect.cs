namespace Iskra.Reactivity.Effects;

public class WatchEffect : IEffect
{
    private readonly Action _callback;
    private readonly EffectsScope _scope;

    internal WatchEffect(Action callback)
    {
        if (EffectsScope.Active is null)
        {
            throw new("Can not run effect outside of scope.");
        }

        _callback = callback;
        _scope = EffectsScope.Active;
        _scope.AttachEffect(this);

        Trigger();
    }

    public void Dispose()
    {
        DepsTracking.RemoveEffect(this);
        _scope.DetachEffect(this);
    }

    public void Trigger()
    {
        IEffect? oldActive = Effect.Active;
        Effect.Active = this;
        try
        {
            DepsTracking.RemoveEffect(this);
            _callback();
        }
        finally
        {
            Effect.Active = oldActive;
        }
    }
}