using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(ConstantMemberType), "const")]
[JsonDerivedType(typeof(OperationMemberType), "operation")]
public abstract class IDLCallbackInterfaceMemberType : AbstractBase
{
}