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

        var isStatic = input.Special == OperationSpecial.Static;
        var staticKeyword = isStatic ? " static" : "";

        var name = input.Name.Replace('-', '_').CapitalizeFirstLetter();
        if (name == containingTypeName)
        {
            name += "_";
        }

        if (name == string.Empty)
        {
            name += "_";
        }

        var returnTypeDeclaration =
            input.IdlType is null ? "void" : descriptionToTypeDeclarationGenerator.Generate(input.IdlType);

        var argsArrayVar = generatorContext.GetNextVariableName("args");

        var body = "throw new Exception();";

        var content = $$"""
                        public{{staticKeyword}} {{returnTypeDeclaration}} {{name}}()
                        {
                            global::Iskra.JSCore.ArgsArrayPool.Owner {{argsArrayVar}} = global::Iskra.JSCore.ArgsArrayPool.Rent(0);
                        {{body.IndentLines(4)}}
                        }
                        """;

        return content;
    }
}