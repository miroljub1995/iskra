// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public sealed partial class SecurePaymentConfirmationCapability
{
    private readonly string _value;

    private SecurePaymentConfirmationCapability(string value)
    {
        _value = value;
    }

    public static readonly SecurePaymentConfirmationCapability BrowserBoundKeyHardware = new("browserBoundKeyHardware");

    public override string ToString() => _value;

    public static SecurePaymentConfirmationCapability Create(string value) => value switch
    {
        "browserBoundKeyHardware" => BrowserBoundKeyHardware,
        _ => throw new ArgumentException($"Invalid value \"{value}\" for SecurePaymentConfirmationCapability", nameof(value)),
    };
}

#nullable disable