// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public sealed partial class AudioSelectionPreferenceEnum
{
    private readonly string _value;

    private AudioSelectionPreferenceEnum(string value)
    {
        _value = value;
    }

    public static readonly AudioSelectionPreferenceEnum Preferred = new("preferred");

    public override string ToString() => _value;

    public static AudioSelectionPreferenceEnum Create(string value) => value switch
    {
        "preferred" => Preferred,
        _ => throw new ArgumentException($"Invalid value \"{value}\" for AudioSelectionPreferenceEnum", nameof(value)),
    };
}

#nullable disable