using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public record DictionaryType : AbstractContainer
{
    [JsonPropertyName("members")] public required List<FieldType> Members { get; set; }

    [JsonPropertyName("inheritance")] public string? Inheritance { get; set; }
}