using System.Runtime.Versioning;
using Iskra.Core.Components;
using Iskra.Dom.Components;
using Iskra.StdWeb;
using Exception = System.Exception;

namespace Iskra.Core.RenderRoot;

[SupportedOSPlatform("browser")]
public class DomRenderSlot : IDomRenderSlot
{
    private DomRenderRoot _root;
    internal readonly LinkedListNode<DomRenderSlot?> _listNode;
    private Node? _node;

    internal DomRenderSlot(LinkedListNode<DomRenderSlot?> listNode, DomRenderRoot root)
    {
        _root = root;
        _listNode = listNode;
    }

    public void Dispose()
    {
        _listNode.List?.Remove(_listNode);
    }

    public IDomRenderSlot CreateSlotAfter()
    {
        return _root.CreateSlotAfter(_listNode);
    }

    IRenderSlot IRenderSlot.CreateSlotAfter() => (IRenderSlot)CreateSlotAfter();

    public IDomRenderRoot CreateChildRoot(Element parent)
    {
        return new DomRenderRoot(parent);
    }

    public bool AreLifecycleHooksEnabled => true;

    public DomRenderRoot Root => _root;

    public (IComponent? Open, IComponent? Close) CreateComponentBounds()
        => (new DomComment { Data = new Iskra.Signals.Signal<string>("[") }, new DomComment { Data = new Iskra.Signals.Signal<string>("]") });

    public (IComponent? Open, IComponent? Close) CreateForEachBounds()
        => (new DomComment { Data = new Iskra.Signals.Signal<string>("[") }, new DomComment { Data = new Iskra.Signals.Signal<string>("]") });

    public bool IsHydrating => _root.IsHydrating;

    public Node? TryHydrateSlot()
    {
        var node = _root.TryDequeueHydrationNode();
        if (node is not null)
        {
            _node = node;
        }
        return node;
    }

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

    public void MoveRangeAfter(IDomRenderSlot rangeEnd, IDomRenderSlot anchor)
    {
        var endSlot = (DomRenderSlot)rangeEnd;
        var anchorSlot = (DomRenderSlot)anchor;

        var sourceList = _listNode.List ?? throw new Exception("Slot must be attached.");

        if (endSlot._listNode.List != sourceList)
        {
            throw new Exception("rangeStart and rangeEnd must belong to the same slot list.");
        }

        var targetList = anchorSlot._listNode.List ?? throw new Exception("Anchor slot must be attached.");

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

        // Relink: remove each node from the source list and re-insert in order
        // after the anchor in the target list (may be the same list or different).
        var insertAfter = anchorSlot._listNode;
        foreach (var node in rangeNodes)
        {
            sourceList.Remove(node);
            targetList.AddAfter(insertAfter, node);
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

        // Update _root on each moved slot so that ClaimOrCreateSlotAfter,
        // Populate, and Empty use the correct list and DOM parent.
        foreach (var node in rangeNodes)
        {
            if (node.Value is not null)
            {
                node.Value._root = anchorSlot._root;
            }
        }

        // Reinsert DOM nodes under the anchor's root in forward order.
        foreach (var node in rangeNodes)
        {
            if (node.Value?._node is { } domNode)
            {
                anchorSlot._root.Node.InsertBefore(domNode, nextNode);
            }
        }
    }

    void IRenderSlot.MoveRangeAfter(IRenderSlot rangeEnd, IRenderSlot anchor)
        => MoveRangeAfter((IDomRenderSlot)rangeEnd, (IDomRenderSlot)anchor);

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
