using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class ExtendedAttributeRightHandSideIntegerList : ExtendedAttributeRightHandSide
{
    [JsonPropertyName("value")] public required List<ExtendedAttributeRightHandSideInteger> Value { get; set; }
}