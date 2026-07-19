// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public sealed partial class CorrectionType
{
    private readonly string _value;

    private CorrectionType(string value)
    {
        _value = value;
    }

    public static readonly CorrectionType Spelling = new("spelling");
    public static readonly CorrectionType Punctuation = new("punctuation");
    public static readonly CorrectionType Capitalization = new("capitalization");
    public static readonly CorrectionType Grammar = new("grammar");

    public override string ToString() => _value;

    public static CorrectionType Create(string value) => value switch
    {
        "spelling" => Spelling,
        "punctuation" => Punctuation,
        "capitalization" => Capitalization,
        "grammar" => Grammar,
        _ => throw new ArgumentException($"Invalid value \"{value}\" for CorrectionType", nameof(value)),
    };
}

#nullable disable