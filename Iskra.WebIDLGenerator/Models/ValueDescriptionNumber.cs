using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class ValueDescriptionNumber : ValueDescription
{
    [JsonPropertyName("value")] public required string Value { get; set; }
}