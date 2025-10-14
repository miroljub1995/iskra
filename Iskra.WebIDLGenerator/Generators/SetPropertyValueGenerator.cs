using Iskra.StdWebGenerator.GeneratorContexts;
using Iskra.WebIDLGenerator.Marshallers;
using Iskra.WebIDLGenerator.Models;

namespace Iskra.WebIDLGenerator.Generators;

public class SetPropertyValueGenerator(
    GenTypeDescriptors descriptors,
    GeneratorContext generatorContext,
    IDLTypeDescriptionToTypeDeclarationGenerator descriptionToTypeDeclarationGenerator,
    IDLTypeDescriptionMarshaller marshaller
)
{
    public string Generate(
        string inputVar,
        string valueVar,
        IDLTypeDescription type,
        string propertyNameVar
    )
    {
        if (type is SingleTypeDescription singleTypeDescription)
        {
            return GenerateForSpecific(
                inputVar: inputVar,
                valueVar: valueVar,
                type: singleTypeDescription,
                propertyNameVar: propertyNameVar
            );
        }

        if (type is FrozenArrayTypeDescription frozenArrayTypeDescription)
        {
            return GenerateForFrozenArray(
                inputVar: inputVar,
                valueVar: valueVar,
                type: frozenArrayTypeDescription,
                propertyNameVar: propertyNameVar
            );
        }

        if (type is SequenceTypeDescription sequenceTypeDescription)
        {
            return GenerateForSequence(
                inputVar: inputVar,
                valueVar: valueVar,
                type: sequenceTypeDescription,
                propertyNameVar: propertyNameVar
            );
        }

        var content = $$"""
                        throw new Exception();
                        """;

        return content;
    }

    private string GenerateForSpecific(
        string inputVar,
        string valueVar,
        SingleTypeDescription type,
        string propertyNameVar
    )
    {
        var asNullableSuffix = type.Nullable ? "AsNullable" : "";
        var nullableTypeSuffix = type.Nullable ? "?" : "";

        var marshalledVar = generatorContext.GetNextVariableName("marshalledValue");

        string setPropertyContent;

        IDLTypeDescription marshalledType;

        if (type.IdlType is BuiltinTypes.Boolean)
        {
            marshalledType = new SingleTypeDescription
            {
                ExtAttrs = [],
                IdlType = BuiltinTypes.Boolean,
                Nullable = type.Nullable,
            };

            setPropertyContent = $$"""
                                   Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsBooleanV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}}, {{marshalledVar}});
                                   """;
        }
        else if (type.IdlType is BuiltinTypes.String)
        {
            marshalledType = new SingleTypeDescription
            {
                ExtAttrs = [],
                IdlType = BuiltinTypes.String,
                Nullable = type.Nullable,
            };

            setPropertyContent = $$"""
                                   Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}}, {{marshalledVar}});
                                   """;
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
            marshalledType = new SingleTypeDescription
            {
                ExtAttrs = [],
                IdlType = BuiltinTypes.Double,
                Nullable = type.Nullable,
            };

            setPropertyContent = $$"""
                                   Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsDoubleV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}}, {{marshalledVar}});
                                   """;
        }
        else if (descriptors.TryGet(type.IdlType, out var descriptor) && descriptor.RootType is EnumType)
        {
            marshalledType = new SingleTypeDescription
            {
                ExtAttrs = [],
                IdlType = BuiltinTypes.String,
                Nullable = type.Nullable,
            };

            setPropertyContent = $$"""
                                   Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}}, {{marshalledVar}});
                                   """;
        }
        else
        {
            marshalledType = new SingleTypeDescription
            {
                ExtAttrs = [],
                IdlType = BuiltinTypes.Object,
                Nullable = type.Nullable,
            };

            setPropertyContent = $$"""
                                   Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}}, {{marshalledVar}});
                                   """;
        }

        var marshalledTypeDeclaration = descriptionToTypeDeclarationGenerator.Generate(marshalledType);

        return $$"""
                 {{marshalledTypeDeclaration}} {{marshalledVar}};
                 {{marshaller.ToJS(type, valueVar, marshalledType, marshalledVar)}}
                 {{setPropertyContent}}
                 """;
    }

    private string GenerateForFrozenArray(
        string inputVar,
        string valueVar,
        FrozenArrayTypeDescription type,
        string propertyNameVar
    )
    {
        var asNullableSuffix = type.Nullable ? "AsNullable" : "";
        var nullableTypeSuffix = type.Nullable ? "?" : "";

        var setPropertyVar = generatorContext.GetNextVariableName("propObject");

        var setPropertyContent = $$"""
                                   Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}}, {{setPropertyVar}});
                                   """;

        if (type.Nullable)
        {
            return $$"""
                     global::System.Runtime.InteropServices.JavaScript.JSObject{{nullableTypeSuffix}} {{setPropertyVar}};
                     if ({{valueVar}} is null)
                     {
                         {{setPropertyVar}} = null;
                     }
                     else
                     {
                         {{setPropertyVar}} = {{valueVar}}.JSObject;
                     }

                     {{setPropertyContent}}
                     """;
        }

        return $$"""
                 global::System.Runtime.InteropServices.JavaScript.JSObject{{nullableTypeSuffix}} {{setPropertyVar}} = {{valueVar}}.JSObject;
                 {{setPropertyContent}}
                 """;
    }

    private string GenerateForSequence(
        string inputVar,
        string valueVar,
        SequenceTypeDescription type,
        string propertyNameVar
    )
    {
        var asNullableSuffix = type.Nullable ? "AsNullable" : "";
        var nullableTypeSuffix = type.Nullable ? "?" : "";

        var setPropertyVar = generatorContext.GetNextVariableName("propObject");

        var setPropertyContent = $$"""
                                   Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}}, {{setPropertyVar}});
                                   """;

        if (type.Nullable)
        {
            return $$"""
                     global::System.Runtime.InteropServices.JavaScript.JSObject{{nullableTypeSuffix}} {{setPropertyVar}};
                     if ({{valueVar}} is null)
                     {
                         {{setPropertyVar}} = null;
                     }
                     else
                     {
                         {{setPropertyVar}} = {{valueVar}}.JSObject;
                     }

                     {{setPropertyContent}}
                     """;
        }

        return $$"""
                 global::System.Runtime.InteropServices.JavaScript.JSObject{{nullableTypeSuffix}} {{setPropertyVar}} = {{valueVar}}.JSObject;
                 {{setPropertyContent}}
                 """;
    }
}