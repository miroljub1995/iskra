using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class SetlikeDeclarationMemberType : DeclarationMemberType
{
    [JsonPropertyName("readonly")] public required bool Readonly { get; set; }
}