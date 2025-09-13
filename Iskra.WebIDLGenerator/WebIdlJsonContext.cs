using System.Text.Json.Serialization;
using Iskra.WebIDLGenerator.Models;

[JsonSourceGenerationOptions(AllowOutOfOrderMetadataProperties = true)]
[JsonSerializable(typeof(IDLModule))]
[JsonSerializable(typeof(UnionTypeDescription))]
[JsonSerializable(typeof(NonUnionTypeDescription))]
public partial class WebIdlJsonContext : JsonSerializerContext
{
}