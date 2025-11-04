using Iskra.WebIDLGenerator.Extensions;
using Iskra.WebIDLGenerator.Models;
using Iskra.WebIDLGenerator.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Iskra.WebIDLGenerator.Generators;

public class ConstructorMemberTypeGenerator(
    IServiceProvider provider,
    GenSettings genSettings
)
{
    public string Generate(ConstructorMemberType input, string containingTypeName)
    {
        var argsArrayGenerator = provider.GetRequiredService<ArgumentsToArgsArrayGenerator>();
        var descriptionToTypeDeclarationGenerator =
            provider.GetRequiredService<IDLTypeDescriptionToTypeDeclarationGenerator>();
        var argumentsToDeclarationGenerator = provider.GetRequiredService<ArgumentsToDeclarationGenerator>();
        var propertyAccessorGenerator = provider.GetRequiredService<PropertyAccessorGenerator>();

        var isEmpty = input.Arguments.Count == 0;

        var args = argumentsToDeclarationGenerator.Generate(input.Arguments);

        var argsArrayVar = VariableName.Current.GetNext("argsArray");
        var resOwnerVar = VariableName.Current.GetNext("resOwner");
        var resVar = VariableName.Current.GetNext("res");

        var argVars = input.Arguments
            .Select(x => x.ValidCSharpName)
            .ToList();

        List<string> bodyStatements = [];

        using (VariableName.CreateScope())
        {
            if (isEmpty)
            {
                bodyStatements.Add(
                    $"global::System.Runtime.InteropServices.JavaScript.JSObject {resVar} = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, \"{containingTypeName}\");");
            }
            else
            {
                bodyStatements.Add(argsArrayGenerator.Generate(
                    args: input.Arguments,
                    argVars: argVars,
                    argsArrayVar: argsArrayVar
                ));

                bodyStatements.Add(
                    $"global::System.Runtime.InteropServices.JavaScript.JSObject {resVar} = global::Iskra.JSCore.Extensions.JSConstructorExtensions.ConstructObjectNonEmpty(global::System.Runtime.InteropServices.JavaScript.JSHost.GlobalThis, \"{containingTypeName}\", {argsArrayVar}.JSObject);");
            }
        }

        var body = string.Join("\n\n", bodyStatements);

        var content = $$"""
                        public static global::{{genSettings.Namespace}}.{{containingTypeName}} New({{args}})
                        {
                        {{body.IndentLines(4)}}
                            return new global::{{genSettings.Namespace}}.{{containingTypeName}}({{resVar}});
                        }
                        """;

        return content;
    }
}