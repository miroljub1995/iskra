using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore.Generics;

public interface IRecordValueMarshaller<TValue>
{
    static abstract bool TryGetValue(
        JSObject record,
        string key,
        [MaybeNullWhen(false)] out TValue value
    );

    static abstract void Set(JSObject record, string key, TValue value);
}