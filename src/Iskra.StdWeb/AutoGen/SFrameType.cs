// ReSharper disable All

namespace Iskra.StdWeb;

#nullable enable

public sealed partial class SFrameType
{
    private readonly string _value;

    private SFrameType(string value)
    {
        _value = value;
    }

    public static readonly SFrameType Per_frame = new("per-frame");
    public static readonly SFrameType Per_packet = new("per-packet");

    public override string ToString() => _value;

    public static SFrameType Create(string value) => value switch
    {
        "per-frame" => Per_frame,
        "per-packet" => Per_packet,
        _ => throw new ArgumentException($"Invalid value \"{value}\" for SFrameType", nameof(value)),
    };
}

#nullable disable