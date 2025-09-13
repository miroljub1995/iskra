using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class SingleTypeDescription : NonUnionTypeDescription
{
    [JsonPropertyName("idlType")] public required string IdlType { get; set; }
}