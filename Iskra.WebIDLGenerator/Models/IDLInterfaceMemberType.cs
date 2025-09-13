using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(AttributeMemberType), "attribute")]
[JsonDerivedType(typeof(ConstantMemberType), "const")]
[JsonDerivedType(typeof(ConstructorMemberType), "constructor")]
[JsonDerivedType(typeof(IterableDeclarationMemberType), "iterable")]
[JsonDerivedType(typeof(MaplikeDeclarationMemberType), "maplike")]
[JsonDerivedType(typeof(SetlikeDeclarationMemberType), "setlike")]
[JsonDerivedType(typeof(OperationMemberType), "operation")]
public abstract class IDLInterfaceMemberType : AbstractBase
{
}