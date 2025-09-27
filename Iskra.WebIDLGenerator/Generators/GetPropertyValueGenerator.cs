using Iskra.StdWebGenerator.GeneratorContexts;
using Iskra.WebIDLGenerator.Marshallers;
using Iskra.WebIDLGenerator.Models;

namespace Iskra.WebIDLGenerator.Generators;

public class GetPropertyValueGenerator(
    GeneratorContext generatorContext,
    IDLTypeDescriptionToTypeDeclarationGenerator descriptionToTypeDeclarationGenerator,
    IDLTypeDescriptionMarshaller marshaller
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
        var nullableTypeSuffix = type.Nullable ? "?" : "";

        var getPropertyVar = generatorContext.GetNextVariableName("res");

        string getPropertyContent;

        IDLTypeDescription inputType;

        if (type.IdlType is BuiltinTypes.Boolean)
        {
            if (isStatic)
            {
                return $$"""
                         throw new Exception();
                         """;
            }
            else
            {
                inputType = new SingleTypeDescription
                {
                    ExtAttrs = [],
                    IdlType = BuiltinTypes.Boolean,
                    Nullable = type.Nullable,
                };

                getPropertyContent = $$"""
                                       bool{{nullableTypeSuffix}} {{getPropertyVar}} = Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsBooleanV2{{asNullableSuffix}}({{inputVar}}, "{{propertyName}}");
                                       """;
            }
        }
        else if (type.IdlType is BuiltinTypes.String)
        {
            if (isStatic)
            {
                return $$"""
                         throw new Exception();
                         """;
            }
            else
            {
                inputType = new SingleTypeDescription
                {
                    ExtAttrs = [],
                    IdlType = BuiltinTypes.String,
                    Nullable = type.Nullable,
                };

                getPropertyContent = $$"""
                                       string{{nullableTypeSuffix}} {{getPropertyVar}} = Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsStringV2{{asNullableSuffix}}({{inputVar}}, "{{propertyName}}");
                                       """;
            }
        }
        else if (type.IdlType is
                 BuiltinTypes.Byte or
                 BuiltinTypes.SignedByte or
                 BuiltinTypes.Short or
                 BuiltinTypes.UnsignedShort or
                 BuiltinTypes.Int32 or
                 BuiltinTypes.UnsignedInt32 or
                 BuiltinTypes.Int64 or
                 BuiltinTypes.UnsignedInt64 or
                 BuiltinTypes.Float or
                 BuiltinTypes.UnrestrictedFloat or
                 BuiltinTypes.Double or
                 BuiltinTypes.UnrestrictedDouble
                )
        {
            if (isStatic)
            {
                return $$"""
                         throw new Exception();
                         """;
            }
            else
            {
                inputType = new SingleTypeDescription
                {
                    ExtAttrs = [],
                    IdlType = BuiltinTypes.Double,
                    Nullable = type.Nullable,
                };

                getPropertyContent = $$"""
                                       double{{nullableTypeSuffix}} {{getPropertyVar}} = Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsDoubleV2{{asNullableSuffix}}({{inputVar}}, "{{propertyName}}");
                                       """;
            }
        }
        else
        {
            if (isStatic)
            {
                return $$"""
                         throw new Exception();
                         """;
            }
            else
            {
                inputType = new SingleTypeDescription
                {
                    ExtAttrs = [],
                    IdlType = BuiltinTypes.Object,
                    Nullable = type.Nullable,
                };

                getPropertyContent = $$"""
                                       JSObject{{nullableTypeSuffix}} {{getPropertyVar}} = Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2{{asNullableSuffix}}({{inputVar}}, "{{propertyName}}");
                                       """;
            }
        }

        return $$"""
                 {{getPropertyContent}}
                 {{marshaller.ToManaged(inputType, getPropertyVar, type, outputVar)}}
                 """;
    }
}