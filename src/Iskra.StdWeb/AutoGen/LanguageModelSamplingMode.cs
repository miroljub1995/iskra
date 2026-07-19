// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public sealed partial class LanguageModelSamplingMode
{
    private readonly string _value;

    private LanguageModelSamplingMode(string value)
    {
        _value = value;
    }

    public static readonly LanguageModelSamplingMode Most_predictable = new("most-predictable");
    public static readonly LanguageModelSamplingMode Predictable = new("predictable");
    public static readonly LanguageModelSamplingMode Balanced = new("balanced");
    public static readonly LanguageModelSamplingMode Creative = new("creative");
    public static readonly LanguageModelSamplingMode Most_creative = new("most-creative");

    public override string ToString() => _value;

    public static LanguageModelSamplingMode Create(string value) => value switch
    {
        "most-predictable" => Most_predictable,
        "predictable" => Predictable,
        "balanced" => Balanced,
        "creative" => Creative,
        "most-creative" => Most_creative,
        _ => throw new ArgumentException($"Invalid value \"{value}\" for LanguageModelSamplingMode", nameof(value)),
    };
}

#nullable disable