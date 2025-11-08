using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public abstract record DeclarationMemberType : IDLInterfaceMemberType
{
    [JsonPropertyName("idlType")] public required List<IDLTypeDescription> IdlType { get; set; }
}