using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public record CallbackType : IDLRootType
{
    [JsonPropertyName("name")] public required string Name { get; set; }

    [JsonPropertyName("idlType")] public required IDLTypeDescription IdlType { get; set; }

    [JsonPropertyName("arguments")] public required List<Argument> Arguments { get; set; }
}