using System.Runtime.Versioning;
using Iskra.StdWeb;

namespace Iskra.Core.RenderRoot;

[SupportedOSPlatform("browser")]
public class DomRenderRoot : IDomRenderRoot
{
    private readonly Node _node;
    private readonly LinkedList<DomRenderSlot?> _slots = [];
    private readonly Queue<Node> _hydrationQueue = new();
    internal Node Node => _node;
    private bool _isHydrating;
    internal bool IsHydrating => _isHydrating;

    public DomRenderRoot(Node node)
    {
        _node = node;
    }

    public IRenderSlot CreateFirstSlot()
    {
        if (_slots.First is not null)
        {
            throw new System.Exception("First slot already exists.");
        }

        var listNode = _slots.AddFirst((DomRenderSlot?)null);
        listNode.Value = new DomRenderSlot(listNode, this);
        return listNode.Value;
    }

    internal IDomRenderSlot CreateSlotAfter(LinkedListNode<DomRenderSlot?> listNode)
    {
        if (listNode.List is null)
        {
            throw new System.Exception("Slot must be attached.");
        }

        var newListNode = _slots.AddAfter(listNode, (DomRenderSlot?)null);
        newListNode.Value = new DomRenderSlot(newListNode, this);
        return newListNode.Value;
    }

    /// <summary>
    /// Dequeues the next pre-existing DOM node from the hydration queue.
    /// Returns <c>null</c> when no more server-rendered nodes remain (i.e. pure
    /// client-side rendering). When hydrating, an empty queue indicates a mismatch
    /// between SSR output and the component tree.
    /// </summary>
    internal Node? TryDequeueHydrationNode()
    {
        if (!_isHydrating)
        {
            return null;
        }

        if (_hydrationQueue.TryDequeue(out var node))
        {
            return node;
        }

        throw new HydrationMismatchException(
            "Hydration mismatch: component expected a server-rendered DOM node but the hydration queue is empty.");
    }

    public void BeginHydration()
    {
        _isHydrating = true;
        var childNodes = _node.ChildNodes;
        for (uint i = 0; i < childNodes.Length; i++)
        {
            var childNode = childNodes.Item(i);
            if (childNode is not null)
            {
                _hydrationQueue.Enqueue(childNode);
            }
        }
    }

    public void EndHydration()
    {
        _isHydrating = false;
        if (_hydrationQueue.Count > 0)
        {
            _hydrationQueue.Clear();
            throw new HydrationMismatchException(
                "Hydration mismatch: server rendered more DOM nodes than the component tree consumed.");
        }
    }
}