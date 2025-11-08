using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public record SingleTypeDescription : NonUnionTypeDescription
{
    [JsonPropertyName("idlType")] public required string IdlType { get; set; }
}