namespace Iskra.Core.RenderRoot;

public interface IRenderSlot : IDisposable
{
    IRenderSlot CreateSlotAfter();

    /// <summary>
    /// Moves the contiguous range of slots [this .. <paramref name="rangeEnd"/>] (inclusive)
    /// to immediately after <paramref name="anchor"/> in slot-list order, preserving the
    /// internal ordering of the range.
    /// </summary>
    void MoveRangeAfter(IRenderSlot rangeEnd, IRenderSlot anchor);
}