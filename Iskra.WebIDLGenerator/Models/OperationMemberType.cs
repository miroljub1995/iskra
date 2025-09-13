using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class OperationMemberType : AbstractBase
{
    [JsonPropertyName("special")] public required OperationSpecial? Special { get; set; }

    [JsonPropertyName("idlType")] public required IDLTypeDescription? IdlType { get; set; }

    [JsonPropertyName("name")] public required string? Name { get; set; }

    [JsonPropertyName("arguments")] public required List<Argument> Arguments { get; set; }
}