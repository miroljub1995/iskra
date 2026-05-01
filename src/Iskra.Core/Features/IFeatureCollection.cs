namespace Iskra.Core.Features;

/// <summary>
/// Represents a typed collection of HTTP-style features, modeled after
/// <c>Microsoft.AspNetCore.Http.Features.IFeatureCollection</c>.
/// </summary>
public interface IFeatureCollection : IEnumerable<KeyValuePair<Type, object>>
{
    bool IsReadOnly { get; }

    object? this[Type key] { get; set; }

    TFeature? Get<TFeature>();

    void Set<TFeature>(TFeature? instance);
}
