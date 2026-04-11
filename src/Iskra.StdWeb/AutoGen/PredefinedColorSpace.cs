// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public sealed partial class PredefinedColorSpace
{
    private readonly string _value;

    private PredefinedColorSpace(string value)
    {
        _value = value;
    }

    public static readonly PredefinedColorSpace Srgb = new("srgb");
    public static readonly PredefinedColorSpace Srgb_linear = new("srgb-linear");
    public static readonly PredefinedColorSpace Display_p3 = new("display-p3");
    public static readonly PredefinedColorSpace Display_p3_linear = new("display-p3-linear");

    public override string ToString() => _value;

    public static PredefinedColorSpace Create(string value) => value switch
    {
        "srgb" => Srgb,
        "srgb-linear" => Srgb_linear,
        "display-p3" => Display_p3,
        "display-p3-linear" => Display_p3_linear,
        _ => throw new ArgumentException($"Invalid value \"{value}\" for PredefinedColorSpace", nameof(value)),
    };
}

#nullable disable