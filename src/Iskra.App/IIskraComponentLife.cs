using Iskra.StdWeb.Dom;

namespace Iskra.App;

public interface IIskraComponentLife
{
    void Start(Element container, object props);
    void End();
    VirtualNode CurrentVirtualNode { get; }
}