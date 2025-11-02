using Iskra.WebIDLGenerator.Extensions;
using Iskra.WebIDLGenerator.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Iskra.WebIDLGenerator.Generators;

public class AttributeMemberTypeGenerator(
    IServiceProvider provider,
    GenTypeDescriptors descriptors
)
{
    public string Generate(AttributeMemberType input, string containingTypeName)
    {
        var descriptionToTypeDeclarationGenerator =
            provider.GetRequiredService<IDLTypeDescriptionToTypeDeclarationGenerator>();
        var propertyAccessorGenerator = provider.GetRequiredService<PropertyAccessorGenerator>();

        List<string> bodyParts = [];

        var isStatic = input.Special == AttributeSpecial.Static;
        var staticKeyword = isStatic ? " static" : "";
        var newKeyword = HidesAccessibleMember(input, containingTypeName, isStatic) ? " new" : "";

        var name = GetValidPropertyName(input.Name, containingTypeName);

        var returnTypeDeclaration = descriptionToTypeDeclarationGenerator.Generate(input.IdlType);

        var accessor = propertyAccessorGenerator.GetOrCreateAccessor(input.IdlType);

        // Getter
        {
            var inputVar = isStatic
                ? "global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsConstructorProxy" +
                  $"(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, \"{containingTypeName}\")"
                : "JSObject";

            var getter = $$"""
                           get => global::Iskra.JSCore.Generics.PropertyAccessor.Get<{{returnTypeDeclaration}}, {{accessor}}>({{inputVar}}, "{{input.Name}}");
                           """;

            bodyParts.Add(getter);
        }

        // Setter
        if (!input.Readonly)
        {
            var inputVar = isStatic
                ? "global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsConstructorProxy" +
                  $"(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, \"{containingTypeName}\")"
                : "JSObject";

            var setter = $$"""
                           set => global::Iskra.JSCore.Generics.PropertyAccessor.Set<{{returnTypeDeclaration}}, {{accessor}}>({{inputVar}}, "{{input.Name}}", value);
                           """;

            bodyParts.Add(setter);
        }

        var body = string.Join("\n", bodyParts);

        var content = $$"""
                        public{{staticKeyword}}{{newKeyword}} {{returnTypeDeclaration}} {{name}}
                        {
                        {{body.IndentLines(4)}}
                        }
                        """;

        return content;
    }

    private static string GetValidPropertyName(string name, string containingTypeName)
    {
        name = name.Replace('-', '_').CapitalizeFirstLetter();
        if (name == containingTypeName)
        {
            name += "_";
        }

        return name;
    }

    private bool HidesAccessibleMember(AttributeMemberType input, string containingTypeName, bool isStatic)
    {
        if (!descriptors.TryGet(containingTypeName, out var desc))
        {
            return false;
        }

        if (desc.RootType is not InterfaceType interfaceType)
        {
            return false;
        }

        if (interfaceType.Inheritance is null)
        {
            return false;
        }

        return TypeHasProperty(interfaceType.Inheritance, input.Name, isStatic);
    }

    private bool TypeHasProperty(string typeName, string propertyName, bool isStatic)
    {
        if (!descriptors.TryGet(typeName, out var desc))
        {
            return false;
        }

        if (desc.RootType is not InterfaceType interfaceType)
        {
            return false;
        }

        if (interfaceType.Members.Any(x =>
                x is AttributeMemberType attr && (isStatic && attr.Special == AttributeSpecial.Static ||
                                                  !isStatic && attr.Special != AttributeSpecial.Static) &&
                attr.Name == propertyName))
        {
            return true;
        }

        if (interfaceType.Inheritance is not null)
        {
            return TypeHasProperty(interfaceType.Inheritance, propertyName, isStatic);
        }

        return false;
    }
}