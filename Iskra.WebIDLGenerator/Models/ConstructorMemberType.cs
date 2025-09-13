using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class ConstructorMemberType : IDLInterfaceMemberType
{
    [JsonPropertyName("arguments")] public required List<Argument> Arguments { get; set; }
}