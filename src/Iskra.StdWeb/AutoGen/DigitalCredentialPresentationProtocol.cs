// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public sealed partial class DigitalCredentialPresentationProtocol
{
    private readonly string _value;

    private DigitalCredentialPresentationProtocol(string value)
    {
        _value = value;
    }

    public static readonly DigitalCredentialPresentationProtocol Openid4vp_v1_unsigned = new("openid4vp-v1-unsigned");
    public static readonly DigitalCredentialPresentationProtocol Openid4vp_v1_signed = new("openid4vp-v1-signed");
    public static readonly DigitalCredentialPresentationProtocol Openid4vp_v1_multisigned = new("openid4vp-v1-multisigned");
    public static readonly DigitalCredentialPresentationProtocol Org_iso_mdoc = new("org-iso-mdoc");

    public override string ToString() => _value;

    public static DigitalCredentialPresentationProtocol Create(string value) => value switch
    {
        "openid4vp-v1-unsigned" => Openid4vp_v1_unsigned,
        "openid4vp-v1-signed" => Openid4vp_v1_signed,
        "openid4vp-v1-multisigned" => Openid4vp_v1_multisigned,
        "org-iso-mdoc" => Org_iso_mdoc,
        _ => throw new ArgumentException($"Invalid value \"{value}\" for DigitalCredentialPresentationProtocol", nameof(value)),
    };
}

#nullable disable