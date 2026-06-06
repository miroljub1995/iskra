using Iskra.Core.Features;
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
    private sealed record ItemState(TKey Key, Signal<TElement> Element, EffectScope Scope, IRenderSlot StartSlot, IRenderSlot EndSlot);

    public void Mount(IRenderSlot slot)
    {
        // Capture parent features at mount time. The reactive effect below can
        // re-run later (e.g. async data, click handlers) when AppFeatures.Current
        // is null; we must re-establish the parent features before mounting any
        // newly created child so each item layers on the correct parent.
        var parentFeatures = AppFeatures.Current
            ?? throw new InvalidOperationException(
                "AppFeatures.Current must be set before mounting ForEach.");

        _effectScope.Run(() =>
        {
            var orderedItems = new List<ItemState>();

            var (openBound, closeBound) = slot.CreateForEachBounds();

            // closeSlot is permanently the last slot — items are inserted before it.
            // Pre-allocating it here (before any items) ensures ClaimOrCreateSlotAfter
            // inserts new item slots between the open comment and this anchor.
            var closeSlot = slot.CreateSlotAfter();

            openBound?.Mount(slot);
            closeBound?.Mount(closeSlot);

            new Effect(onCleanup => onCleanup(() =>
            {
                openBound?.Unmount();
                closeBound?.Unmount();
                closeSlot.Dispose();
            }));

            // Reactive Effect: re-runs whenever Items signal changes.
            // Performs keyed diffing:
            //   same key at same index  → reuse in place
            //   same key at new index   → move existing DOM nodes to new position (no remount)
            //   brand new key           → mount fresh
            //   disappeared key         → dispose
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
                var oldByKey = new Dictionary<TKey, ItemState>(Comparer);
                for (int i = 0; i < orderedItems.Count; i++)
                {
                    oldByKey[orderedItems[i].Key] = orderedItems[i];
                }

                var newList = new List<ItemState>(newItems.Count);
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
                        prevSlot = existing.EndSlot;
                        oldByKey.Remove(key);
                    }
                    else if (oldByKey.TryGetValue(key, out var existingItem))
                    {
                        // Key exists at a different position — move its entire slot range after the running anchor.
                        existingItem.StartSlot.MoveRangeAfter(existingItem.EndSlot, prevSlot);
                        // Update the element signal so that any reactive consumers re-render.
                        existingItem.Element.Value = element;
                        oldByKey.Remove(key);
                        newList.Add(existingItem);
                        prevSlot = existingItem.EndSlot;
                    }
                    else
                    {
                        // Brand new key — mount fresh.

                        var itemScope = new EffectScope();
                        var elementSignal = new Signal<TElement>(element);
                        // Pre-allocate the end anchor before mounting so that ComposedComponent's
                        // internally created slots are inserted between startSlot and endSlot.
                        var startSlot = prevSlot.CreateSlotAfter();
                        var endSlot = startSlot.CreateSlotAfter();
                        itemScope.Run(() =>
                        {
                            // Re-establish parent features ambient before mounting children.
                            // This effect can re-run after async/click events when
                            // AppFeatures.Current is null. Each newly mounted item must
                            // layer on the original parent — not on a sibling's layer or null.
                            var prevFeatures = AppFeatures.Current;
                            AppFeatures.Current = parentFeatures;
                            try
                            {
                                var children = ElementSetup(elementSignal);
                                var composed = new ComposedComponent(children);
                                composed.Mount(startSlot);
                                new Effect(onCleanup => onCleanup(() =>
                                {
                                    composed.Unmount();
                                    startSlot.Dispose();
                                    endSlot.Dispose();
                                }));
                            }
                            finally
                            {
                                AppFeatures.Current = prevFeatures;
                            }
                        });

                        prevSlot = endSlot;
                        newList.Add(new ItemState(key, elementSignal, itemScope, startSlot, endSlot));
                    }
                }

                // Dispose items whose key disappeared from the new list
                foreach (var item in oldByKey.Values)
                {
                    item.Scope.Dispose();
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
