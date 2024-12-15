using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
public class Console
{
    private Console() => throw new();

    public void Log([AsParams] object[] args) => throw new();
}