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
    
    public int? IntPropertyNullable
    {
        get => throw new();
        set => throw new();
    }

    public int? IntPropertyReadOnlyNullableAsNull
    {
        get => throw new();
    }

    public int? IntPropertyReadOnlyNullableAsNotNull
    {
        get => throw new();
    }

    public double DoubleProperty
    {
        get => throw new();
        set => throw new();
    }

    public double DoublePropertyReadOnly
    {
        get => throw new();
    }

    public bool BoolProperty
    {
        get => throw new();
        set => throw new();
    }

    public bool BoolPropertyReadOnly
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