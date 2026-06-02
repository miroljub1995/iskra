// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public sealed partial class YamlLdErrorCode
{
    private readonly string _value;

    private YamlLdErrorCode(string value)
    {
        _value = value;
    }

    public static readonly YamlLdErrorCode Invalid_encoding = new("invalid-encoding");
    public static readonly YamlLdErrorCode Mapping_key_error = new("mapping-key-error");
    public static readonly YamlLdErrorCode Profile_error = new("profile-error");

    public override string ToString() => _value;

    public static YamlLdErrorCode Create(string value) => value switch
    {
        "invalid-encoding" => Invalid_encoding,
        "mapping-key-error" => Mapping_key_error,
        "profile-error" => Profile_error,
        _ => throw new ArgumentException($"Invalid value \"{value}\" for YamlLdErrorCode", nameof(value)),
    };
}

#nullable disable