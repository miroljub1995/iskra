using Iskra.Reactivity.Effects;

namespace Iskra.Reactivity;

public class EffectsScope : IDisposable
{
    public static EffectsScope? Active;

    private readonly List<IEffect> _effects = [];

    public void Run(Action action)
    {
        EffectsScope? oldActive = Active;
        Active = this;
        try
        {
            action();
        }
        finally
        {
            Active = oldActive;
        }
    }

    public void Dispose()
    {
        foreach (IEffect effect in _effects.ToList())
        {
            effect.Dispose();
        }
    }

    public void AttachEffect(IEffect effect)
    {
        _effects.Add(effect);
    }

    public void DetachEffect(IEffect effect)
    {
        _effects.Remove(effect);
    }
}