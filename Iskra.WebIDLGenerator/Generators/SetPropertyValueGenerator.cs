using Iskra.StdWebGenerator.GeneratorContexts;
using Iskra.WebIDLGenerator.Marshallers;
using Iskra.WebIDLGenerator.Models;

namespace Iskra.WebIDLGenerator.Generators;

public class SetPropertyValueGenerator(
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
        string containingTypeName
    )
    {
        if (type is SingleTypeDescription singleTypeDescription)
        {
            return GenerateForSpecific(
                inputVar: inputVar,
                type: singleTypeDescription,
                propertyName: propertyName,
                isStatic: isStatic,
                containingTypeName: containingTypeName
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
        string containingTypeName
    )
    {
        var asNullableSuffix = type.Nullable ? "AsNullable" : "";
        var nullableTypeSuffix = type.Nullable ? "?" : "";

        var marshalledVar = generatorContext.GetNextVariableName("marshalledValue");

        string setPropertyContent;

        IDLTypeDescription marshalledType;

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
                marshalledType = new SingleTypeDescription
                {
                    ExtAttrs = [],
                    IdlType = BuiltinTypes.Boolean,
                    Nullable = type.Nullable,
                };

                setPropertyContent = $$"""
                                       Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsBooleanV2{{asNullableSuffix}}({{inputVar}}, "{{propertyName}}", {{marshalledVar}});
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
                marshalledType = new SingleTypeDescription
                {
                    ExtAttrs = [],
                    IdlType = BuiltinTypes.String,
                    Nullable = type.Nullable,
                };

                setPropertyContent = $$"""
                                       Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsStringV2{{asNullableSuffix}}({{inputVar}}, "{{propertyName}}", {{marshalledVar}});
                                       """;
            }
        }
        else if (type.IdlType is
                 BuiltinTypes.Octet or
                 BuiltinTypes.Byte or
                 BuiltinTypes.Short or
                 BuiltinTypes.UnsignedShort or
                 BuiltinTypes.Long or
                 BuiltinTypes.UnsignedLong or
                 BuiltinTypes.LongLong or
                 BuiltinTypes.UnsignedLongLong or
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
                marshalledType = new SingleTypeDescription
                {
                    ExtAttrs = [],
                    IdlType = BuiltinTypes.Double,
                    Nullable = type.Nullable,
                };

                setPropertyContent = $$"""
                                       Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsDoubleV2{{asNullableSuffix}}({{inputVar}}, "{{propertyName}}", {{marshalledVar}});
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
                marshalledType = new SingleTypeDescription
                {
                    ExtAttrs = [],
                    IdlType = BuiltinTypes.Object,
                    Nullable = type.Nullable,
                };

                setPropertyContent = $$"""
                                       Iskra.JSCore.Extensions.JSObjectPropertyExtensions.SetPropertyAsJSObjectV2{{asNullableSuffix}}({{inputVar}}, "{{propertyName}}", {{marshalledVar}});
                                       """;
            }
        }

        var marshalledTypeDeclaration = descriptionToTypeDeclarationGenerator.Generate(marshalledType);

        return $$"""
                 {{marshalledTypeDeclaration}} {{marshalledVar}};
                 {{marshaller.ToJS(marshalledType, "value", marshalledType, marshalledVar)}}
                 {{setPropertyContent}}
                 """;
    }
}