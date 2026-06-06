namespace Iskra.Core.RenderRoot;

public interface IDomRenderRoot : IRenderRoot
{
    void BeginHydration();
    void EndHydration();
}