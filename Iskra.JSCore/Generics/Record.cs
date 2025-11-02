using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;
using Iskra.JSCore.Extensions;

namespace Iskra.JSCore.Generics;

public class Record<TValue, TAccessor>(JSObject obj) : JSObjectProxy(obj), IEnumerable<KeyValuePair<string, TValue>>
    where TAccessor : IPropertyAccessor<TValue>
{
    public TValue this[string key]
    {
        get => TryGetValue(key, out var value)
            ? value
            : throw new KeyNotFoundException($"Key ${key} doesn't exist.");
        set => TAccessor.Set(JSObject, key, value);
    }

    public ICollection<string> Keys => throw new NotImplementedException();

    public ICollection<TValue> Values => throw new NotImplementedException();

    public bool ContainsKey(string key) => JSObject.HasProperty(key);

    public void Add(string key, TValue value)
    {
        if (ContainsKey(key))
        {
            throw new ArgumentException($"Key {key} already exists.");
        }

        this[key] = value;
    }

    public bool Remove(string key) => JSObject.DeleteProperty(key);

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out TValue value)
    {
        if (!ContainsKey(key))
        {
            value = default;
            return false;
        }

        value = TAccessor.Get(JSObject, key);
        return true;
    }

    public IEnumerator<KeyValuePair<string, TValue>> GetEnumerator()
    {
        // TODO: Implement some mem efficient iterator, like:
        // function* entries(obj) {
        //     for (const key in obj) {
        //         yield { key, value: obj[key] };
        //     }
        // }
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}