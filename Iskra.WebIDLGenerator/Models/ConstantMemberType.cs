using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class ConstantMemberType : IDLInterfaceMemberType
{
    [JsonPropertyName("idlType")] public required IDLTypeDescription IdlType { get; set; }

    [JsonPropertyName("name")] public required string Name { get; set; }

    [JsonPropertyName("value")] public required ValueDescription Value { get; set; }
}