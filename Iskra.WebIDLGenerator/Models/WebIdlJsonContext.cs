using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

[JsonSourceGenerationOptions(AllowOutOfOrderMetadataProperties = true)]
[JsonSerializable(typeof(IDLModule))]
[JsonSerializable(typeof(UnionTypeDescription))]
[JsonSerializable(typeof(NonUnionTypeDescription))]
public partial class WebIdlJsonContext : JsonSerializerContext
{
}