using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class ExtendedAttributeRightHandSideInteger : ExtendedAttributeRightHandSide
{
    [JsonPropertyName("value")] public required string Value { get; set; }
}