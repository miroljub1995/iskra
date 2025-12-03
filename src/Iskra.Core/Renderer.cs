using Iskra.Core.Instances;
using Iskra.Core.RenderRoot;
using Microsoft.Extensions.DependencyInjection;

namespace Iskra.Core;

public class Renderer(
    IKeyedServiceProvider provider
)
{
    public void Render(IRenderRoot root, BaseInstance instance)
    {
        instance.Mount(root.GetNextSlot());
    }
}