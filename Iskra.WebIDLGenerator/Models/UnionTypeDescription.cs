using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class UnionTypeDescription : IDLTypeDescription
{
    [JsonPropertyName("idlType")] public required List<IDLTypeDescription> IdlType { get; set; }
}