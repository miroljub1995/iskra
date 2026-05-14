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

    public void MoveRangeAfter(IRenderSlot rangeEnd, IRenderSlot anchor)
    {
        var endSlot = (DomRenderSlot)rangeEnd;
        var anchorSlot = (DomRenderSlot)anchor;

        var list = _listNode.List ?? throw new Exception("Slot must be attached.");

        if (anchorSlot._listNode.List != list)
        {
            throw new Exception("Slots must belong to the same slot list.");
        }

        // Collect linked-list nodes in the range [this .. endSlot].
        var rangeNodes = new List<LinkedListNode<DomRenderSlot?>>();
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

        // Find the first DOM node that now follows endSlot (for InsertBefore).
        Node? nextNode = null;
        var afterEnd = endSlot._listNode.Next;
        while (afterEnd is not null)
        {
            if (afterEnd.Value?._node is { } n)
            {
                nextNode = n;
                break;
            }
            afterEnd = afterEnd.Next;
        }

        // Reinsert DOM nodes in forward order, each before nextNode.
        foreach (var node in rangeNodes)
        {
            if (node.Value?._node is { } domNode)
            {
                _root.Node.InsertBefore(domNode, nextNode);
            }
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
