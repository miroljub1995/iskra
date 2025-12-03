using System.Runtime.Versioning;
using Iskra.StdWeb;
using Exception = System.Exception;

namespace Iskra.Core.RenderRoot;

[SupportedOSPlatform("browser")]
public class DomRenderSlot : IDomRenderSlot
{
    private readonly Node _parent;
    private readonly LinkedListNode<DomRenderSlot> _listNode;
    private Node? _node;

    public DomRenderSlot(LinkedList<DomRenderSlot> list, Node parent)
    {
        _parent = parent;
        _listNode = list.AddLast(this);
    }

    private DomRenderSlot(LinkedListNode<DomRenderSlot> listNode, Node parent)
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

        var linkedListNode = _listNode.List.AddAfter(_listNode, new DomRenderSlot(_listNode.List, _parent));
        return new DomRenderSlot(linkedListNode, _parent);
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

    private Node? TryFindNextNode()
    {
        var current = _listNode.Next;
        while (current is not null && current.Value._node is null)
        {
            current = current.Next;
        }

        return current?.Value._node;
    }
}