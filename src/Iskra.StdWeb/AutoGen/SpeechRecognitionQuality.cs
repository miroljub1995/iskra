// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public sealed partial class SpeechRecognitionQuality
{
    private readonly string _value;

    private SpeechRecognitionQuality(string value)
    {
        _value = value;
    }

    public static readonly SpeechRecognitionQuality Command = new("command");
    public static readonly SpeechRecognitionQuality Dictation = new("dictation");
    public static readonly SpeechRecognitionQuality Conversation = new("conversation");

    public override string ToString() => _value;

    public static SpeechRecognitionQuality Create(string value) => value switch
    {
        "command" => Command,
        "dictation" => Dictation,
        "conversation" => Conversation,
        _ => throw new ArgumentException($"Invalid value \"{value}\" for SpeechRecognitionQuality", nameof(value)),
    };
}

#nullable disable