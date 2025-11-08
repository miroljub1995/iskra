namespace Iskra.App;

public class VirtualNodeComponent : VirtualNode
{
    public required RenderNodeComponent RenderNode { get; set; }
    public required IIskraComponentLife ComponentLife { get; set; }
}