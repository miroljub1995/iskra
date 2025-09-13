using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class ValueDescriptionBoolean : ValueDescription
{
    [JsonPropertyName("value")] public required bool Value { get; set; }
}