using Iskra.StdWebGenerator.GeneratorContexts;
using Iskra.WebIDLGenerator.Marshallers;
using Iskra.WebIDLGenerator.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Iskra.WebIDLGenerator.Generators;

public class GetPropertyValueGenerator(
    IServiceProvider provider,
    GeneratorContext generatorContext,
    IDLTypeDescriptionMarshaller marshaller
)
{
    public string Generate(
        string inputVar,
        IDLTypeDescription type,
        string propertyNameVar,
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
                propertyNameVar: propertyNameVar,
                isStatic: isStatic,
                containingTypeName: containingTypeName,
                outputVar: outputVar
            );
        }

        if (type is SequenceTypeDescription sequenceTypeDescription)
        {
            return GenerateForSequence(
                inputVar: inputVar,
                type: sequenceTypeDescription,
                propertyNameVar: propertyNameVar,
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
        string propertyNameVar,
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
                                       bool{{nullableTypeSuffix}} {{getPropertyVar}} = Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsBooleanV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}});
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
                                       string{{nullableTypeSuffix}} {{getPropertyVar}} = Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsStringV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}});
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
                                       double{{nullableTypeSuffix}} {{getPropertyVar}} = Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsDoubleV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}});
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
                                       JSObject{{nullableTypeSuffix}} {{getPropertyVar}} = Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}});
                                       """;
            }
        }

        return $$"""
                 {{getPropertyContent}}
                 {{marshaller.ToManaged(inputType, getPropertyVar, type, outputVar)}}
                 """;
    }

    private string GenerateForSequence(
        string inputVar,
        SequenceTypeDescription type,
        string propertyNameVar,
        bool isStatic,
        string containingTypeName,
        string outputVar
    )
    {
        var toTypeDeclarationGenerator = provider.GetRequiredService<IDLTypeDescriptionToTypeDeclarationGenerator>();

        var arrayTypeDeclaration = toTypeDeclarationGenerator.Generate(type);


        var asNullableSuffix = type.Nullable ? "AsNullable" : "";
        var nullableTypeSuffix = type.Nullable ? "?" : "";

        var getPropertyVar = generatorContext.GetNextVariableName("propObject");

        string getPropertyContent;
        if (isStatic)
        {
            return $$"""
                     throw new Exception();
                     """;
        }
        else
        {
            getPropertyContent = $$"""
                                   {{getPropertyVar}} = Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}});
                                   """;
        }

        if (type.Nullable)
        {
            return $$"""
                     JSObject{{nullableTypeSuffix}} {{getPropertyVar}};
                     {{getPropertyContent}}
                     if ({{getPropertyContent}} is null)
                     {
                         return null;
                     }

                     {{outputVar}} = new {{arrayTypeDeclaration}}({{getPropertyVar}});
                     """;
        }

        return $$"""
                 JSObject{{nullableTypeSuffix}} {{getPropertyVar}};
                 {{getPropertyContent}}
                 {{outputVar}} = new {{arrayTypeDeclaration}}({{getPropertyVar}});
                 """;
    }
}