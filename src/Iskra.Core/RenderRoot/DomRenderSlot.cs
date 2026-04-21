using System.Runtime.Versioning;
using Iskra.StdWeb;
using Exception = System.Exception;

namespace Iskra.Core.RenderRoot;

[SupportedOSPlatform("browser")]
public class DomRenderSlot : IDomRenderSlot
{
    private readonly Node _parent;
    private readonly LinkedListNode<DomRenderSlot?> _listNode;
    private Node? _node;

    public DomRenderSlot(LinkedList<DomRenderSlot?> list, Node parent)
    {
        _parent = parent;
        _listNode = list.AddLast(this);
    }

    private DomRenderSlot(LinkedListNode<DomRenderSlot?> listNode, Node parent)
    {
        _parent = parent;
        _listNode = listNode;
    }

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

        var linkedListNode = _listNode.List.AddAfter(_listNode, (DomRenderSlot?)null);
        var slot = new DomRenderSlot(linkedListNode, _parent);
        linkedListNode.Value = slot;
        return slot;
    }

    public void Populate(Node node)
    {
        _node = node;
        var nextNode = TryFindNextNode();
        _parent.InsertBefore(node, nextNode);
    }

    public void Empty()
    {
        if (_node is not null)
        {
            _parent.RemoveChild(_node);
        }
    }

    public void MoveAfter(IRenderSlot anchor)
    {
        var anchorSlot = (DomRenderSlot)anchor;

        var list = _listNode.List ?? throw new Exception("Slot must be attached.");

        if (anchorSlot._listNode.List != list)
            throw new Exception("Slots must belong to the same slot list.");

        // Relink this slot's node immediately after the anchor.
        list.Remove(_listNode);
        list.AddAfter(anchorSlot._listNode, _listNode);

        // Reinsert the DOM node at the new logical position.
        // InsertBefore moves an already-attached node — no RemoveChild needed.
        if (_node is not null)
        {
            _parent.InsertBefore(_node, TryFindNextNode());
        }
    }

    private Node? TryFindNextNode()
    {
        var current = _listNode.Next;
        while (current is not null && current.Value?._node is null)
        {
            current = current.Next;
        }

        return current?.Value?._node;
    }
}