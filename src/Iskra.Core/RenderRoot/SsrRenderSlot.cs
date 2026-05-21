using Exception = System.Exception;

namespace Iskra.Core.RenderRoot;

public sealed class SsrRenderSlot : ISsrRenderSlot
{
    private readonly SsrRenderRoot _root;
    internal readonly LinkedListNode<SsrRenderSlot?> _listNode;
    private ISsrNode? _node;

    internal SsrRenderSlot(LinkedListNode<SsrRenderSlot?> listNode, SsrRenderRoot root)
    {
        _root = root;
        _listNode = listNode;
    }

    internal ISsrNode? Node => _node;

    public void Dispose()
    {
        _listNode.List?.Remove(_listNode);
    }

    public IRenderSlot CreateSlotAfter()
    {
        return _root.ClaimOrCreateSlotAfter(_listNode);
    }

    public void Populate(ISsrNode node)
    {
        _node = node;
    }

    public void Empty()
    {
        _node = null;
    }

    public void MoveRangeAfter(IRenderSlot rangeEnd, IRenderSlot anchor)
    {
        var endSlot = (SsrRenderSlot)rangeEnd;
        var anchorSlot = (SsrRenderSlot)anchor;

        var sourceList = _listNode.List ?? throw new Exception("Slot must be attached.");

        if (endSlot._listNode.List != sourceList)
        {
            throw new Exception("rangeStart and rangeEnd must belong to the same slot list.");
        }

        var targetList = anchorSlot._listNode.List ?? throw new Exception("Anchor slot must be attached.");

        // Collect linked-list nodes in the range [this .. endSlot].
        var rangeNodes = new List<LinkedListNode<SsrRenderSlot?>>();
        var cursor = _listNode;
        while (true)
        {
            rangeNodes.Add(cursor);
            if (cursor == endSlot._listNode)
            {
                break;
            }

            cursor = cursor.Next ?? throw new Exception("rangeEnd not found after rangeStart in slot list.");
        }

        // Relink: remove each node from the source list and re-insert in order
        // after the anchor in the target list (may be the same list or different).
        var insertAfter = anchorSlot._listNode;
        foreach (var node in rangeNodes)
        {
            sourceList.Remove(node);
            targetList.AddAfter(insertAfter, node);
            insertAfter = node;
        }
    }
}
