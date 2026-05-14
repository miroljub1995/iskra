using System.Runtime.Versioning;
using Iskra.StdWeb;

namespace Iskra.Core.RenderRoot;

[SupportedOSPlatform("browser")]
public class DomRenderRoot : IRenderRoot
{
    private readonly Node _node;
    private readonly LinkedList<DomRenderSlot?> _slots = [];
    internal Node Node => _node;

    public DomRenderRoot(Node node)
    {
        _node = node;
        var childNodes = node.ChildNodes;
        for (uint i = 0; i < childNodes.Length; i++)
        {
            var listNode = _slots.AddLast((DomRenderSlot?)null);
            listNode.Value = new DomRenderSlot(listNode, this, childNodes.Item(i));
        }
    }

    public IRenderSlot ClaimOrCreateFirstSlot()
    {
        var first = _slots.First?.Value;
        if (first is not null)
        {
            if (first._claimed)
            {
                throw new System.Exception("First slot is already claimed.");
            }

            first._claimed = true;
            return first;
        }

        var listNode = _slots.AddLast((DomRenderSlot?)null);
        listNode.Value = new DomRenderSlot(listNode, this)
        {
            _claimed = true
        };

        return listNode.Value;
    }

    internal IRenderSlot ClaimOrCreateSlotAfter(LinkedListNode<DomRenderSlot?> listNode)
    {
        if (listNode.List is null)
        {
            throw new System.Exception("Slot must be attached.");
        }

        if (listNode.Next?.Value is { _claimed: false } nextSlot)
        {
            nextSlot._claimed = true;
            return nextSlot;
        }

        var newListNode = _slots.AddAfter(listNode, (DomRenderSlot?)null);
        newListNode.Value = new DomRenderSlot(newListNode, this)
        {
            _claimed = true
        };

        return newListNode.Value;
    }
}