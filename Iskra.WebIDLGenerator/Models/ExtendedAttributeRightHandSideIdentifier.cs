using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class ExtendedAttributeRightHandSideIdentifier : ExtendedAttributeRightHandSide
{
    [JsonPropertyName("value")] public required string Value { get; set; }
}