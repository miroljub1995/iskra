// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public sealed partial class ConnectionAllowlistDisposition
{
    private readonly string _value;

    private ConnectionAllowlistDisposition(string value)
    {
        _value = value;
    }

    public static readonly ConnectionAllowlistDisposition Enforce = new("enforce");
    public static readonly ConnectionAllowlistDisposition Report = new("report");

    public override string ToString() => _value;

    public static ConnectionAllowlistDisposition Create(string value) => value switch
    {
        "enforce" => Enforce,
        "report" => Report,
        _ => throw new ArgumentException($"Invalid value \"{value}\" for ConnectionAllowlistDisposition", nameof(value)),
    };
}

#nullable disable