using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class ConstantMemberType : AbstractBase
{
    [JsonPropertyName("nullable")] public required bool Nullable { get; set; }

    [JsonPropertyName("idlType")] public required IDLTypeDescription IdlType { get; set; }

    [JsonPropertyName("name")] public required string Name { get; set; }

    [JsonPropertyName("value")] public required ValueDescription Value { get; set; }
}