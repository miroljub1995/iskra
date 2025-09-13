using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class FieldType : AbstractBase
{
    [JsonPropertyName("name")] public required string Name { get; set; }

    [JsonPropertyName("required")] public required bool Required { get; set; }

    [JsonPropertyName("idlType")] public required IDLTypeDescription IdlType { get; set; }

    [JsonPropertyName("default")] public required ValueDescription? Default { get; set; }
}