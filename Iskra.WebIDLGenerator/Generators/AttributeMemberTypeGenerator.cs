using Iskra.StdWebGenerator.GeneratorContexts;
using Iskra.WebIDLGenerator.Extensions;
using Iskra.WebIDLGenerator.Models;

namespace Iskra.WebIDLGenerator.Generators;

public class AttributeMemberTypeGenerator(
    GenTypeDescriptors descriptors,
    IDLTypeDescriptionToTypeDeclarationGenerator descriptionToTypeDeclarationGenerator,
    GetPropertyValueGenerator getPropertyValueGenerator,
    SetPropertyValueGenerator setPropertyValueGenerator,
    GeneratorContext generatorContext
)
{
    public string Generate(AttributeMemberType input, string containingTypeName)
    {
        List<string> bodyParts = [];

        var isStatic = input.Special == AttributeSpecial.Static;
        var staticKeyword = isStatic ? " static" : "";
        var newKeyword = HidesAccessibleMember(input, containingTypeName, isStatic) ? " new" : "";

        var name = GetValidPropertyName(input.Name, containingTypeName);

        var returnTypeDeclaration = descriptionToTypeDeclarationGenerator.Generate(input.IdlType);

        // Getter
        {
            var inputVar = isStatic
                ? "global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsConstructorProxy" +
                  $"(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, \"{containingTypeName}\")"
                : "JSObject";

            var returnValueVar = generatorContext.GetNextVariableName("res");

            var getPropertyValue = getPropertyValueGenerator.Generate(
                inputVar: inputVar,
                type: input.IdlType,
                propertyNameVar: $"\"{input.Name}\"",
                outputVar: returnValueVar
            );

            var getter = $$"""
                           get
                           {
                               {{returnTypeDeclaration}} {{returnValueVar}};
                           {{getPropertyValue.IndentLines(4)}}
                               return {{returnValueVar}};
                           }
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

            var setPropertyValue = setPropertyValueGenerator.Generate(
                inputVar: inputVar,
                valueVar: "value",
                type: input.IdlType,
                propertyNameVar: $"\"{input.Name}\""
            );

            var setter = $$"""
                           set
                           {
                           {{setPropertyValue.IndentLines(4)}}
                           }
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