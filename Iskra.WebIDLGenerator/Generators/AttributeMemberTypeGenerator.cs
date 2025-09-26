using Iskra.StdWebGenerator.GeneratorContexts;
using Iskra.WebIDLGenerator.Extensions;
using Iskra.WebIDLGenerator.Models;

namespace Iskra.WebIDLGenerator.Generators;

public class AttributeMemberTypeGenerator(
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

        var name = input.Name.Replace('-', '_').CapitalizeFirstLetter();
        if (name == containingTypeName)
        {
            name += "_";
        }

        var returnTypeDeclaration = descriptionToTypeDeclarationGenerator.Generate(input.IdlType);

        // Getter
        {
            var returnValueVar = generatorContext.GetNextVariableName("res");

            var getPropertyValue = getPropertyValueGenerator.Generate(
                inputVar: "JSObject",
                type: input.IdlType,
                propertyName: input.Name,
                isStatic: isStatic,
                containingTypeName: containingTypeName,
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
            var setPropertyValue = setPropertyValueGenerator.Generate(
                inputVar: "JSObject",
                type: input.IdlType,
                propertyName: input.Name,
                isStatic: isStatic,
                containingTypeName: containingTypeName
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
                        public{{staticKeyword}} {{returnTypeDeclaration}} {{name}}
                        {
                        {{body.IndentLines(4)}}
                        }
                        """;

        return content;
    }
}