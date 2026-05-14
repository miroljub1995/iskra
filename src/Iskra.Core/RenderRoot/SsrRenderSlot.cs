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
