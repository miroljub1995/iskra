using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.Api;

[GenerateBindings]
public class Console
{
    protected Console() => throw new();

    public void Log([AsParams] object[] args) => throw new();
}