using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
[AddToGlobalFactory]
public class Window
{
    protected Window() => throw new();

    public Console Console => throw new();

    public HTMLDocument Document => throw new();
}