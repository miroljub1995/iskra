// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public sealed partial class PerformanceTimingConfidenceValue
{
    private readonly string _value;

    private PerformanceTimingConfidenceValue(string value)
    {
        _value = value;
    }

    public static readonly PerformanceTimingConfidenceValue High = new("high");
    public static readonly PerformanceTimingConfidenceValue Low = new("low");

    public override string ToString() => _value;

    public static PerformanceTimingConfidenceValue Create(string value) => value switch
    {
        "high" => High,
        "low" => Low,
        _ => throw new ArgumentException($"Invalid value \"{value}\" for PerformanceTimingConfidenceValue", nameof(value)),
    };
}

#nullable disable