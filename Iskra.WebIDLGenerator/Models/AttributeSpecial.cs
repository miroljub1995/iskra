using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

[JsonConverter(typeof(JsonStringEnumConverter<AttributeSpecial>))]
public enum AttributeSpecial
{
    [JsonStringEnumMemberName("static")] Static,

    [JsonStringEnumMemberName("stringifier")]
    Stringifier
}