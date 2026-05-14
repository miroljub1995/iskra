using System.Runtime.Versioning;
using Iskra.StdWeb;
using Exception = System.Exception;

namespace Iskra.Core.RenderRoot;

[SupportedOSPlatform("browser")]
public class DomRenderSlot : IDomRenderSlot
{
    private readonly DomRenderRoot _root;
    internal readonly LinkedListNode<DomRenderSlot?> _listNode;
    private Node? _node;
    internal bool _claimed;

    internal DomRenderSlot(LinkedListNode<DomRenderSlot?> listNode, DomRenderRoot root,
        Node? existingNode = null)
    {
        _root = root;
        _node = existingNode;
        _listNode = listNode;
    }

    public void Dispose()
    {
        _listNode.List?.Remove(_listNode);
    }

    public IRenderSlot ClaimOrCreateSlotAfter()
    {
        return _root.ClaimOrCreateSlotAfter(_listNode);
    }

    public Node? GetNode() => _node;

    public void Populate(Node node)
    {
        if (_node is not null)
        {
            throw new Exception("Slot is already populated.");
        }

        _node = node;
        var nextNode = TryFindNextNode();
        _root.Node.InsertBefore(node, nextNode);
    }

    public void Empty()
    {
        if (_node is null)
        {
            throw new Exception("Slot is not populated.");
        }

        _root.Node.RemoveChild(_node);
        _node = null;
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
            _root.Node.InsertBefore(_node, TryFindNextNode());
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
