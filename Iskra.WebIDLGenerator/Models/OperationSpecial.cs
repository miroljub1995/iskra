using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

[JsonConverter(typeof(JsonStringEnumConverter<OperationSpecial>))]
public enum OperationSpecial
{
    [JsonStringEnumMemberName("getter")] Getter,

    [JsonStringEnumMemberName("setter")] Setter,

    [JsonStringEnumMemberName("deleter")] Deleter,

    [JsonStringEnumMemberName("static")] Static,

    [JsonStringEnumMemberName("stringifier")]
    Stringifier
}