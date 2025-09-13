using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class AttributeMemberType : IDLInterfaceMemberType
{
    [JsonPropertyName("name")] public required string Name { get; set; }

    [JsonPropertyName("special")] public required string? Special { get; set; }

    [JsonPropertyName("readonly")] public required bool Readonly { get; set; }

    [JsonPropertyName("idlType")] public required IDLTypeDescription IdlType { get; set; }
}