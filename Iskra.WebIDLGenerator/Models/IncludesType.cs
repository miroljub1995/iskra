using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class IncludesType : IDLRootType
{
    [JsonPropertyName("target")] public required string Target { get; set; }

    [JsonPropertyName("includes")] public required string Includes { get; set; }
}