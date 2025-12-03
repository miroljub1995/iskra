using System.Runtime.Versioning;
using Iskra.StdWeb;

namespace Iskra.Core.RenderRoot;

[SupportedOSPlatform("browser")]
public class DomRenderRoot : IRenderRoot
{
    private readonly Node _node;
    private readonly LinkedList<DomRenderSlot> _slots = [];

    public DomRenderRoot(Node node)
    {
        _node = node;
    }

    public IRenderSlot GetNextSlot()
    {
        return new DomRenderSlot(_slots, _node);
    }
}