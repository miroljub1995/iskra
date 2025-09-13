using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class EnumValue
{
    [JsonPropertyName("value")] public required string Value { get; set; }
}