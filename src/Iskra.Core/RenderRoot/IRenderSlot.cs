using Iskra.Core.Components;

namespace Iskra.Core.RenderRoot;

public interface IRenderSlot : IDisposable
{
    IRenderSlot CreateSlotAfter();

    bool AreLifecycleHooksEnabled { get; }

    /// <summary>
    /// Moves the contiguous range of slots [this .. <paramref name="rangeEnd"/>] (inclusive)
    /// to immediately after <paramref name="anchor"/> in slot-list order, preserving the
    /// internal ordering of the range.
    /// </summary>
    void MoveRangeAfter(IRenderSlot rangeEnd, IRenderSlot anchor);

    /// <summary>
    /// Creates open and close boundary markers for a component scope.
    /// Either element may be <c>null</c> if the slot implementation does not require boundaries.
    /// </summary>
    (IComponent? Open, IComponent? Close) CreateComponentBounds();

    /// <summary>
    /// Creates open and close boundary markers for a ForEach scope.
    /// Either element may be <c>null</c> if the slot implementation does not require boundaries.
    /// </summary>
    (IComponent? Open, IComponent? Close) CreateForEachBounds();
}