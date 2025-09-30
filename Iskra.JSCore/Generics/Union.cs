using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore.Generics;

public class Union<T1, T2, TMarshaller> : JSObjectProxy
    where T1 : notnull
    where T2 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>
{
    private Union(JSObject obj) : base(obj)
    {
    }

    public static implicit operator Union<T1, T2, TMarshaller>(T1 value) => new(TMarshaller.ToJS(value));
    public static implicit operator Union<T1, T2, TMarshaller>(T2 value) => new(TMarshaller.ToJS(value));

    public bool TryCast([NotNullWhen(true)] out T1? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T2? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, TMarshaller> : JSObjectProxy
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>
{
    private Union(JSObject obj) : base(obj)
    {
    }

    public static implicit operator Union<T1, T2, T3, TMarshaller>(T1 value) => new(TMarshaller.ToJS(value));
    public static implicit operator Union<T1, T2, T3, TMarshaller>(T2 value) => new(TMarshaller.ToJS(value));
    public static implicit operator Union<T1, T2, T3, TMarshaller>(T3 value) => new(TMarshaller.ToJS(value));

    public bool TryCast([NotNullWhen(true)] out T1? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T2? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T3? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, TMarshaller> : JSObjectProxy
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
    where T4 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>
{
    private Union(JSObject obj) : base(obj)
    {
    }

    public static implicit operator Union<T1, T2, T3, T4, TMarshaller>(T1 value) => new(TMarshaller.ToJS(value));
    public static implicit operator Union<T1, T2, T3, T4, TMarshaller>(T2 value) => new(TMarshaller.ToJS(value));
    public static implicit operator Union<T1, T2, T3, T4, TMarshaller>(T3 value) => new(TMarshaller.ToJS(value));
    public static implicit operator Union<T1, T2, T3, T4, TMarshaller>(T4 value) => new(TMarshaller.ToJS(value));

    public bool TryCast([NotNullWhen(true)] out T1? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T2? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T3? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T4? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, T5, TMarshaller> : JSObjectProxy
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
    where T4 : notnull
    where T5 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>
{
    private Union(JSObject obj) : base(obj)
    {
    }

    public static implicit operator Union<T1, T2, T3, T4, T5, TMarshaller>(T1 value) => new(TMarshaller.ToJS(value));
    public static implicit operator Union<T1, T2, T3, T4, T5, TMarshaller>(T2 value) => new(TMarshaller.ToJS(value));
    public static implicit operator Union<T1, T2, T3, T4, T5, TMarshaller>(T3 value) => new(TMarshaller.ToJS(value));
    public static implicit operator Union<T1, T2, T3, T4, T5, TMarshaller>(T4 value) => new(TMarshaller.ToJS(value));
    public static implicit operator Union<T1, T2, T3, T4, T5, TMarshaller>(T5 value) => new(TMarshaller.ToJS(value));

    public bool TryCast([NotNullWhen(true)] out T1? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T2? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T3? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T4? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T5? value) => TMarshaller.TryToManaged(JSObject, out value);
}