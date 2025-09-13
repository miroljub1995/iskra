using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "generic")]
[JsonDerivedType(typeof(SingleTypeDescription), "")]
[JsonDerivedType(typeof(FrozenArrayTypeDescription), "FrozenArray")]
[JsonDerivedType(typeof(ObservableArrayTypeDescription), "ObservableArray")]
[JsonDerivedType(typeof(PromiseTypeDescription), "Promise")]
[JsonDerivedType(typeof(RecordTypeDescription), "record")]
[JsonDerivedType(typeof(SequenceTypeDescription), "sequence")]
public abstract class NonUnionTypeDescription : IDLTypeDescription
{
}