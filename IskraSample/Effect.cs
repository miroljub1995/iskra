namespace IskraSample;

public class Effect(
    EffectsScope scope,
    Action callback
) : IDisposable
{
    public static Effect? Active;

    public void Dispose()
    {
        RemoveDepsTracking();
    }

    public void Trigger()
    {
        Effect? oldActive = Active;
        Active = this;
        try
        {
            RemoveDepsTracking();
            callback();
        }
        finally
        {
            Active = oldActive;
        }
    }

    private void RemoveDepsTracking()
    {
        DepsTracking.RemoveEffect(this);
    }
}