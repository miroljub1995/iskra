using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public record AsyncIterableMemberType : IDLInterfaceMemberType
{
    [JsonPropertyName("async")] public required bool Async { get; set; }

    [JsonPropertyName("idlType")] public required List<IDLTypeDescription> IdlType { get; set; }

    [JsonPropertyName("arguments")] public required List<Argument> Arguments { get; set; }
}