using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class ValueDescriptionInfinity : ValueDescription
{
    [JsonPropertyName("negative")] public required bool Negative { get; set; }
}