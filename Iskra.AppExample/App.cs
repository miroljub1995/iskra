using Iskra.App;

namespace Iskra.AppExample;

public record AppProps();

public class App : IIskraComponent<AppProps>
{
    public RenderCallback Setup(AppProps props)
    {
        return () => new RenderNodeText("Test text");
    }
}