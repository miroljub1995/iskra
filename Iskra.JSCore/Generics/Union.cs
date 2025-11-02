using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;

namespace Iskra.JSCore.Generics;

public class Union<T1, T2, TMarshaller> : JSObjectProxy
    where T1 : notnull
    where T2 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>
{
    public Union(JSObject obj) : base(obj)
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
    public Union(JSObject obj) : base(obj)
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
    public Union(JSObject obj) : base(obj)
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
    public Union(JSObject obj) : base(obj)
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

public class Union<T1, T2, T3, T4, T5, T6, TMarshaller> : JSObjectProxy
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
    where T4 : notnull
    where T5 : notnull
    where T6 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>
{
    public Union(JSObject obj) : base(obj)
    {
    }

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    public bool TryCast([NotNullWhen(true)] out T1? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T2? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T3? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T4? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T5? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T6? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, T5, T6, T7, TMarshaller> : JSObjectProxy
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
    where T4 : notnull
    where T5 : notnull
    where T6 : notnull
    where T7 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>, IUnionTypeMarshaller<T7>
{
    public Union(JSObject obj) : base(obj)
    {
    }

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, TMarshaller>(T7 value) =>
        new(TMarshaller.ToJS(value));

    public bool TryCast([NotNullWhen(true)] out T1? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T2? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T3? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T4? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T5? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T6? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T7? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, T5, T6, T7, T8, TMarshaller> : JSObjectProxy
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
    where T4 : notnull
    where T5 : notnull
    where T6 : notnull
    where T7 : notnull
    where T8 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>,
    IUnionTypeMarshaller<T7>, IUnionTypeMarshaller<T8>
{
    public Union(JSObject obj) : base(obj)
    {
    }

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, TMarshaller>(T7 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, TMarshaller>(T8 value) =>
        new(TMarshaller.ToJS(value));

    public bool TryCast([NotNullWhen(true)] out T1? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T2? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T3? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T4? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T5? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T6? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T7? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T8? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TMarshaller> : JSObjectProxy
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
    where T4 : notnull
    where T5 : notnull
    where T6 : notnull
    where T7 : notnull
    where T8 : notnull
    where T9 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>,
    IUnionTypeMarshaller<T7>, IUnionTypeMarshaller<T8>, IUnionTypeMarshaller<T9>
{
    public Union(JSObject obj) : base(obj)
    {
    }

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TMarshaller>(T7 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TMarshaller>(T8 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TMarshaller>(T9 value) =>
        new(TMarshaller.ToJS(value));

    public bool TryCast([NotNullWhen(true)] out T1? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T2? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T3? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T4? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T5? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T6? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T7? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T8? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T9? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TMarshaller> : JSObjectProxy
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
    where T4 : notnull
    where T5 : notnull
    where T6 : notnull
    where T7 : notnull
    where T8 : notnull
    where T9 : notnull
    where T10 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>,
    IUnionTypeMarshaller<T7>, IUnionTypeMarshaller<T8>, IUnionTypeMarshaller<T9>,
    IUnionTypeMarshaller<T10>
{
    public Union(JSObject obj) : base(obj)
    {
    }

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TMarshaller>(T7 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TMarshaller>(T8 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TMarshaller>(T9 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TMarshaller>(T10 value) =>
        new(TMarshaller.ToJS(value));

    public bool TryCast([NotNullWhen(true)] out T1? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T2? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T3? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T4? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T5? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T6? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T7? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T8? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T9? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T10? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TMarshaller> : JSObjectProxy
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
    where T4 : notnull
    where T5 : notnull
    where T6 : notnull
    where T7 : notnull
    where T8 : notnull
    where T9 : notnull
    where T10 : notnull
    where T11 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>,
    IUnionTypeMarshaller<T7>, IUnionTypeMarshaller<T8>, IUnionTypeMarshaller<T9>,
    IUnionTypeMarshaller<T10>, IUnionTypeMarshaller<T11>
{
    public Union(JSObject obj) : base(obj)
    {
    }

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TMarshaller>(T7 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TMarshaller>(T8 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TMarshaller>(T9 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TMarshaller>(T10 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TMarshaller>(T11 value) =>
        new(TMarshaller.ToJS(value));

    public bool TryCast([NotNullWhen(true)] out T1? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T2? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T3? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T4? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T5? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T6? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T7? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T8? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T9? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T10? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T11? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller> : JSObjectProxy
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
    where T4 : notnull
    where T5 : notnull
    where T6 : notnull
    where T7 : notnull
    where T8 : notnull
    where T9 : notnull
    where T10 : notnull
    where T11 : notnull
    where T12 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>,
    IUnionTypeMarshaller<T7>, IUnionTypeMarshaller<T8>, IUnionTypeMarshaller<T9>,
    IUnionTypeMarshaller<T10>, IUnionTypeMarshaller<T11>, IUnionTypeMarshaller<T12>
{
    public Union(JSObject obj) : base(obj)
    {
    }

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller>(T7 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller>(T8 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller>(T9 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller>(T10 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller>(T11 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller>(T12 value) =>
        new(TMarshaller.ToJS(value));

    public bool TryCast([NotNullWhen(true)] out T1? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T2? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T3? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T4? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T5? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T6? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T7? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T8? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T9? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T10? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T11? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T12? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller> : JSObjectProxy
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
    where T4 : notnull
    where T5 : notnull
    where T6 : notnull
    where T7 : notnull
    where T8 : notnull
    where T9 : notnull
    where T10 : notnull
    where T11 : notnull
    where T12 : notnull
    where T13 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>,
    IUnionTypeMarshaller<T7>, IUnionTypeMarshaller<T8>, IUnionTypeMarshaller<T9>,
    IUnionTypeMarshaller<T10>, IUnionTypeMarshaller<T11>, IUnionTypeMarshaller<T12>,
    IUnionTypeMarshaller<T13>
{
    public Union(JSObject obj) : base(obj)
    {
    }

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T7 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T8 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T9 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T10 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T11 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T12 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T13 value) =>
        new(TMarshaller.ToJS(value));

    public bool TryCast([NotNullWhen(true)] out T1? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T2? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T3? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T4? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T5? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T6? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T7? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T8? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T9? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T10? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T11? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T12? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T13? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller> : JSObjectProxy
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
    where T4 : notnull
    where T5 : notnull
    where T6 : notnull
    where T7 : notnull
    where T8 : notnull
    where T9 : notnull
    where T10 : notnull
    where T11 : notnull
    where T12 : notnull
    where T13 : notnull
    where T14 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>,
    IUnionTypeMarshaller<T7>, IUnionTypeMarshaller<T8>, IUnionTypeMarshaller<T9>,
    IUnionTypeMarshaller<T10>, IUnionTypeMarshaller<T11>, IUnionTypeMarshaller<T12>,
    IUnionTypeMarshaller<T13>, IUnionTypeMarshaller<T14>
{
    public Union(JSObject obj) : base(obj)
    {
    }

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T7 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T8 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T9 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T10 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T11 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T12 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T13 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T14 value) =>
        new(TMarshaller.ToJS(value));

    public bool TryCast([NotNullWhen(true)] out T1? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T2? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T3? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T4? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T5? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T6? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T7? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T8? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T9? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T10? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T11? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T12? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T13? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T14? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller> : JSObjectProxy
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
    where T4 : notnull
    where T5 : notnull
    where T6 : notnull
    where T7 : notnull
    where T8 : notnull
    where T9 : notnull
    where T10 : notnull
    where T11 : notnull
    where T12 : notnull
    where T13 : notnull
    where T14 : notnull
    where T15 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>,
    IUnionTypeMarshaller<T7>, IUnionTypeMarshaller<T8>, IUnionTypeMarshaller<T9>,
    IUnionTypeMarshaller<T10>, IUnionTypeMarshaller<T11>, IUnionTypeMarshaller<T12>,
    IUnionTypeMarshaller<T13>, IUnionTypeMarshaller<T14>, IUnionTypeMarshaller<T15>
{
    public Union(JSObject obj) : base(obj)
    {
    }

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T7 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T8 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T9 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T10 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T11 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T12 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T13 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T14 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T15 value) =>
        new(TMarshaller.ToJS(value));

    public bool TryCast([NotNullWhen(true)] out T1? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T2? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T3? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T4? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T5? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T6? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T7? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T8? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T9? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T10? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T11? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T12? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T13? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T14? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T15? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller> : JSObjectProxy
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
    where T4 : notnull
    where T5 : notnull
    where T6 : notnull
    where T7 : notnull
    where T8 : notnull
    where T9 : notnull
    where T10 : notnull
    where T11 : notnull
    where T12 : notnull
    where T13 : notnull
    where T14 : notnull
    where T15 : notnull
    where T16 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>,
    IUnionTypeMarshaller<T7>, IUnionTypeMarshaller<T8>, IUnionTypeMarshaller<T9>,
    IUnionTypeMarshaller<T10>, IUnionTypeMarshaller<T11>, IUnionTypeMarshaller<T12>,
    IUnionTypeMarshaller<T13>, IUnionTypeMarshaller<T14>, IUnionTypeMarshaller<T15>,
    IUnionTypeMarshaller<T16>
{
    public Union(JSObject obj) : base(obj)
    {
    }

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T7 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T8 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T9 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T10 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T11 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T12 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T13 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T14 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T15 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T16 value) =>
        new(TMarshaller.ToJS(value));

    public bool TryCast([NotNullWhen(true)] out T1? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T2? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T3? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T4? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T5? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T6? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T7? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T8? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T9? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T10? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T11? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T12? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T13? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T14? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T15? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T16? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class
    Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller> : JSObjectProxy
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
    where T4 : notnull
    where T5 : notnull
    where T6 : notnull
    where T7 : notnull
    where T8 : notnull
    where T9 : notnull
    where T10 : notnull
    where T11 : notnull
    where T12 : notnull
    where T13 : notnull
    where T14 : notnull
    where T15 : notnull
    where T16 : notnull
    where T17 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>,
    IUnionTypeMarshaller<T7>, IUnionTypeMarshaller<T8>, IUnionTypeMarshaller<T9>,
    IUnionTypeMarshaller<T10>, IUnionTypeMarshaller<T11>, IUnionTypeMarshaller<T12>,
    IUnionTypeMarshaller<T13>, IUnionTypeMarshaller<T14>, IUnionTypeMarshaller<T15>,
    IUnionTypeMarshaller<T16>, IUnionTypeMarshaller<T17>
{
    public Union(JSObject obj) : base(obj)
    {
    }

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T7 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T8 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T9 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T10 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T11 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T12 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T13 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T14 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T15 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T16 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T17 value) =>
        new(TMarshaller.ToJS(value));

    public bool TryCast([NotNullWhen(true)] out T1? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T2? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T3? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T4? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T5? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T6? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T7? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T8? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T9? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T10? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T11? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T12? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T13? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T14? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T15? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T16? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T17? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18,
    TMarshaller> : JSObjectProxy
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
    where T4 : notnull
    where T5 : notnull
    where T6 : notnull
    where T7 : notnull
    where T8 : notnull
    where T9 : notnull
    where T10 : notnull
    where T11 : notnull
    where T12 : notnull
    where T13 : notnull
    where T14 : notnull
    where T15 : notnull
    where T16 : notnull
    where T17 : notnull
    where T18 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>,
    IUnionTypeMarshaller<T7>, IUnionTypeMarshaller<T8>, IUnionTypeMarshaller<T9>,
    IUnionTypeMarshaller<T10>, IUnionTypeMarshaller<T11>, IUnionTypeMarshaller<T12>,
    IUnionTypeMarshaller<T13>, IUnionTypeMarshaller<T14>, IUnionTypeMarshaller<T15>,
    IUnionTypeMarshaller<T16>, IUnionTypeMarshaller<T17>, IUnionTypeMarshaller<T18>
{
    public Union(JSObject obj) : base(obj)
    {
    }

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(T7 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(T8 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(T9 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(
            T10 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(
            T11 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(
            T12 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(
            T13 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(
            T14 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(
            T15 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(
            T16 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(
            T17 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(
            T18 value) =>
        new(TMarshaller.ToJS(value));

    public bool TryCast([NotNullWhen(true)] out T1? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T2? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T3? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T4? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T5? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T6? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T7? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T8? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T9? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T10? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T11? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T12? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T13? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T14? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T15? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T16? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T17? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T18? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19,
    TMarshaller> : JSObjectProxy
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
    where T4 : notnull
    where T5 : notnull
    where T6 : notnull
    where T7 : notnull
    where T8 : notnull
    where T9 : notnull
    where T10 : notnull
    where T11 : notnull
    where T12 : notnull
    where T13 : notnull
    where T14 : notnull
    where T15 : notnull
    where T16 : notnull
    where T17 : notnull
    where T18 : notnull
    where T19 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>,
    IUnionTypeMarshaller<T7>, IUnionTypeMarshaller<T8>, IUnionTypeMarshaller<T9>,
    IUnionTypeMarshaller<T10>, IUnionTypeMarshaller<T11>, IUnionTypeMarshaller<T12>,
    IUnionTypeMarshaller<T13>, IUnionTypeMarshaller<T14>, IUnionTypeMarshaller<T15>,
    IUnionTypeMarshaller<T16>, IUnionTypeMarshaller<T17>, IUnionTypeMarshaller<T18>,
    IUnionTypeMarshaller<T19>
{
    public Union(JSObject obj) : base(obj)
    {
    }

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T1 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T2 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T3 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T4 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T5 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T6 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T7 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T8 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T9 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T10 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T11 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T12 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T13 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T14 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T15 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T16 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T17 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T18 value) =>
        new(TMarshaller.ToJS(value));

    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T19 value) =>
        new(TMarshaller.ToJS(value));

    public bool TryCast([NotNullWhen(true)] out T1? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T2? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T3? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T4? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T5? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T6? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T7? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T8? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T9? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T10? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T11? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T12? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T13? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T14? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T15? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T16? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T17? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T18? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T19? value) => TMarshaller.TryToManaged(JSObject, out value);
}