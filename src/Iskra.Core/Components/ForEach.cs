using Iskra.Core.RenderRoot;
using Iskra.Signals;

namespace Iskra.Core.Components;

public class ForEach<TElement, TKey> : IComponent where TKey : notnull
{
    public required IReadOnlySignal<IList<TElement>> Items { get; init; }
    public required Func<TElement, TKey> Key { get; init; }
    public required Func<IReadOnlySignal<TElement>, IComponent[]> ElementSetup { get; init; }
    public IEqualityComparer<TKey> Comparer { get; init; } = EqualityComparer<TKey>.Default;

    private readonly EffectScope _effectScope = new();

    // Tracks mounted state per keyed item across reactive re-runs.
    // Element is held in a Signal so that when the same key is paired with a new
    // element value, the existing components are preserved and only the signal
    // is updated reactively (no remount, no ElementSetup re-invocation).
    private sealed record ItemState(TKey Key, Signal<TElement> Element, EffectScope Scope, IReadOnlyList<IRenderSlot> Slots);

    public void Mount(IRenderSlot slot)
    {
        _effectScope.Run(() =>
        {
            var orderedItems = new List<ItemState>();

            // Reactive Effect: re-runs whenever Items signal changes.
            // Performs keyed diffing:
            //   same key at same index  → reuse in place
            //   same key at new index   → move existing DOM nodes to new position (no remount)
            //   brand new key           → mount fresh
            //   disappeared key         → dispose
            new Effect(_ =>
            {
                if (!OperatingSystem.IsBrowser()) return;

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
                var oldByKey = new Dictionary<TKey, ItemState>(Comparer);
                for (int i = 0; i < orderedItems.Count; i++)
                {
                    oldByKey[orderedItems[i].Key] = orderedItems[i];
                }

                var newList = new List<ItemState>(newItems.Count);
                var handledKeys = new HashSet<TKey>(Comparer);
                var prevSlot = slot;

                for (int i = 0; i < newItems.Count; i++)
                {
                    var element = newItems[i];
                    var key = Key(element);

                    if (i < orderedItems.Count
                        && Comparer.Equals(orderedItems[i].Key, key))
                    {
                        // Same key at same position — reuse existing scope, slots, and components.
                        // Update the element signal so that any reactive consumers re-render.
                        var existing = orderedItems[i];
                        existing.Element.Value = element;
                        newList.Add(existing);
                        prevSlot = existing.Slots[^1];
                        handledKeys.Add(key);
                    }
                    else if (oldByKey.TryGetValue(key, out var existingItem)
                        && existingItem.Slots.Count > 0)
                    {
                        // Key exists at a different position — move each slot individually after the running anchor.
                        var anchor = prevSlot;
                        foreach (var s in existingItem.Slots)
                        {
                            s.MoveAfter(anchor);
                            anchor = s;
                        }
                        // Update the element signal so that any reactive consumers re-render.
                        existingItem.Element.Value = element;
                        handledKeys.Add(key);
                        newList.Add(existingItem);
                        prevSlot = existingItem.Slots[^1];
                    }
                    else
                    {
                        // Brand new key, or moved key in a non-DOM context (fallback: dispose + remount)
                        if (oldByKey.TryGetValue(key, out var staleItem))
                        {
                            staleItem.Scope.Dispose();
                        }

                        handledKeys.Add(key);

                        var itemSlots = new List<IRenderSlot>();
                        var itemScope = new EffectScope();
                        var elementSignal = new Signal<TElement>(element);
                        itemScope.Run(() =>
                        {
                            var children = ElementSetup(elementSignal);
                            for (int j = 0; j < children.Length; j++)
                            {
                                var compSlot = prevSlot.CreateSlotAfter();
                                itemSlots.Add(compSlot);
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

                        newList.Add(new ItemState(key, elementSignal, itemScope, itemSlots));
                    }
                }

                // Dispose items whose key disappeared from the new list
                foreach (var item in orderedItems)
                {
                    if (!handledKeys.Contains(item.Key))
                    {
                        item.Scope.Dispose();
                    }
                }

                orderedItems.Clear();
                orderedItems.AddRange(newList);
            });

            // Cleanup Effect: no signals tracked — only registers teardown for when this component is unmounted.
            new Effect(onCleanup => onCleanup(() =>
            {
                foreach (var item in orderedItems)
                {
                    item.Scope.Dispose();
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
