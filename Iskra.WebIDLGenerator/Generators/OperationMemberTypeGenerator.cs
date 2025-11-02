using Iskra.StdWebGenerator.GeneratorContexts;
using Iskra.WebIDLGenerator.Extensions;
using Iskra.WebIDLGenerator.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Iskra.WebIDLGenerator.Generators;

public class OperationMemberTypeGenerator(
    IServiceProvider provider,
    GeneratorContext generatorContext
)
{
    public string Generate(OperationMemberType input, string containingTypeName)
    {
        var descriptionToTypeDeclarationGenerator =
            provider.GetRequiredService<IDLTypeDescriptionToTypeDeclarationGenerator>();
        var argumentsToDeclarationGenerator = provider.GetRequiredService<ArgumentsToDeclarationGenerator>();

        var isStatic = input.Special == OperationSpecial.Static;
        var staticKeyword = isStatic ? " static" : "";
        var isVoid = input.IdlType is null or SingleTypeDescription { IdlType: BuiltinTypes.Undefined };

        var name = input.Name.Replace('-', '_').CapitalizeFirstLetter();
        if (name == containingTypeName)
        {
            name += "_";
        }

        if (name == string.Empty && input.Special == OperationSpecial.Getter)
        {
            name = "Get";
        }
        else if (name == string.Empty && input.Special == OperationSpecial.Setter)
        {
            name = "Set";
        }
        else if (name == string.Empty && input.Special == OperationSpecial.Deleter)
        {
            name = "Delete";
        }

        if (name == string.Empty)
        {
            name += "_";
        }

        var returnTypeDeclaration =
            isVoid || input.IdlType is null ? "void" : descriptionToTypeDeclarationGenerator.Generate(input.IdlType);

        var argsArrayVar = generatorContext.GetNextVariableName("args");

        var args = argumentsToDeclarationGenerator.Generate(input.Arguments);

        var body = "throw new global::System.Exception();";

        var content = $$"""
                        public{{staticKeyword}} {{returnTypeDeclaration}} {{name}}({{args}})
                        {
                        {{body.IndentLines(4)}}
                        }
                        """;

        return content;
    }
}