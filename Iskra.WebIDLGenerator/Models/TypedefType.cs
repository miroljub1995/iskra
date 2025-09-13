using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class TypedefType : IDLRootType
{
    [JsonPropertyName("name")] public required string Name { get; set; }

    [JsonPropertyName("idlType")] public required IDLTypeDescription IdlType { get; set; }
}