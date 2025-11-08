using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public record FrozenArrayTypeDescription : NonUnionTypeDescription
{
    [JsonPropertyName("idlType")] public required List<IDLTypeDescription> IdlType { get; set; }
}