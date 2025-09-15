using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public record GenSettings
{
    [JsonPropertyName("input")] public required string Input { get; set; }

    [JsonPropertyName("output")] public required string Output { get; set; }

    [JsonPropertyName("namespace")] public required string Namespace { get; set; }

    [JsonPropertyName("typeRewrite")] public required Dictionary<string, string> TypeRewrite { get; set; }
}