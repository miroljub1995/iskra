// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public sealed partial class CredentialUiMode
{
    private readonly string _value;

    private CredentialUiMode(string value)
    {
        _value = value;
    }

    public static readonly CredentialUiMode Immediate = new("immediate");

    public override string ToString() => _value;

    public static CredentialUiMode Create(string value) => value switch
    {
        "immediate" => Immediate,
        _ => throw new ArgumentException($"Invalid value \"{value}\" for CredentialUiMode", nameof(value)),
    };
}

#nullable disable