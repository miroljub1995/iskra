using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public abstract class DeclarationMemberType : IDLInterfaceMemberType
{
    [JsonPropertyName("idlType")] public required List<IDLTypeDescription> IdlType { get; set; }
}