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

    public IRenderSlot ClaimOrCreateSlotAfter()
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

        var list = _listNode.List ?? throw new Exception("Slot must be attached.");

        if (anchorSlot._listNode.List != list)
        {
            throw new Exception("Slots must belong to the same slot list.");
        }

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

        // Relink: remove each node and re-insert in order after the anchor.
        var insertAfter = anchorSlot._listNode;
        foreach (var node in rangeNodes)
        {
            list.Remove(node);
            list.AddAfter(insertAfter, node);
            insertAfter = node;
        }
    }
}
