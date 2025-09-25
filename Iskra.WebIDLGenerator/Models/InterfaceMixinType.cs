using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public record InterfaceMixinType : AbstractContainer
{
    [JsonPropertyName("members")] public required List<IDLInterfaceMixinMemberType> Members { get; set; }
}