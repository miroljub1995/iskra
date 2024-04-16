namespace IskraSample;

public static class WatchEffectHelper
{
    public static void WatchEffect(Action effectCallback)
    {
        if (EffectsScope.Active is not { } activeScope)
        {
            throw new("Can not call effect outside of scope.");
        }

        Effect effect = new(activeScope, effectCallback);
        activeScope.AttachEffect(effect);

        effect.Trigger();
    }
}