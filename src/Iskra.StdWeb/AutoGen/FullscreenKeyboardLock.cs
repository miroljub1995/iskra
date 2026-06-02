// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public sealed partial class FullscreenKeyboardLock
{
    private readonly string _value;

    private FullscreenKeyboardLock(string value)
    {
        _value = value;
    }

    public static readonly FullscreenKeyboardLock Browser = new("browser");
    public static readonly FullscreenKeyboardLock None = new("none");

    public override string ToString() => _value;

    public static FullscreenKeyboardLock Create(string value) => value switch
    {
        "browser" => Browser,
        "none" => None,
        _ => throw new ArgumentException($"Invalid value \"{value}\" for FullscreenKeyboardLock", nameof(value)),
    };
}

#nullable disable