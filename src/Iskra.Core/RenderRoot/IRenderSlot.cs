namespace Iskra.Core.RenderRoot;

public interface IRenderSlot : IDisposable
{
    IRenderSlot CreateSlotAfter();
}