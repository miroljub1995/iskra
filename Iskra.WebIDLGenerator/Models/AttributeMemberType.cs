using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class AttributeMemberType : AbstractBase
{
    [JsonPropertyName("name")] public required string Name { get; set; }

    [JsonPropertyName("special")] public required AttributeSpecial? Special { get; set; }

    [JsonPropertyName("inherit")] public required bool Inherit { get; set; }

    [JsonPropertyName("readonly")] public required bool Readonly { get; set; }

    [JsonPropertyName("idlType")] public required IDLTypeDescription IdlType { get; set; }
}