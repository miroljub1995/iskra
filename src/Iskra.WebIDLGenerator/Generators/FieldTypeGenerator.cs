using Iskra.WebIDLGenerator.Extensions;
using Iskra.WebIDLGenerator.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Iskra.WebIDLGenerator.Generators;

public class FieldTypeGenerator(
    IServiceProvider provider
)
{
    public string Generate(FieldType input)
    {
        var descriptionToTypeDeclarationGenerator =
            provider.GetRequiredService<IDLTypeDescriptionToTypeDeclarationGenerator>();
        var propertyAccessorGenerator = provider.GetRequiredService<PropertyAccessorGenerator>();

        var requiredKeyword = input.Required ? " required" : "";
        var returnTypeDeclaration = descriptionToTypeDeclarationGenerator.Generate(input.IdlType);

        var accessor = propertyAccessorGenerator.GetOrCreateAccessor(input.IdlType);

        var getter = $$"""
                       get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<{{returnTypeDeclaration}}, {{accessor}}>(JSObject, "{{input.Name}}");
                       """;

        var setter = $$"""
                       set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<{{returnTypeDeclaration}}, {{accessor}}>(JSObject, "{{input.Name}}", value);
                       """;

        var content = $$"""
                        public{{requiredKeyword}} {{returnTypeDeclaration}} {{input.Name.CapitalizeFirstLetter()}}
                        {
                        {{getter.IndentLines(4)}}
                        {{setter.IndentLines(4)}}
                        }
                        """;

        return content;
    }
}