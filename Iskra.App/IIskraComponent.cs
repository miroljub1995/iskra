namespace Iskra.App;

public interface IIskraComponent<in TProps>
{
    public RenderCallback Setup(TProps props);
}