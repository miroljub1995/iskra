using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(ExtendedAttributeRightHandSideIdentifier), "identifier")]
[JsonDerivedType(typeof(ExtendedAttributeRightHandSideIdentifierList), "identifier-list")]
[JsonDerivedType(typeof(ExtendedAttributeRightHandSideString), "string")]
[JsonDerivedType(typeof(ExtendedAttributeRightHandSideStringList), "string-list")]
[JsonDerivedType(typeof(ExtendedAttributeRightHandSideDecimal), "decimal")]
[JsonDerivedType(typeof(ExtendedAttributeRightHandSideDecimalList), "decimal-list")]
[JsonDerivedType(typeof(ExtendedAttributeRightHandSideInteger), "integer")]
[JsonDerivedType(typeof(ExtendedAttributeRightHandSideIntegerList), "integer-list")]
[JsonDerivedType(typeof(ExtendedAttributeRightHandSideWildCard), "*")]
public abstract class ExtendedAttributeRightHandSide
{
}