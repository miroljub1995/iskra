using Iskra.Core.RenderRoot;

namespace Iskra.Core.Instances;

public abstract class BaseInstance
{
    public abstract void Mount(IRenderSlot slot);
    public abstract void Unmount();
}