using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public record InterfaceType : AbstractContainer
{
    [JsonPropertyName("members")] public required List<IDLInterfaceMemberType> Members { get; set; }

    [JsonPropertyName("inheritance")] public required string? Inheritance { get; set; }
}