using Iskra.WebIDLGenerator.Models;

namespace Iskra.WebIDLGenerator.Generators;

public class ArgumentsToDeclarationGenerator(
    IDLTypeDescriptionToTypeDeclarationGenerator idlTypeDescriptionToTypeDeclarationGenerator
)
{
    public string Generate(List<Argument> input)
    {
        var argDeclarations = input.Select(Generate).ToList();
        return string.Join(", ", argDeclarations);
    }

    private string Generate(Argument input)
    {
        var type = idlTypeDescriptionToTypeDeclarationGenerator.Generate(input.IdlType);
        if (input.Variadic)
        {
            return $$"""
                     params {{type}}[] {{input.ValidCSharpName}}
                     """;
        }

        return $$"""
                 {{type}} {{input.ValidCSharpName}}
                 """;
    }
}