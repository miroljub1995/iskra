using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace Iskra.JSCore.Generics;

public class Union<T1, T2, TMarshaller> : JSObjectProxy
    where T1 : notnull
    where T2 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>
{
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, TMarshaller>(T1 value) => new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
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
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, TMarshaller>(T1 value) => new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, TMarshaller>(T2 value) => new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
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
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, TMarshaller>(T1 value) => new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, TMarshaller>(T2 value) => new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, TMarshaller>(T3 value) => new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
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
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, TMarshaller>(T1 value) => new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, TMarshaller>(T2 value) => new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, TMarshaller>(T3 value) => new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, TMarshaller>(T4 value) => new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
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
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
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
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
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
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, TMarshaller>(T7 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
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
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TMarshaller>(T7 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, TMarshaller>(T8 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
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
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TMarshaller>(T7 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TMarshaller>(T8 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TMarshaller>(T9 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
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
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TMarshaller>(T7 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TMarshaller>(T8 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TMarshaller>(T9 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TMarshaller>(T10 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
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
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller>(T7 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller>(T8 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller>(T9 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller>(T10 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TMarshaller>(T11 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
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
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T7 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T8 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T9 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T10 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T11 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TMarshaller>(T12 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
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
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T7 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T8 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T9 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T10 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T11 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T12 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TMarshaller>(T13 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
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
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T7 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T8 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T9 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T10 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T11 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T12 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T13 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TMarshaller>(T14 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
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
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T7 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T8 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T9 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T10 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T11 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T12 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T13 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T14 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TMarshaller>(T15 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
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
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T7 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T8 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T9 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T10 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T11 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T12 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T13 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T14 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T15 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, TMarshaller>(T16 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
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
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(T1 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(T2 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(T3 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(T4 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(T5 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(T6 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(T7 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(T8 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(T9 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(
            T10 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(
            T11 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(
            T12 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(
            T13 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(
            T14 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(
            T15 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(
            T16 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, TMarshaller>(
            T17 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
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
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T1 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T2 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T3 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T4 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T5 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T6 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T7 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T8 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T9 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T10 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T11 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T12 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T13 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T14 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T15 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T16 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T17 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
        Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, TMarshaller>(
            T18 value) =>
        new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
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

public class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TMarshaller> : JSObjectProxy
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
    where T20 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>,
    IUnionTypeMarshaller<T7>, IUnionTypeMarshaller<T8>, IUnionTypeMarshaller<T9>,
    IUnionTypeMarshaller<T10>, IUnionTypeMarshaller<T11>, IUnionTypeMarshaller<T12>,
    IUnionTypeMarshaller<T13>, IUnionTypeMarshaller<T14>, IUnionTypeMarshaller<T15>,
    IUnionTypeMarshaller<T16>, IUnionTypeMarshaller<T17>, IUnionTypeMarshaller<T18>,
    IUnionTypeMarshaller<T19>, IUnionTypeMarshaller<T20>
{
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TMarshaller>(
                T1 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TMarshaller>(
                T2 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TMarshaller>(
                T3 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TMarshaller>(
                T4 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TMarshaller>(
                T5 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TMarshaller>(
                T6 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TMarshaller>(
                T7 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TMarshaller>(
                T8 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TMarshaller>(
                T9 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TMarshaller>(
                T10 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TMarshaller>(
                T11 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TMarshaller>(
                T12 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TMarshaller>(
                T13 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TMarshaller>(
                T14 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TMarshaller>(
                T15 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TMarshaller>(
                T16 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TMarshaller>(
                T17 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TMarshaller>(
                T18 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TMarshaller>(
                T19 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, TMarshaller>(
                T20 value) =>
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
    public bool TryCast([NotNullWhen(true)] out T20? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TMarshaller> : JSObjectProxy
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
    where T20 : notnull
    where T21 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>,
    IUnionTypeMarshaller<T7>, IUnionTypeMarshaller<T8>, IUnionTypeMarshaller<T9>,
    IUnionTypeMarshaller<T10>, IUnionTypeMarshaller<T11>, IUnionTypeMarshaller<T12>,
    IUnionTypeMarshaller<T13>, IUnionTypeMarshaller<T14>, IUnionTypeMarshaller<T15>,
    IUnionTypeMarshaller<T16>, IUnionTypeMarshaller<T17>, IUnionTypeMarshaller<T18>,
    IUnionTypeMarshaller<T19>, IUnionTypeMarshaller<T20>, IUnionTypeMarshaller<T21>
{
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TMarshaller>(
                T1 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TMarshaller>(
                T2 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TMarshaller>(
                T3 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TMarshaller>(
                T4 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TMarshaller>(
                T5 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TMarshaller>(
                T6 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TMarshaller>(
                T7 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TMarshaller>(
                T8 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TMarshaller>(
                T9 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TMarshaller>(
                T10 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TMarshaller>(
                T11 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TMarshaller>(
                T12 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TMarshaller>(
                T13 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TMarshaller>(
                T14 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TMarshaller>(
                T15 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TMarshaller>(
                T16 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TMarshaller>(
                T17 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TMarshaller>(
                T18 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TMarshaller>(
                T19 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TMarshaller>(
                T20 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, TMarshaller>(
                T21 value) =>
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
    public bool TryCast([NotNullWhen(true)] out T20? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T21? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TMarshaller> : JSObjectProxy
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
    where T20 : notnull
    where T21 : notnull
    where T22 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>,
    IUnionTypeMarshaller<T7>, IUnionTypeMarshaller<T8>, IUnionTypeMarshaller<T9>,
    IUnionTypeMarshaller<T10>, IUnionTypeMarshaller<T11>, IUnionTypeMarshaller<T12>,
    IUnionTypeMarshaller<T13>, IUnionTypeMarshaller<T14>, IUnionTypeMarshaller<T15>,
    IUnionTypeMarshaller<T16>, IUnionTypeMarshaller<T17>, IUnionTypeMarshaller<T18>,
    IUnionTypeMarshaller<T19>, IUnionTypeMarshaller<T20>, IUnionTypeMarshaller<T21>,
    IUnionTypeMarshaller<T22>
{
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TMarshaller>(
                T1 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TMarshaller>(
                T2 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TMarshaller>(
                T3 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TMarshaller>(
                T4 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TMarshaller>(
                T5 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TMarshaller>(
                T6 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TMarshaller>(
                T7 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TMarshaller>(
                T8 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TMarshaller>(
                T9 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TMarshaller>(
                T10 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TMarshaller>(
                T11 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TMarshaller>(
                T12 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TMarshaller>(
                T13 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TMarshaller>(
                T14 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TMarshaller>(
                T15 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TMarshaller>(
                T16 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TMarshaller>(
                T17 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TMarshaller>(
                T18 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TMarshaller>(
                T19 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TMarshaller>(
                T20 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TMarshaller>(
                T21 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, TMarshaller>(
                T22 value) =>
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
    public bool TryCast([NotNullWhen(true)] out T20? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T21? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T22? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller> : JSObjectProxy
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
    where T20 : notnull
    where T21 : notnull
    where T22 : notnull
    where T23 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>,
    IUnionTypeMarshaller<T7>, IUnionTypeMarshaller<T8>, IUnionTypeMarshaller<T9>,
    IUnionTypeMarshaller<T10>, IUnionTypeMarshaller<T11>, IUnionTypeMarshaller<T12>,
    IUnionTypeMarshaller<T13>, IUnionTypeMarshaller<T14>, IUnionTypeMarshaller<T15>,
    IUnionTypeMarshaller<T16>, IUnionTypeMarshaller<T17>, IUnionTypeMarshaller<T18>,
    IUnionTypeMarshaller<T19>, IUnionTypeMarshaller<T20>, IUnionTypeMarshaller<T21>,
    IUnionTypeMarshaller<T22>, IUnionTypeMarshaller<T23>
{
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller>(
                T1 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller>(
                T2 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller>(
                T3 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller>(
                T4 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller>(
                T5 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller>(
                T6 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller>(
                T7 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller>(
                T8 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller>(
                T9 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller>(
                T10 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller>(
                T11 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller>(
                T12 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller>(
                T13 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller>(
                T14 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller>(
                T15 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller>(
                T16 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller>(
                T17 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller>(
                T18 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller>(
                T19 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller>(
                T20 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller>(
                T21 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller>(
                T22 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, TMarshaller>(
                T23 value) =>
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
    public bool TryCast([NotNullWhen(true)] out T20? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T21? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T22? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T23? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller> : JSObjectProxy
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
    where T20 : notnull
    where T21 : notnull
    where T22 : notnull
    where T23 : notnull
    where T24 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>,
    IUnionTypeMarshaller<T7>, IUnionTypeMarshaller<T8>, IUnionTypeMarshaller<T9>,
    IUnionTypeMarshaller<T10>, IUnionTypeMarshaller<T11>, IUnionTypeMarshaller<T12>,
    IUnionTypeMarshaller<T13>, IUnionTypeMarshaller<T14>, IUnionTypeMarshaller<T15>,
    IUnionTypeMarshaller<T16>, IUnionTypeMarshaller<T17>, IUnionTypeMarshaller<T18>,
    IUnionTypeMarshaller<T19>, IUnionTypeMarshaller<T20>, IUnionTypeMarshaller<T21>,
    IUnionTypeMarshaller<T22>, IUnionTypeMarshaller<T23>, IUnionTypeMarshaller<T24>
{
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T1 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T2 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T3 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T4 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T5 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T6 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T7 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T8 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T9 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T10 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T11 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T12 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T13 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T14 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T15 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T16 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T17 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T18 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T19 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T20 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T21 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T22 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T23 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, TMarshaller>(
                T24 value) =>
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
    public bool TryCast([NotNullWhen(true)] out T20? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T21? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T22? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T23? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T24? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller> : JSObjectProxy
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
    where T20 : notnull
    where T21 : notnull
    where T22 : notnull
    where T23 : notnull
    where T24 : notnull
    where T25 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>,
    IUnionTypeMarshaller<T7>, IUnionTypeMarshaller<T8>, IUnionTypeMarshaller<T9>,
    IUnionTypeMarshaller<T10>, IUnionTypeMarshaller<T11>, IUnionTypeMarshaller<T12>,
    IUnionTypeMarshaller<T13>, IUnionTypeMarshaller<T14>, IUnionTypeMarshaller<T15>,
    IUnionTypeMarshaller<T16>, IUnionTypeMarshaller<T17>, IUnionTypeMarshaller<T18>,
    IUnionTypeMarshaller<T19>, IUnionTypeMarshaller<T20>, IUnionTypeMarshaller<T21>,
    IUnionTypeMarshaller<T22>, IUnionTypeMarshaller<T23>, IUnionTypeMarshaller<T24>,
    IUnionTypeMarshaller<T25>
{
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T1 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T2 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T3 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T4 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T5 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T6 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T7 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T8 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T9 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T10 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T11 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T12 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T13 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T14 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T15 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T16 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T17 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T18 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T19 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T20 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T21 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T22 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T23 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T24 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, TMarshaller>(
                T25 value) =>
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
    public bool TryCast([NotNullWhen(true)] out T20? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T21? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T22? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T23? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T24? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T25? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller> : JSObjectProxy
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
    where T20 : notnull
    where T21 : notnull
    where T22 : notnull
    where T23 : notnull
    where T24 : notnull
    where T25 : notnull
    where T26 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>,
    IUnionTypeMarshaller<T7>, IUnionTypeMarshaller<T8>, IUnionTypeMarshaller<T9>,
    IUnionTypeMarshaller<T10>, IUnionTypeMarshaller<T11>, IUnionTypeMarshaller<T12>,
    IUnionTypeMarshaller<T13>, IUnionTypeMarshaller<T14>, IUnionTypeMarshaller<T15>,
    IUnionTypeMarshaller<T16>, IUnionTypeMarshaller<T17>, IUnionTypeMarshaller<T18>,
    IUnionTypeMarshaller<T19>, IUnionTypeMarshaller<T20>, IUnionTypeMarshaller<T21>,
    IUnionTypeMarshaller<T22>, IUnionTypeMarshaller<T23>, IUnionTypeMarshaller<T24>,
    IUnionTypeMarshaller<T25>, IUnionTypeMarshaller<T26>
{
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T1 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T2 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T3 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T4 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T5 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T6 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T7 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T8 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T9 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T10 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T11 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T12 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T13 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T14 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T15 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T16 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T17 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T18 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T19 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T20 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T21 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T22 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T23 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T24 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T25 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, TMarshaller>(
                T26 value) =>
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
    public bool TryCast([NotNullWhen(true)] out T20? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T21? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T22? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T23? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T24? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T25? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T26? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller> : JSObjectProxy
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
    where T20 : notnull
    where T21 : notnull
    where T22 : notnull
    where T23 : notnull
    where T24 : notnull
    where T25 : notnull
    where T26 : notnull
    where T27 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>,
    IUnionTypeMarshaller<T7>, IUnionTypeMarshaller<T8>, IUnionTypeMarshaller<T9>,
    IUnionTypeMarshaller<T10>, IUnionTypeMarshaller<T11>, IUnionTypeMarshaller<T12>,
    IUnionTypeMarshaller<T13>, IUnionTypeMarshaller<T14>, IUnionTypeMarshaller<T15>,
    IUnionTypeMarshaller<T16>, IUnionTypeMarshaller<T17>, IUnionTypeMarshaller<T18>,
    IUnionTypeMarshaller<T19>, IUnionTypeMarshaller<T20>, IUnionTypeMarshaller<T21>,
    IUnionTypeMarshaller<T22>, IUnionTypeMarshaller<T23>, IUnionTypeMarshaller<T24>,
    IUnionTypeMarshaller<T25>, IUnionTypeMarshaller<T26>, IUnionTypeMarshaller<T27>
{
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T1 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T2 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T3 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T4 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T5 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T6 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T7 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T8 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T9 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T10 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T11 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T12 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T13 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T14 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T15 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T16 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T17 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T18 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T19 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T20 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T21 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T22 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T23 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T24 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T25 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T26 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, TMarshaller>(
                T27 value) =>
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
    public bool TryCast([NotNullWhen(true)] out T20? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T21? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T22? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T23? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T24? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T25? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T26? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T27? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller> : JSObjectProxy
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
    where T20 : notnull
    where T21 : notnull
    where T22 : notnull
    where T23 : notnull
    where T24 : notnull
    where T25 : notnull
    where T26 : notnull
    where T27 : notnull
    where T28 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>,
    IUnionTypeMarshaller<T7>, IUnionTypeMarshaller<T8>, IUnionTypeMarshaller<T9>,
    IUnionTypeMarshaller<T10>, IUnionTypeMarshaller<T11>, IUnionTypeMarshaller<T12>,
    IUnionTypeMarshaller<T13>, IUnionTypeMarshaller<T14>, IUnionTypeMarshaller<T15>,
    IUnionTypeMarshaller<T16>, IUnionTypeMarshaller<T17>, IUnionTypeMarshaller<T18>,
    IUnionTypeMarshaller<T19>, IUnionTypeMarshaller<T20>, IUnionTypeMarshaller<T21>,
    IUnionTypeMarshaller<T22>, IUnionTypeMarshaller<T23>, IUnionTypeMarshaller<T24>,
    IUnionTypeMarshaller<T25>, IUnionTypeMarshaller<T26>, IUnionTypeMarshaller<T27>,
    IUnionTypeMarshaller<T28>
{
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T1 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T2 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T3 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T4 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T5 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T6 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T7 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T8 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T9 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T10 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T11 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T12 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T13 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T14 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T15 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T16 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T17 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T18 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T19 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T20 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T21 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T22 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T23 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T24 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T25 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T26 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T27 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, TMarshaller>(
                T28 value) =>
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
    public bool TryCast([NotNullWhen(true)] out T20? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T21? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T22? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T23? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T24? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T25? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T26? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T27? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T28? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller> : JSObjectProxy
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
    where T20 : notnull
    where T21 : notnull
    where T22 : notnull
    where T23 : notnull
    where T24 : notnull
    where T25 : notnull
    where T26 : notnull
    where T27 : notnull
    where T28 : notnull
    where T29 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>,
    IUnionTypeMarshaller<T7>, IUnionTypeMarshaller<T8>, IUnionTypeMarshaller<T9>,
    IUnionTypeMarshaller<T10>, IUnionTypeMarshaller<T11>, IUnionTypeMarshaller<T12>,
    IUnionTypeMarshaller<T13>, IUnionTypeMarshaller<T14>, IUnionTypeMarshaller<T15>,
    IUnionTypeMarshaller<T16>, IUnionTypeMarshaller<T17>, IUnionTypeMarshaller<T18>,
    IUnionTypeMarshaller<T19>, IUnionTypeMarshaller<T20>, IUnionTypeMarshaller<T21>,
    IUnionTypeMarshaller<T22>, IUnionTypeMarshaller<T23>, IUnionTypeMarshaller<T24>,
    IUnionTypeMarshaller<T25>, IUnionTypeMarshaller<T26>, IUnionTypeMarshaller<T27>,
    IUnionTypeMarshaller<T28>, IUnionTypeMarshaller<T29>
{
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T1 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T2 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T3 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T4 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T5 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T6 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T7 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T8 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T9 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T10 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T11 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T12 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T13 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T14 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T15 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T16 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T17 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T18 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T19 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T20 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T21 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T22 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T23 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T24 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T25 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T26 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T27 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T28 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, TMarshaller>(
                T29 value) =>
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
    public bool TryCast([NotNullWhen(true)] out T20? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T21? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T22? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T23? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T24? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T25? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T26? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T27? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T28? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T29? value) => TMarshaller.TryToManaged(JSObject, out value);
}

public class Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller> : JSObjectProxy
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
    where T20 : notnull
    where T21 : notnull
    where T22 : notnull
    where T23 : notnull
    where T24 : notnull
    where T25 : notnull
    where T26 : notnull
    where T27 : notnull
    where T28 : notnull
    where T29 : notnull
    where T30 : notnull
    where TMarshaller : IUnionTypeMarshaller<T1>, IUnionTypeMarshaller<T2>, IUnionTypeMarshaller<T3>,
    IUnionTypeMarshaller<T4>, IUnionTypeMarshaller<T5>, IUnionTypeMarshaller<T6>,
    IUnionTypeMarshaller<T7>, IUnionTypeMarshaller<T8>, IUnionTypeMarshaller<T9>,
    IUnionTypeMarshaller<T10>, IUnionTypeMarshaller<T11>, IUnionTypeMarshaller<T12>,
    IUnionTypeMarshaller<T13>, IUnionTypeMarshaller<T14>, IUnionTypeMarshaller<T15>,
    IUnionTypeMarshaller<T16>, IUnionTypeMarshaller<T17>, IUnionTypeMarshaller<T18>,
    IUnionTypeMarshaller<T19>, IUnionTypeMarshaller<T20>, IUnionTypeMarshaller<T21>,
    IUnionTypeMarshaller<T22>, IUnionTypeMarshaller<T23>, IUnionTypeMarshaller<T24>,
    IUnionTypeMarshaller<T25>, IUnionTypeMarshaller<T26>, IUnionTypeMarshaller<T27>,
    IUnionTypeMarshaller<T28>, IUnionTypeMarshaller<T29>, IUnionTypeMarshaller<T30>
{
    [SupportedOSPlatform("browser")]
    public Union(JSObject obj) : base(obj)
    {
    }

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T1 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T2 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T3 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T4 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T5 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T6 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T7 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T8 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T9 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T10 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T11 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T12 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T13 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T14 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T15 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T16 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T17 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T18 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T19 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T20 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T21 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T22 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T23 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T24 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T25 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T26 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T27 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T28 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T29 value) =>
            new(TMarshaller.ToJS(value));

    [SupportedOSPlatform("browser")]
    public static implicit operator
            Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21, T22, T23, T24, T25, T26, T27, T28, T29, T30, TMarshaller>(
                T30 value) =>
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
    public bool TryCast([NotNullWhen(true)] out T20? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T21? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T22? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T23? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T24? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T25? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T26? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T27? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T28? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T29? value) => TMarshaller.TryToManaged(JSObject, out value);
    public bool TryCast([NotNullWhen(true)] out T30? value) => TMarshaller.TryToManaged(JSObject, out value);
}
