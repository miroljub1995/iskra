namespace IskraSample;

public class EffectsScope : IDisposable
{
    public static EffectsScope? Active;

    private readonly List<Effect> _effects = [];

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
        foreach (Effect effect in _effects)
        {
            effect.Dispose();
        }
    }

    public void AttachEffect(Effect effect)
    {
        _effects.Add(effect);
    }
}