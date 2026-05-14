using System.IO.Pipelines;

namespace Iskra.Core.RenderRoot;

public sealed class SsrRenderRoot : IRenderRoot
{
    private readonly LinkedList<SsrRenderSlot?> _slots;

    public SsrRenderRoot()
    {
        _slots = [];
    }

    internal SsrRenderRoot(SsrElementNode parent)
    {
        _slots = parent.Children;
    }

    public IRenderSlot ClaimOrCreateFirstSlot()
    {
        var listNode = _slots.AddLast((SsrRenderSlot?)null);
        var slot = new SsrRenderSlot(listNode, this);
        listNode.Value = slot;
        return slot;
    }

    internal IRenderSlot ClaimOrCreateSlotAfter(LinkedListNode<SsrRenderSlot?> listNode)
    {
        if (listNode.List is null)
        {
            throw new System.Exception("Slot must be attached.");
        }

        var newListNode = _slots.AddAfter(listNode, (SsrRenderSlot?)null);
        var newSlot = new SsrRenderSlot(newListNode, this);
        newListNode.Value = newSlot;
        return newSlot;
    }

    /// <summary>
    /// Serializes the tree to <paramref name="writer"/>. Does not call
    /// <see cref="PipeWriter.FlushAsync"/> or <see cref="PipeWriter.Complete"/>;
    /// the caller is responsible for flushing and completing the pipe.
    /// </summary>
    /// <param name="sortAttributes">
    /// When <c>true</c>, attributes on each element are emitted in ordinal order
    /// of their names rather than insertion order. Useful for deterministic
    /// snapshot tests; the underlying storage is a hash dictionary.
    /// </param>
    public async ValueTask WriteAsync(PipeWriter writer, bool sortAttributes = false, CancellationToken cancellationToken = default)
    {
        foreach (var slot in _slots)
        {
            if (slot is { Node: { } node })
            {
                await node.WriteAsync(writer, sortAttributes, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
