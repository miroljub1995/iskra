using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(ValueDescriptionString), "string")]
[JsonDerivedType(typeof(ValueDescriptionNumber), "number")]
[JsonDerivedType(typeof(ValueDescriptionBoolean), "boolean")]
[JsonDerivedType(typeof(ValueDescriptionNull), "null")]
[JsonDerivedType(typeof(ValueDescriptionInfinity), "Infinity")]
[JsonDerivedType(typeof(ValueDescriptionNaN), "NaN")]
[JsonDerivedType(typeof(ValueDescriptionSequence), "sequence")]
[JsonDerivedType(typeof(ValueDescriptionDictionary), "dictionary")]
public abstract class ValueDescription : AbstractBase
{
}