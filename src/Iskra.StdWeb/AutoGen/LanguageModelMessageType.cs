// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public sealed partial class LanguageModelMessageType
{
    private readonly string _value;

    private LanguageModelMessageType(string value)
    {
        _value = value;
    }

    public static readonly LanguageModelMessageType Text = new("text");
    public static readonly LanguageModelMessageType Image = new("image");
    public static readonly LanguageModelMessageType Audio = new("audio");
    public static readonly LanguageModelMessageType Tool_call = new("tool-call");
    public static readonly LanguageModelMessageType Tool_response = new("tool-response");

    public override string ToString() => _value;

    public static LanguageModelMessageType Create(string value) => value switch
    {
        "text" => Text,
        "image" => Image,
        "audio" => Audio,
        "tool-call" => Tool_call,
        "tool-response" => Tool_response,
        _ => throw new ArgumentException($"Invalid value \"{value}\" for LanguageModelMessageType", nameof(value)),
    };
}

#nullable disable