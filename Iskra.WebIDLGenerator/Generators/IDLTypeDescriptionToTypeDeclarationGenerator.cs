using Iskra.WebIDLGenerator.Models;
using Microsoft.Extensions.Logging;

namespace Iskra.WebIDLGenerator.Generators;

public class IDLTypeDescriptionToTypeDeclarationGenerator(
    ILogger<IDLTypeDescriptionToTypeDeclarationGenerator> logger,
    GenTypeDescriptors genTypeDescriptors
)
{
    public string Generate(IDLTypeDescription input)
    {
        if (input is SingleTypeDescription singleTypeDescription)
        {
            return MapSingleToManagedType(singleTypeDescription);
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