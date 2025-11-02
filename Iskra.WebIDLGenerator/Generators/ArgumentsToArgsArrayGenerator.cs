using Iskra.WebIDLGenerator.Extensions;
using Iskra.WebIDLGenerator.Models;
using Iskra.WebIDLGenerator.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Iskra.WebIDLGenerator.Generators;

public class ArgumentsToArgsArrayGenerator(
    IServiceProvider provider
)
{
    public string Generate(
        IReadOnlyList<Argument> args,
        IReadOnlyList<string> argVars,
        string argsArrayVar
    )
    {
        var setPropertyValueGenerator = provider.GetRequiredService<SetPropertyValueGenerator>();
        var idlToTypeDescripor = provider.GetRequiredService<IDLTypeDescriptionToTypeDeclarationGenerator>();

        List<string> parts = [];

        if (args.Count > 0)
        {
            var argsArrayLength = VariableName.Current.GetNext("argsArrayLength");

            if (args[^1].Variadic)
            {
                parts.Add(
                    $$"""
                      int {{argsArrayLength}} = {{argVars[^1]}}.Length + {{args.Count - 1}};
                      """
                );
            }
            else
            {
                parts.Add(
                    $$"""
                      int {{argsArrayLength}} = {{args.Count}};
                      """
                );
            }

            parts.Add($"""
                       using global::Iskra.JSCore.ArgsArrayPool.Owner {argsArrayVar} = global::Iskra.JSCore.ArgsArrayPool.Shared.Rent({argsArrayLength});
                       """
            );
        }

        for (var i = 0; i < args.Count; i++)
        {
            var arg = args[i];

            if (i == args.Count - 1 && arg.Variadic)
            {
                var indexVar = VariableName.Current.GetNext("i");
                var elemVar = VariableName.Current.GetNext("elem");

                var setParamsProperty = setPropertyValueGenerator.Generate(
                    inputVar: $"{argsArrayVar}.JSObject",
                    valueVar: $"{elemVar}",
                    type: arg.IdlType,
                    propertyNameVar: $"{i} + {indexVar}"
                );

                var argType = idlToTypeDescripor.Generate(arg.IdlType);

                parts.Add(
                    $$"""
                      // Argument {{i + 1}}
                      for (int {{indexVar}} = 0; {{indexVar}} < {{argVars[^1]}}.Length; {{indexVar}}++)
                      {
                      {{argType}} {{elemVar}} = {{argVars[^1]}}[{{indexVar}}];
                      {{setParamsProperty.IndentLines(4)}}
                      }
                      """
                );
            }
            else
            {
                var setPropertyContent = setPropertyValueGenerator.Generate(
                    inputVar: $"{argsArrayVar}.JSObject",
                    valueVar: argVars[i],
                    type: arg.IdlType,
                    propertyNameVar: $"{i}"
                );

                parts.Add(
                    $$"""
                      // Argument {{i + 1}}
                      {{setPropertyContent}}
                      """
                );
            }
        }

        return string.Join("\n\n", parts);
    }
}