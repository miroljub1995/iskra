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
                        public{{staticKeyword}} new {{returnTypeDeclaration}} {{name}}
                        {
                        {{body.IndentLines(4)}}
                        }
                        """;

        return content;
    }
}