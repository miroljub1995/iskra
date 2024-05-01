using System.Runtime.CompilerServices;
using Iskra.Reactivity.Effects;

namespace Iskra.Reactivity;

public static class DepsTracking
{
    private static readonly ConditionalWeakTable<object, Dictionary<string, List<IEffect>>> DepsMap = new();

    public static void Track(object obj, string prop)
    {
        if (Effect.Active is not { } activeEffect)
        {
            return;
        }

        Dictionary<string, List<IEffect>> valByObj =
            DepsMap.GetValue(obj, (_) => new Dictionary<string, List<IEffect>>());

        if (!valByObj.TryGetValue(prop, out var effects))
        {
            effects = [];
            valByObj[prop] = effects;
        }

        if (!effects.Contains(activeEffect))
        {
            effects.Add(activeEffect);
        }
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
            if (DepsMap.TryGetValue(obj, out var valByObj))
            {
                valByObj[prop].Remove(effect);
            }
        }
    }
}