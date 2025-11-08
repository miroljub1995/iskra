using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public abstract record AbstractContainer : IDLRootType
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("partial")]
    public required bool Partial { get; set; }
}