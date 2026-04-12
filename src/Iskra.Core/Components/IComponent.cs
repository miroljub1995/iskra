using Iskra.Core.RenderRoot;

namespace Iskra.Core.Components;

public interface IComponent
{
    void Mount(IRenderSlot slot);
    void Unmount();
}