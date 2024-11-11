using Iskra.StdWeb.Dom;

namespace Iskra.App;

public abstract class VirtualNodeDomNode : VirtualNode
{
    public abstract Node Node { get; }
}