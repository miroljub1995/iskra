namespace Iskra.StdWeb;

public abstract class OneOf
{
    public required object Value { get; set; }
}

public class OneOf<T1, T2> : OneOf
    where T1 : notnull
    where T2 : notnull
{
    public static implicit operator OneOf<T1, T2>(T1 value)
        => new()
        {
            Value = value
        };

    public static implicit operator OneOf<T1, T2>(T2 value)
        => new()
        {
            Value = value
        };
}

public class OneOf<T1, T2, T3> : OneOf
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
{
    public static implicit operator OneOf<T1, T2, T3>(T1 value)
        => new()
        {
            Value = value
        };

    public static implicit operator OneOf<T1, T2, T3>(T2 value)
        => new()
        {
            Value = value
        };

    public static implicit operator OneOf<T1, T2, T3>(T3 value)
        => new()
        {
            Value = value
        };
}

public class OneOf<T1, T2, T3, T4> : OneOf
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
    where T4 : notnull
{
    public static implicit operator OneOf<T1, T2, T3, T4>(T1 value)
        => new()
        {
            Value = value
        };

    public static implicit operator OneOf<T1, T2, T3, T4>(T2 value)
        => new()
        {
            Value = value
        };

    public static implicit operator OneOf<T1, T2, T3, T4>(T3 value)
        => new()
        {
            Value = value
        };

    public static implicit operator OneOf<T1, T2, T3, T4>(T4 value)
        => new()
        {
            Value = value
        };
}

public class OneOf<T1, T2, T3, T4, T5> : OneOf
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
    where T4 : notnull
    where T5 : notnull
{
    public static implicit operator OneOf<T1, T2, T3, T4, T5>(T1 value)
        => new()
        {
            Value = value
        };

    public static implicit operator OneOf<T1, T2, T3, T4, T5>(T2 value)
        => new()
        {
            Value = value
        };

    public static implicit operator OneOf<T1, T2, T3, T4, T5>(T3 value)
        => new()
        {
            Value = value
        };

    public static implicit operator OneOf<T1, T2, T3, T4, T5>(T4 value)
        => new()
        {
            Value = value
        };

    public static implicit operator OneOf<T1, T2, T3, T4, T5>(T5 value)
        => new()
        {
            Value = value
        };
}