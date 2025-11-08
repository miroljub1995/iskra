using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class ValueDescriptionString : ValueDescription
{
    [JsonPropertyName("value")] public required string Value { get; set; }
}