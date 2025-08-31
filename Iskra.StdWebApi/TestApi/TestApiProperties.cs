using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.TestApi;

[GenerateBindings]
[AddToGlobalFactory]
public class TestApiProperties
{
    public int IntProperty
    {
        get => throw new();
        set => throw new();
    }

    public int IntPropertyReadOnly
    {
        get => throw new();
    }

    public string StringProperty
    {
        get => throw new();
        set => throw new();
    }

    public string StringPropertyReadOnly
    {
        get => throw new();
    }
}