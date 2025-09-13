using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class InterfaceMixinType : AbstractContainer
{
    [JsonPropertyName("members")] public required List<IDLInterfaceMixinMemberType> Members { get; set; }
}