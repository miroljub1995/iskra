namespace Iskra.Core.RenderRoot;

public interface ISsrRenderSlot : IRenderSlot
{
    void Populate(ISsrNode node);
    void Empty();
}
