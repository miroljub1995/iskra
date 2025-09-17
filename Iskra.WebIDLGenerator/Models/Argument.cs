using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class Argument : AbstractBase
{
    [JsonPropertyName("default")] public required ValueDescription? Default { get; set; }

    [JsonPropertyName("optional")] public required bool Optional { get; set; }

    [JsonPropertyName("variadic")] public required bool Variadic { get; set; }

    [JsonPropertyName("idlType")] public required IDLTypeDescription IdlType { get; set; }

    [JsonPropertyName("name")] public required string Name { get; set; }

    public string ValidCSharpName => Name switch
    {
        "event" => "@event",
        "params" => "@params",
        "lock" => "@lock",
        _ => Name
    };
}