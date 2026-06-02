// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public sealed partial class DigitalCredentialIssuanceProtocol
{
    private readonly string _value;

    private DigitalCredentialIssuanceProtocol(string value)
    {
        _value = value;
    }

    public static readonly DigitalCredentialIssuanceProtocol Openid4vci_v1 = new("openid4vci-v1");

    public override string ToString() => _value;

    public static DigitalCredentialIssuanceProtocol Create(string value) => value switch
    {
        "openid4vci-v1" => Openid4vci_v1,
        _ => throw new ArgumentException($"Invalid value \"{value}\" for DigitalCredentialIssuanceProtocol", nameof(value)),
    };
}

#nullable disable