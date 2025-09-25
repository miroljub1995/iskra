using Iskra.StdWebGenerator.GeneratorContexts;
using Iskra.WebIDLGenerator.Models;

namespace Iskra.WebIDLGenerator.Generators;

public class GetPropertyValueGenerator(
    GeneratorContext generatorContext
)
{
    public string Generate(
        string inputVar,
        IDLTypeDescription type,
        string propertyName,
        bool isStatic,
        string containingTypeName,
        string outputVar
    )
    {
        if (type is SingleTypeDescription singleTypeDescription)
        {
            return GenerateForSpecific(
                inputVar: inputVar,
                type: singleTypeDescription,
                propertyName: propertyName,
                isStatic: isStatic,
                containingTypeName: containingTypeName,
                outputVar: outputVar
            );
        }

        var content = $$"""
                        throw new Exception();
                        """;

        return content;
    }

    private string GenerateForSpecific(
        string inputVar,
        SingleTypeDescription type,
        string propertyName,
        bool isStatic,
        string containingTypeName,
        string outputVar
    )
    {
        var asNullableSuffix = type.Nullable ? "AsNullable" : "";

        if (type.IdlType == "boolean")
        {
            if (isStatic)
            {
                return $$"""
                         throw new Exception();
                         """;
            }
            else
            {
                return $$"""
                         {{outputVar}} = Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsBooleanV2{{asNullableSuffix}}({{inputVar}}, "{{propertyName}}");
                         """;
            }
        }

        return $$"""
                 throw new Exception();
                 """;
    }
}