using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class OperationMemberType : IDLInterfaceMemberType
{
    [JsonPropertyName("special")] public required string? Special { get; set; }

    [JsonPropertyName("idlType")] public IDLTypeDescription? IdlType { get; set; } = null;

    [JsonPropertyName("name")] public required string? Name { get; set; }

    [JsonPropertyName("arguments")] public required List<Argument> Arguments { get; set; }
}