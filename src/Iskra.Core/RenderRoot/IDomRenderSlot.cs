using System.Runtime.Versioning;
using Iskra.StdWeb;

namespace Iskra.Core.RenderRoot;

[SupportedOSPlatform("browser")]
public interface IDomRenderSlot : IRenderSlot
{
    void Populate(Node node);
    void Empty();
}