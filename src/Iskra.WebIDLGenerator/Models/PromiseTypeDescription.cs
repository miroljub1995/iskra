using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public record PromiseTypeDescription : NonUnionTypeDescription
{
    [JsonPropertyName("idlType")] public required List<IDLTypeDescription> IdlType { get; set; }
}