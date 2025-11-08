using Iskra.WebIDLGenerator.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Iskra.WebIDLGenerator.Generators;

public class ConstantMemberTypeGenerator(
    IServiceProvider provider
)
{
    public string Generate(ConstantMemberType input)
    {
        var descriptionToTypeDeclarationGenerator =
            provider.GetRequiredService<IDLTypeDescriptionToTypeDeclarationGenerator>();

        if (input.IdlType is not SingleTypeDescription type)
        {
            throw new NotSupportedException("Only single types are supported for constant members.");
        }

        var value = input.Value switch
        {
            ValueDescriptionString stringValue => $"\n{stringValue.Value}\n",
            ValueDescriptionNumber numberValue => numberValue.Value,
            ValueDescriptionBoolean booleanValue => booleanValue.Value ? "true" : "false",
            ValueDescriptionNull => "null",
            ValueDescriptionInfinity infinity => infinity.Negative
                ? "double.NegativeInfinity"
                : "double.PositiveInfinity",
            ValueDescriptionNaN => "double.NaN",
            _ => throw new NotSupportedException($"Value {input.Value} is not supported.")
        };

        var typeDeclaration = descriptionToTypeDeclarationGenerator.Generate(type);

        var content = $$"""
                        public const {{typeDeclaration}} {{input.Name}} = {{value}};
                        """;

        return content;
    }
}