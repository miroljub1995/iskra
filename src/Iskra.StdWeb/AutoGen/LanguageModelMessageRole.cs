// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public sealed partial class LanguageModelMessageRole
{
    private readonly string _value;

    private LanguageModelMessageRole(string value)
    {
        _value = value;
    }

    public static readonly LanguageModelMessageRole System = new("system");
    public static readonly LanguageModelMessageRole User = new("user");
    public static readonly LanguageModelMessageRole Assistant = new("assistant");

    public override string ToString() => _value;

    public static LanguageModelMessageRole Create(string value) => value switch
    {
        "system" => System,
        "user" => User,
        "assistant" => Assistant,
        _ => throw new ArgumentException($"Invalid value \"{value}\" for LanguageModelMessageRole", nameof(value)),
    };
}

#nullable disable