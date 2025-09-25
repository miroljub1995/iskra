using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public record MaplikeDeclarationMemberType : DeclarationMemberType
{
    [JsonPropertyName("readonly")] public required bool Readonly { get; set; }
}