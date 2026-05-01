using System.Collections;

namespace Iskra.Core.Features;

/// <summary>
/// Default <see cref="IFeatureCollection"/> implementation, modeled after
/// <c>Microsoft.AspNetCore.Http.Features.FeatureCollection</c>.
/// Supports an optional parent collection: reads fall back to the parent when
/// a key is not found locally; writes only mutate the local layer.
/// </summary>
public sealed class FeatureCollection : IFeatureCollection
{
    private readonly IFeatureCollection? _defaults;
    private Dictionary<Type, object>? _features;

    public FeatureCollection()
    {
    }

    public FeatureCollection(IFeatureCollection defaults)
    {
        _defaults = defaults;
    }

    public bool IsReadOnly => false;

    public object? this[Type key]
    {
        get
        {
            ArgumentNullException.ThrowIfNull(key);

            if (_features != null && _features.TryGetValue(key, out var result))
            {
                return result;
            }

            return _defaults?[key];
        }
        set
        {
            ArgumentNullException.ThrowIfNull(key);

            if (value == null)
            {
                _features?.Remove(key);
                return;
            }

            _features ??= [];
            _features[key] = value;
        }
    }

    public TFeature? Get<TFeature>()
    {
        return (TFeature?)this[typeof(TFeature)];
    }

    public void Set<TFeature>(TFeature? instance)
    {
        this[typeof(TFeature)] = instance;
    }

    public IEnumerator<KeyValuePair<Type, object>> GetEnumerator()
    {
        if (_features != null)
        {
            foreach (var pair in _features)
            {
                yield return pair;
            }
        }

        if (_defaults != null)
        {
            foreach (var pair in _defaults)
            {
                if (_features == null || !_features.ContainsKey(pair.Key))
                {
                    yield return pair;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
