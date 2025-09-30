using Iskra.WebIDLGenerator.Models;
using Microsoft.Extensions.Logging;

namespace Iskra.WebIDLGenerator.Generators;

public class IDLTypeDescriptionToTypeDeclarationGenerator(
    ILogger<IDLTypeDescriptionToTypeDeclarationGenerator> logger,
    GenTypeDescriptors genTypeDescriptors,
    GenericMarshallerGenerator genericMarshallerGenerator
)
{
    public string Generate(IDLTypeDescription input, bool marshalled = false)
    {
        if (input is SingleTypeDescription singleTypeDescription)
        {
            return MapSingleToManagedType(singleTypeDescription);
        }

        if (input is FrozenArrayTypeDescription frozenArrayTypeDescription)
        {
            return MapFrozenArrayToManagedType(frozenArrayTypeDescription, marshalled);
        }

        if (input is SequenceTypeDescription sequenceTypeDescription)
        {
            return MapSequenceToManagedType(sequenceTypeDescription, marshalled);
        }

        if (input is UnionTypeDescription unionTypeDescription)
        {
            return MapUnionToManagedType(unionTypeDescription);
        }

        logger.LogWarning("Input type {input} is not handled, fallback to object.", input.GetType());
        return "object";
    }

    private static string MakeNullableIfNeeded(string input, bool nullable)
    {
        if (nullable)
        {
            return input + "?";
        }

        return input;
    }

    private string MapSingleToManagedType(SingleTypeDescription input)
    {
        var mapped = MapToDotnetType(input.IdlType);
        return MakeNullableIfNeeded(mapped, input.Nullable || input.IdlType == "any");
    }


    private string MapFrozenArrayToManagedType(FrozenArrayTypeDescription input, bool marshalled)
    {
        var elementType = input.IdlType.Single();
        var elementManagedType = Generate(elementType);

        if (marshalled)
        {
            return MakeNullableIfNeeded($"{elementManagedType}[]", input.Nullable);
        }

        var marshaller = genericMarshallerGenerator.GetOrCreateMarshaller(input with { Nullable = false });

        return MakeNullableIfNeeded(
            $"global::Iskra.JSCore.Generics.FrozenArray<{elementManagedType}, {marshaller}>",
            input.Nullable
        );
    }

    private string MapSequenceToManagedType(SequenceTypeDescription input, bool marshalled)
    {
        var elementType = input.IdlType.Single();
        var elementManagedType = Generate(elementType);

        if (marshalled)
        {
            return MakeNullableIfNeeded($"{elementManagedType}[]", input.Nullable);
        }

        var marshaller = genericMarshallerGenerator.GetOrCreateMarshaller(input with { Nullable = false });

        return MakeNullableIfNeeded(
            $"global::Iskra.JSCore.Generics.JSArray<{elementManagedType}, {marshaller}>",
            input.Nullable
        );
    }

    private string MapUnionToManagedType(UnionTypeDescription input)
    {
        var itemManagedTypes = input.IdlType
            .Select(x => Generate(x))
            .ToList();

        var marshaller = genericMarshallerGenerator.GetOrCreateMarshaller(input);
        var genericArgs = string.Join(", ", [..itemManagedTypes, marshaller]);

        return MakeNullableIfNeeded(
            $"global::Iskra.JSCore.Generics.Union<{genericArgs}>",
            input.Nullable
        );
    }

    private string MapToDotnetType(string input)
        => input switch
        {
            BuiltinTypes.Any => "object",
            BuiltinTypes.Undefined => "void",
            BuiltinTypes.Boolean => "bool",
            BuiltinTypes.Byte => "byte",
            BuiltinTypes.SignedByte => "sbyte",
            BuiltinTypes.Short => "short",
            BuiltinTypes.UnsignedShort => "ushort",
            BuiltinTypes.Int32 => "int",
            BuiltinTypes.UnsignedInt32 => "uint",
            BuiltinTypes.Int64 => "long",
            BuiltinTypes.UnsignedInt64 => "ulong",
            BuiltinTypes.Float => "float",
            BuiltinTypes.UnrestrictedFloat => "float",
            BuiltinTypes.Double => "double",
            BuiltinTypes.UnrestrictedDouble => "double",
            BuiltinTypes.String => "string",
            BuiltinTypes.Object => "JSObject",
            _ => MapReferenceToDotnetType(input),
        };

    private string MapReferenceToDotnetType(string input)
    {
        if (!genTypeDescriptors.TryGet(input, out var descriptor))
        {
            return $"UnknownNamespace.{input}";
        }

        return $"{descriptor.Namespace}.{descriptor.Name}";
    }
}