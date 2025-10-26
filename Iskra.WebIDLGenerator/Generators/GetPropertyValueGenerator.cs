using Iskra.StdWebGenerator.GeneratorContexts;
using Iskra.WebIDLGenerator.Marshallers;
using Iskra.WebIDLGenerator.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Iskra.WebIDLGenerator.Generators;

public class GetPropertyValueGenerator(
    IServiceProvider provider,
    GenTypeDescriptors descriptors,
    GeneratorContext generatorContext,
    IDLTypeDescriptionMarshaller marshaller
)
{
    public string Generate(
        string inputVar,
        IDLTypeDescription type,
        string propertyNameVar,
        string outputVar
    )
    {
        if (type is SingleTypeDescription singleTypeDescription)
        {
            return GenerateForSpecific(
                inputVar: inputVar,
                type: singleTypeDescription,
                propertyNameVar: propertyNameVar,
                outputVar: outputVar
            );
        }

        if (type is FrozenArrayTypeDescription frozenArrayTypeDescription)
        {
            return GenerateForFrozenArray(
                inputVar: inputVar,
                type: frozenArrayTypeDescription,
                propertyNameVar: propertyNameVar,
                outputVar: outputVar
            );
        }

        if (type is ObservableArrayTypeDescription observableArrayTypeDescription)
        {
            return GenerateForObservableArray(
                inputVar: inputVar,
                type: observableArrayTypeDescription,
                propertyNameVar: propertyNameVar,
                outputVar: outputVar
            );
        }

        if (type is PromiseTypeDescription promiseTypeDescription)
        {
            return GenerateForPromise(
                inputVar: inputVar,
                type: promiseTypeDescription,
                propertyNameVar: propertyNameVar,
                outputVar: outputVar
            );
        }

        if (type is SequenceTypeDescription sequenceTypeDescription)
        {
            return GenerateForSequence(
                inputVar: inputVar,
                type: sequenceTypeDescription,
                propertyNameVar: propertyNameVar,
                outputVar: outputVar
            );
        }

        if (type is UnionTypeDescription unionTypeDescription)
        {
            return GenerateForUnion(
                inputVar: inputVar,
                type: unionTypeDescription,
                propertyNameVar: propertyNameVar,
                outputVar: outputVar
            );
        }

        var content = $$"""
                        throw new global::System.Exception();
                        """;

        return content;
    }

    private string GenerateForSpecific(
        string inputVar,
        SingleTypeDescription type,
        string propertyNameVar,
        string outputVar
    )
    {
        var asNullableSuffix = type.Nullable ? "AsNullable" : "";
        var nullableTypeSuffix = type.Nullable ? "?" : "";

        var getPropertyVar = generatorContext.GetNextVariableName("res");

        string getPropertyContent;
        IDLTypeDescription inputType;

        if (type.IdlType is BuiltinTypes.BigInt)
        {
            inputType = new SingleTypeDescription
            {
                ExtAttrs = [],
                IdlType = BuiltinTypes.BigInt,
                Nullable = type.Nullable,
            };

            getPropertyContent = $$"""
                                   global::System.Numerics.BigInteger{{nullableTypeSuffix}} {{getPropertyVar}} = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsBigIntegerV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}});
                                   """;
        }
        else if (type.IdlType is BuiltinTypes.Boolean)
        {
            inputType = new SingleTypeDescription
            {
                ExtAttrs = [],
                IdlType = BuiltinTypes.Boolean,
                Nullable = type.Nullable,
            };

            getPropertyContent = $$"""
                                   bool{{nullableTypeSuffix}} {{getPropertyVar}} = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsBooleanV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}});
                                   """;
        }
        else if (type.IdlType is BuiltinTypes.String)
        {
            inputType = new SingleTypeDescription
            {
                ExtAttrs = [],
                IdlType = BuiltinTypes.String,
                Nullable = type.Nullable,
            };

            getPropertyContent = $$"""
                                   string{{nullableTypeSuffix}} {{getPropertyVar}} = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsStringV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}});
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
            inputType = new SingleTypeDescription
            {
                ExtAttrs = [],
                IdlType = BuiltinTypes.Double,
                Nullable = type.Nullable,
            };

            getPropertyContent = $$"""
                                   double{{nullableTypeSuffix}} {{getPropertyVar}} = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsDoubleV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}});
                                   """;
        }
        else if (type.IdlType is BuiltinTypes.ManagedObject)
        {
            inputType = new SingleTypeDescription
            {
                ExtAttrs = [],
                IdlType = BuiltinTypes.ManagedObject,
                Nullable = type.Nullable,
            };

            getPropertyContent = $$"""
                                   object{{nullableTypeSuffix}} {{getPropertyVar}} = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsObjectV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}});
                                   """;
        }
        else if (descriptors.TryGet(type.IdlType, out var descriptor) && descriptor.RootType is EnumType)
        {
            inputType = new SingleTypeDescription
            {
                ExtAttrs = [],
                IdlType = BuiltinTypes.String,
                Nullable = type.Nullable,
            };

            getPropertyContent = $$"""
                                   string{{nullableTypeSuffix}} {{getPropertyVar}} = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsStringV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}});
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
                                   global::System.Runtime.InteropServices.JavaScript.JSObject{{nullableTypeSuffix}} {{getPropertyVar}} = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}});
                                   """;
        }

        return $$"""
                 {{getPropertyContent}}
                 {{marshaller.ToManaged(inputType, getPropertyVar, type, outputVar)}}
                 """;
    }

    private string GenerateForFrozenArray(
        string inputVar,
        FrozenArrayTypeDescription type,
        string propertyNameVar,
        string outputVar
    )
    {
        var toTypeDeclarationGenerator = provider.GetRequiredService<IDLTypeDescriptionToTypeDeclarationGenerator>();

        var constructor = toTypeDeclarationGenerator.Generate(type with { Nullable = false });

        var asNullableSuffix = type.Nullable ? "AsNullable" : "";
        var nullableTypeSuffix = type.Nullable ? "?" : "";

        var getPropertyVar = generatorContext.GetNextVariableName("propObject");

        var getPropertyContent = $$"""
                                   {{getPropertyVar}} = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}});
                                   """;

        if (type.Nullable)
        {
            return $$"""
                     global::System.Runtime.InteropServices.JavaScript.JSObject{{nullableTypeSuffix}} {{getPropertyVar}};
                     {{getPropertyContent}}
                     if ({{getPropertyVar}} is null)
                     {
                         return null;
                     }

                     {{outputVar}} = new {{constructor}}({{getPropertyVar}});
                     """;
        }

        return $$"""
                 global::System.Runtime.InteropServices.JavaScript.JSObject{{nullableTypeSuffix}} {{getPropertyVar}};
                 {{getPropertyContent}}
                 {{outputVar}} = new {{constructor}}({{getPropertyVar}});
                 """;
    }

    private string GenerateForObservableArray(
        string inputVar,
        ObservableArrayTypeDescription type,
        string propertyNameVar,
        string outputVar
    )
    {
        var toTypeDeclarationGenerator = provider.GetRequiredService<IDLTypeDescriptionToTypeDeclarationGenerator>();

        var constructor = toTypeDeclarationGenerator.Generate(type with { Nullable = false });

        var asNullableSuffix = type.Nullable ? "AsNullable" : "";
        var nullableTypeSuffix = type.Nullable ? "?" : "";

        var getPropertyVar = generatorContext.GetNextVariableName("propObject");

        var getPropertyContent = $$"""
                                   {{getPropertyVar}} = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}});
                                   """;

        if (type.Nullable)
        {
            return $$"""
                     global::System.Runtime.InteropServices.JavaScript.JSObject{{nullableTypeSuffix}} {{getPropertyVar}};
                     {{getPropertyContent}}
                     if ({{getPropertyVar}} is null)
                     {
                         return null;
                     }

                     {{outputVar}} = new {{constructor}}({{getPropertyVar}});
                     """;
        }

        return $$"""
                 global::System.Runtime.InteropServices.JavaScript.JSObject{{nullableTypeSuffix}} {{getPropertyVar}};
                 {{getPropertyContent}}
                 {{outputVar}} = new {{constructor}}({{getPropertyVar}});
                 """;
    }

    private string GenerateForPromise(
        string inputVar,
        PromiseTypeDescription type,
        string propertyNameVar,
        string outputVar
    )
    {
        var toTypeDeclarationGenerator = provider.GetRequiredService<IDLTypeDescriptionToTypeDeclarationGenerator>();

        var constructor = toTypeDeclarationGenerator.Generate(type with { Nullable = false });

        var asNullableSuffix = type.Nullable ? "AsNullable" : "";
        var nullableTypeSuffix = type.Nullable ? "?" : "";

        var getPropertyVar = generatorContext.GetNextVariableName("propObject");

        var getPropertyContent = $$"""
                                   {{getPropertyVar}} = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}});
                                   """;

        if (type.Nullable)
        {
            return $$"""
                     global::System.Runtime.InteropServices.JavaScript.JSObject{{nullableTypeSuffix}} {{getPropertyVar}};
                     {{getPropertyContent}}
                     if ({{getPropertyVar}} is null)
                     {
                         return null;
                     }

                     {{outputVar}} = new {{constructor}}({{getPropertyVar}});
                     """;
        }

        return $$"""
                 global::System.Runtime.InteropServices.JavaScript.JSObject{{nullableTypeSuffix}} {{getPropertyVar}};
                 {{getPropertyContent}}
                 {{outputVar}} = new {{constructor}}({{getPropertyVar}});
                 """;
    }

    private string GenerateForSequence(
        string inputVar,
        SequenceTypeDescription type,
        string propertyNameVar,
        string outputVar
    )
    {
        var toTypeDeclarationGenerator = provider.GetRequiredService<IDLTypeDescriptionToTypeDeclarationGenerator>();

        var constructor = toTypeDeclarationGenerator.Generate(type with { Nullable = false });

        var asNullableSuffix = type.Nullable ? "AsNullable" : "";
        var nullableTypeSuffix = type.Nullable ? "?" : "";

        var getPropertyVar = generatorContext.GetNextVariableName("propObject");

        var getPropertyContent = $$"""
                                   {{getPropertyVar}} = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsJSObjectV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}});
                                   """;

        if (type.Nullable)
        {
            return $$"""
                     global::System.Runtime.InteropServices.JavaScript.JSObject{{nullableTypeSuffix}} {{getPropertyVar}};
                     {{getPropertyContent}}
                     if ({{getPropertyVar}} is null)
                     {
                         return null;
                     }

                     {{outputVar}} = new {{constructor}}({{getPropertyVar}});
                     """;
        }

        return $$"""
                 global::System.Runtime.InteropServices.JavaScript.JSObject{{nullableTypeSuffix}} {{getPropertyVar}};
                 {{getPropertyContent}}
                 {{outputVar}} = new {{constructor}}({{getPropertyVar}});
                 """;
    }


    private string GenerateForUnion(
        string inputVar,
        UnionTypeDescription type,
        string propertyNameVar,
        string outputVar
    )
    {
        var toTypeDeclarationGenerator = provider.GetRequiredService<IDLTypeDescriptionToTypeDeclarationGenerator>();

        var constructor = toTypeDeclarationGenerator.Generate(type with { Nullable = false });

        var asNullableSuffix = type.Nullable ? "AsNullable" : "";
        var nullableTypeSuffix = type.Nullable ? "?" : "";

        var getPropertyVar = generatorContext.GetNextVariableName("propObject");

        var getPropertyContent = $$"""
                                   {{getPropertyVar}} = global::Iskra.JSCore.Extensions.JSObjectPropertyExtensions.GetPropertyAsUnionV2{{asNullableSuffix}}({{inputVar}}, {{propertyNameVar}});
                                   """;

        if (type.Nullable)
        {
            return $$"""
                     global::System.Runtime.InteropServices.JavaScript.JSObject{{nullableTypeSuffix}} {{getPropertyVar}};
                     {{getPropertyContent}}
                     if ({{getPropertyVar}} is null)
                     {
                         return null;
                     }

                     {{outputVar}} = new {{constructor}}({{getPropertyVar}});
                     """;
        }

        return $$"""
                 global::System.Runtime.InteropServices.JavaScript.JSObject{{nullableTypeSuffix}} {{getPropertyVar}};
                 {{getPropertyContent}}
                 {{outputVar}} = new {{constructor}}({{getPropertyVar}});
                 """;
    }
}