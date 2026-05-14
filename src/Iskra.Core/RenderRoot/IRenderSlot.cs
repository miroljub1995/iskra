namespace Iskra.Core.RenderRoot;

public interface IRenderSlot : IDisposable
{
    IRenderSlot ClaimOrCreateSlotAfter();
    void MoveAfter(IRenderSlot anchor);
}