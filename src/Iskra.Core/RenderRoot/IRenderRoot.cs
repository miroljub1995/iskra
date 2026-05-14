namespace Iskra.Core.RenderRoot;

public interface IRenderRoot
{
    IRenderSlot ClaimOrCreateFirstSlot();
}