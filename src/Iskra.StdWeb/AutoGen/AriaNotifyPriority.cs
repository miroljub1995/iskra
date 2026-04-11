// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public sealed partial class AriaNotifyPriority
{
    private readonly string _value;

    private AriaNotifyPriority(string value)
    {
        _value = value;
    }

    public static readonly AriaNotifyPriority Normal = new("normal");
    public static readonly AriaNotifyPriority High = new("high");

    public override string ToString() => _value;

    public static AriaNotifyPriority Create(string value) => value switch
    {
        "normal" => Normal,
        "high" => High,
        _ => throw new ArgumentException($"Invalid value \"{value}\" for AriaNotifyPriority", nameof(value)),
    };
}

#nullable disable