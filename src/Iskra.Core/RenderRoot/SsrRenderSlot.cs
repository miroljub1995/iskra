using Exception = System.Exception;

namespace Iskra.Core.RenderRoot;

public sealed class SsrRenderSlot : ISsrRenderSlot
{
    private readonly LinkedListNode<SsrRenderSlot?> _listNode;
    private ISsrNode? _node;

    public SsrRenderSlot(LinkedList<SsrRenderSlot?> list)
    {
        _listNode = list.AddLast(this);
    }

    private SsrRenderSlot(LinkedListNode<SsrRenderSlot?> listNode)
    {
        _listNode = listNode;
    }

    internal ISsrNode? Node => _node;

    public void Dispose()
    {
        _listNode.List?.Remove(_listNode);
    }

    public IRenderSlot CreateSlotAfter()
    {
        if (_listNode.List is null)
        {
            throw new Exception("Slot must be attached.");
        }

        var linkedListNode = _listNode.List.AddAfter(_listNode, (SsrRenderSlot?)null);
        var slot = new SsrRenderSlot(linkedListNode);
        linkedListNode.Value = slot;
        return slot;
    }

    public void Populate(ISsrNode node)
    {
        _node = node;
    }

    public void Empty()
    {
        _node = null;
    }

    public void MoveAfter(IRenderSlot anchor)
    {
        var anchorSlot = (SsrRenderSlot)anchor;

        var list = _listNode.List ?? throw new Exception("Slot must be attached.");

        if (anchorSlot._listNode.List != list)
            throw new Exception("Slots must belong to the same slot list.");

        list.Remove(_listNode);
        list.AddAfter(anchorSlot._listNode, _listNode);
    }
}
