using System.Text.Json;
using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

[JsonConverter(typeof(IDLTypeDescriptionConverter))]
public abstract class IDLTypeDescription : AbstractBase
{
    [JsonPropertyName("nullable")] public required bool Nullable { get; set; }

    public class IDLTypeDescriptionConverter : JsonConverter<IDLTypeDescription>
    {
        public override IDLTypeDescription? Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            var root = doc.RootElement;

            var isUnion = root.TryGetProperty("union", out var u) && u.GetBoolean();

            var idlTypeDescription = (isUnion
                ? root.Deserialize(typeof(UnionTypeDescription), WebIdlJsonContext.Default)
                : root.Deserialize(typeof(NonUnionTypeDescription), WebIdlJsonContext.Default)) as IDLTypeDescription;

            return idlTypeDescription;
        }

        public override void Write(Utf8JsonWriter writer, IDLTypeDescription value, JsonSerializerOptions options)
        {
            throw new NotSupportedException();
        }
    }
}