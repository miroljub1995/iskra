using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public class IDLParsed
{
    [JsonPropertyName("idlNames")] public required Dictionary<string, IDLRootType> IDLNames { get; set; }

    [JsonPropertyName("idlExtendedNames")]
    public required Dictionary<string, List<IDLRootType>> IDLExtendedNames { get; set; }
}