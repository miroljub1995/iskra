using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.TestApi;

[GenerateBindings]
[AddToGlobalFactory]
public class TestApiProperties
{
    public string StringProperty
    {
        get => throw new();
        set => throw new();
    }

    public string ReadOnlyStringProperty
    {
        get => throw new();
    }
}