using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class ExtendedAttribute
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("arguments")]
    public required List<Argument> Arguments { get; set; }

    [JsonPropertyName("rhs")]
    public required ExtendedAttributeRightHandSide? Rhs { get; set; }
}