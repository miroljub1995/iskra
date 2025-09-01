using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebApi.TestApi;

[GenerateBindings]
[AddToGlobalFactory]
public class TestApiProperties
{
    // Int
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

    // Double
    public double DoubleProperty
    {
        get => throw new();
        set => throw new();
    }

    public double DoublePropertyReadOnly
    {
        get => throw new();
    }
    
    public double? DoublePropertyNullable
    {
        get => throw new();
        set => throw new();
    }

    public double? DoublePropertyReadOnlyNullableAsNull
    {
        get => throw new();
    }

    public double? DoublePropertyReadOnlyNullableAsNotNull
    {
        get => throw new();
    }

    // Bool
    public bool BoolProperty
    {
        get => throw new();
        set => throw new();
    }

    public bool BoolPropertyReadOnly
    {
        get => throw new();
    }
    
    public bool? BoolPropertyNullable
    {
        get => throw new();
        set => throw new();
    }

    public bool? BoolPropertyReadOnlyNullableAsNull
    {
        get => throw new();
    }

    public bool? BoolPropertyReadOnlyNullableAsTrue
    {
        get => throw new();
    }

    public bool? BoolPropertyReadOnlyNullableAsFalse
    {
        get => throw new();
    }

    // String
    public string StringProperty
    {
        get => throw new();
        set => throw new();
    }

    public string StringPropertyReadOnly
    {
        get => throw new();
    }
    
    public string? StringPropertyNullable
    {
        get => throw new();
        set => throw new();
    }

    public string? StringPropertyReadOnlyNullableAsNull
    {
        get => throw new();
    }

    public string? StringPropertyReadOnlyNullableAsNotNull
    {
        get => throw new();
    }

    public string? StringPropertyReadOnlyNullableAsEmpty
    {
        get => throw new();
    }
}