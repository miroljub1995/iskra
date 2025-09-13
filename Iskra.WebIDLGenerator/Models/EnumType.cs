using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class EnumType : IDLRootType
{
    [JsonPropertyName("name")] public required string Name { get; set; }

    [JsonPropertyName("values")] public required List<EnumValue> Values { get; set; }
}