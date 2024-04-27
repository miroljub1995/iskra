using Iskra.Reactivity.Effects;

namespace Iskra.Reactivity;

public static class DepsTracking
{
    // TODO: replace with ConditionalWeakTable
    private static readonly Dictionary<object, Dictionary<string, List<IEffect>>> DepsMap = new();

    public static void Track(object obj, string prop)
    {
        if (Effect.Active is not { } activeEffect)
        {
            return;
        }

        if (!DepsMap.TryGetValue(obj, out var valByObj))
        {
            valByObj = new();
            DepsMap[obj] = valByObj;
        }

        if (!valByObj.TryGetValue(prop, out var effects))
        {
            effects = [];
            valByObj[prop] = effects;
        }

        effects.Add(activeEffect);
    }

    public static void Trigger(object obj, string prop)
    {
        if (DepsMap.TryGetValue(obj, out var valByObj) && valByObj.TryGetValue(prop, out var effects))
        {
            foreach (IEffect effect in effects.ToList())
            {
                effect.Trigger();
            }
        }
    }

    public static void RemoveEffect(IEffect effect)
    {
        List<(object, string)> foundInKeys = [];
        foreach (KeyValuePair<object, Dictionary<string, List<IEffect>>> objectKeyValue in DepsMap)
        {
            foreach (KeyValuePair<string, List<IEffect>> propKeyValue in objectKeyValue.Value)
            {
                if (propKeyValue.Value.Contains(effect))
                {
                    foundInKeys.Add((objectKeyValue.Key, propKeyValue.Key));
                }
            }
        }

        foreach ((object obj, string prop) in foundInKeys)
        {
            DepsMap[obj][prop].Remove(effect);
        }
    }
}