using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class RecordTypeDescription : NonUnionTypeDescription
{
    [JsonPropertyName("idlType")] public required List<IDLTypeDescription> IdlType { get; set; }
}