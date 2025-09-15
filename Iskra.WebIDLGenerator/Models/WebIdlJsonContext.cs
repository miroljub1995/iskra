using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

[JsonSourceGenerationOptions(AllowOutOfOrderMetadataProperties = true)]
[JsonSerializable(typeof(IDLModule))]
[JsonSerializable(typeof(UnionTypeDescription))]
[JsonSerializable(typeof(NonUnionTypeDescription))]
[JsonSerializable(typeof(GenSettings))]
public partial class WebIdlJsonContext : JsonSerializerContext
{
}