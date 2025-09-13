using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "union")]
[JsonDerivedType(typeof(UnionTypeDescription), "true")]
[JsonDerivedType(typeof(NonUnionTypeDescription), "false")]
public abstract class IDLTypeDescription : AbstractBase
{
    [JsonPropertyName("nullable")] public required bool Nullable { get; set; }

    // public class IDLTypeDescriptionConverter : JsonConverter<IDLTypeDescription>
    // {
    //     public override IDLTypeDescription? Read(ref Utf8JsonReader reader, Type typeToConvert,
    //         JsonSerializerOptions options)
    //     {
    //         using var doc = JsonDocument.ParseValue(ref reader);
    //         var root = doc.RootElement;
    //
    //         if (root.TryGetProperty("union", out var unionProp) && unionProp.ValueKind == JsonValueKind.True)
    //         {
    //             return JsonSerializer.Deserialize<UnionTypeDescription>(root.GetRawText(), options);
    //         }
    //
    //         // default: union = false
    //         return JsonSerializer.Deserialize<NonUnionTypeDescription>(root.GetRawText(), options);
    //     }
    //
    //     public override void Write(Utf8JsonWriter writer, IDLTypeDescription value, JsonSerializerOptions options)
    //     {
    //         JsonSerializer.Serialize(writer, (object)value, options);
    //     }
    // }
}