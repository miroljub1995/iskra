using Iskra.WebIDLGenerator.Extensions;
using Iskra.WebIDLGenerator.Generators;
using Iskra.WebIDLGenerator.Models;
using Iskra.WebIDLGenerator.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Iskra.WebIDLGenerator.Marshallers;

public partial class IDLTypeDescriptionMarshaller
{
    private string ToManagedNullable(
        IDLTypeDescription input,
        string inputVar,
        IDLTypeDescription outputType,
        string outputVar
    )
    {
        var notNullableInput = input with { Nullable = false };
        var notNullableOutput = outputType with { Nullable = false };

        var notNullableInputVar = VariableName.Current.GetNext("notNullable");

        var notNullableType = provider
            .GetRequiredService<IDLTypeDescriptionToTypeDeclarationGenerator>()
            .Generate(notNullableInput);

        return $$"""
                 if ({{inputVar}} is null)
                 {
                     {{outputVar}} = null;
                 }
                 else
                 {
                     {{notNullableType}} {{notNullableInputVar}} = ({{notNullableType}}){{inputVar}};
                 {{ToManaged(notNullableInput, notNullableInputVar, notNullableOutput, outputVar).IndentLines(4)}}
                 }
                 """;
    }

    public string ToJSNullable(
        IDLTypeDescription input,
        string inputVar,
        IDLTypeDescription outputType,
        string outputVar
    )
    {
        var notNullableInput = input with { Nullable = false };
        var notNullableOutput = outputType with { Nullable = false };

        var notNullableInputVar = VariableName.Current.GetNext("notNullable");

        var notNullableInputTypeDeclaration = provider
            .GetRequiredService<IDLTypeDescriptionToTypeDeclarationGenerator>()
            .Generate(notNullableInput);

        return $$"""
                 if ({{inputVar}} is null)
                 {
                     {{outputVar}} = null;
                 }
                 else
                 {
                     {{notNullableInputTypeDeclaration}} {{notNullableInputVar}} = ({{notNullableInputTypeDeclaration}}){{inputVar}};
                 {{ToJS(notNullableInput, notNullableInputVar, notNullableOutput, outputVar).IndentLines(4)}}
                 }
                 """;
    }
}