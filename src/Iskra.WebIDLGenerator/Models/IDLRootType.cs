using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(CallbackType), "callback")]
[JsonDerivedType(typeof(CallbackInterfaceType), "callback interface")]
[JsonDerivedType(typeof(DictionaryType), "dictionary")]
[JsonDerivedType(typeof(EnumType), "enum")]
[JsonDerivedType(typeof(IncludesType), "includes")]
[JsonDerivedType(typeof(InterfaceMixinType), "interface mixin")]
[JsonDerivedType(typeof(InterfaceType), "interface")]
[JsonDerivedType(typeof(NamespaceType), "namespace")]
[JsonDerivedType(typeof(TypedefType), "typedef")]
public abstract record IDLRootType : AbstractBase
{
}