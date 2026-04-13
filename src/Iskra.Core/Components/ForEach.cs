using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.Components;

public class ForEach<TElement, TKey> : IComponent where TKey : notnull
{
    public required IReadOnlySignal<IList<TElement>> Items { get; init; }
    public required Func<TElement, TKey> Key { get; init; }
    public required Func<TElement, IComponent[]> ElementSetup { get; init; }
    public IEqualityComparer<TKey> Comparer { get; init; } = EqualityComparer<TKey>.Default;

    private readonly EffectScope _effectScope = new();

    public void Mount(IRenderSlot slot)
    {
        _effectScope.Run(() =>
        {
            var orderedItems = new List<(TKey Key, EffectScope Scope, IRenderSlot LastSlot)>();

            // Reactive Effect: re-runs whenever Items signal changes.
            // Performs keyed diffing: same key at same index → reuse; moved/new key → unmount old + remount fresh.
            new Effect(_ =>
            {
                var newItems = Items.Value;

                // Throw on duplicate keys
                var seenKeys = new HashSet<TKey>(Comparer);
                foreach (var element in newItems)
                {
                    var key = Key(element);
                    if (!seenKeys.Add(key))
                    {
                        throw new InvalidOperationException(
                            $"Duplicate key detected in ForEach: {key}");
                    }
                }

                // Build lookup of previous render's items by key
                var oldByKey = new Dictionary<TKey, EffectScope>(Comparer);
                for (int i = 0; i < orderedItems.Count; i++)
                {
                    oldByKey[orderedItems[i].Key] = orderedItems[i].Scope;
                }

                var newList = new List<(TKey Key, EffectScope Scope, IRenderSlot LastSlot)>(newItems.Count);
                var handledKeys = new HashSet<TKey>(Comparer);
                var prevSlot = slot;

                for (int i = 0; i < newItems.Count; i++)
                {
                    var element = newItems[i];
                    var key = Key(element);

                    if (i < orderedItems.Count
                        && Comparer.Equals(orderedItems[i].Key, key))
                    {
                        // Same key at same position — reuse existing scope, slots, and components
                        var existing = orderedItems[i];
                        newList.Add(existing);
                        prevSlot = existing.LastSlot;

                        handledKeys.Add(key);
                    }
                    else
                    {
                        // Key moved to a different position or is brand new
                        if (oldByKey.TryGetValue(key, out var oldScope))
                        {
                            oldScope.Dispose();
                        }

                        handledKeys.Add(key);

                        // Mount fresh at the new position with its own scope
                        var itemScope = new EffectScope();
                        itemScope.Run(() =>
                        {
                            var children = ElementSetup(element);
                            for (int j = 0; j < children.Length; j++)
                            {
                                var compSlot = prevSlot.CreateSlotAfter();
                                children[j].Mount(compSlot);
                                prevSlot = compSlot;
                                var child = children[j];
                                new Effect(onCleanup => onCleanup(() =>
                                {
                                    child.Unmount();
                                    compSlot.Dispose();
                                }));
                            }
                        });

                        newList.Add((key, itemScope, prevSlot));
                    }
                }

                // Unmount items whose key disappeared from the new list
                foreach (var (oldKey, oldScope, _) in orderedItems)
                {
                    if (!handledKeys.Contains(oldKey))
                    {
                        oldScope.Dispose();
                    }
                }

                orderedItems.Clear();
                orderedItems.AddRange(newList);
            });

            // Cleanup Effect: no signals tracked — only registers teardown for when this component is unmounted.
            new Effect(onCleanup => onCleanup(() =>
            {
                foreach (var (_, itemScope, _) in orderedItems)
                {
                    itemScope.Dispose();
                }

                orderedItems.Clear();
            }));
        });
    }

    public void Unmount()
    {
        _effectScope.Dispose();
    }
}
