using Iskra.StdWebGenerator.GeneratorContexts;
using Iskra.WebIDLGenerator.Extensions;
using Iskra.WebIDLGenerator.Models;

namespace Iskra.WebIDLGenerator.Generators;

public class AttributeMemberTypeGenerator(
    IDLTypeDescriptionToTypeDeclarationGenerator descriptionToTypeDeclarationGenerator,
    GetPropertyValueGenerator getPropertyValueGenerator,
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

        var returnType = descriptionToTypeDeclarationGenerator.Generate(input.IdlType);
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
                           {{returnType}} {{returnValueVar}};
                       {{getPropertyValue.IndentLines(4)}}
                           return {{returnValueVar}};
                       }
                       """;

        bodyParts.Add(getter);

        if (!input.Readonly)
        {
            var setter = $$"""
                           set
                           {
                               throw new Exception();
                           }
                           """;

            bodyParts.Add(setter);
        }

        var body = string.Join("\n", bodyParts);

        var content = $$"""
                        public{{staticKeyword}} {{returnType}} {{name}}
                        {
                        {{body.IndentLines(4)}}
                        }
                        """;

        return content;
    }

    private string GeneratePropertyGetter(AttributeMemberType input)
    {
        throw new NotImplementedException();
    }
}