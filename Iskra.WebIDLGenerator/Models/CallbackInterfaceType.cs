using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class CallbackInterfaceType : AbstractContainer
{
    [JsonPropertyName("members")] public required List<IDLCallbackInterfaceMemberType> Members { get; set; }

    [JsonPropertyName("inheritance")] public object? Inheritance { get; set; } = null;
}