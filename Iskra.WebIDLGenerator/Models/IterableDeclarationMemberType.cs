using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class IterableDeclarationMemberType : DeclarationMemberType
{
    [JsonPropertyName("async")] public required bool Async { get; set; }

    [JsonPropertyName("arguments")] public required List<Argument> Arguments { get; set; }
}