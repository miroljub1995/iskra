namespace Iskra.Ssr.Abstractions.RenderRoot;

public interface ISsrRenderSlot : IDisposable
{
    ISsrRenderSlot CreateSlotAfter();
    void MoveRangeAfter(ISsrRenderSlot rangeEnd, ISsrRenderSlot anchor);
    void Populate(ISsrNode node);
    ISsrRenderRoot CreateChildRoot(SsrElementNode parent);
    void Empty();
}
