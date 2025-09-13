using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class IDLModule
{
    [JsonPropertyName("idlparsed")] public required IDLParsed IDLParsed { get; set; }
}