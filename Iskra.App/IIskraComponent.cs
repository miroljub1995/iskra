namespace Iskra.App;

public interface IIskraComponent<in TProps>
where TProps : notnull
{
    public RenderCallback Setup(TProps props);
}