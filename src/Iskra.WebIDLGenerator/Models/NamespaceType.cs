using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public record NamespaceType : AbstractContainer
{
    [JsonPropertyName("members")] public required List<IDLNamespaceMemberType> Members { get; set; }
}