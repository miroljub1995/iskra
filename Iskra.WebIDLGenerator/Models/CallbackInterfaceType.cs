using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public record CallbackInterfaceType : AbstractContainer
{
    [JsonPropertyName("members")] public required List<IDLCallbackInterfaceMemberType> Members { get; set; }
}