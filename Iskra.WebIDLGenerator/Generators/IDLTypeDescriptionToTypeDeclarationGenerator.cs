using Iskra.WebIDLGenerator.Models;
using Microsoft.Extensions.Logging;

namespace Iskra.WebIDLGenerator.Generators;

public class IDLTypeDescriptionToTypeDeclarationGenerator(
    ILogger<IDLTypeDescriptionToTypeDeclarationGenerator> logger,
    GenSettings genSettings,
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

    private string RewriteTypeIfNeeded(string input)
    {
        return genSettings.TypeRewrite.GetValueOrDefault(input, input);
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
        var rewriteTypeIfNeeded = RewriteTypeIfNeeded(input.IdlType);
        var mapped = MapToDotnetType(rewriteTypeIfNeeded);
        return MakeNullableIfNeeded(mapped, input.Nullable || input.IdlType == "any");
    }

    private string MapToDotnetType(string input)
        => input switch
        {
            "any" => "object",
            "undefined" => "void",
            "boolean" => "bool",
            "octet" => "byte",
            "byte" => "sbyte",
            "short" => "short",
            "unsigned short" => "ushort",
            "long" => "int",
            "unsigned long" => "uint",
            "long long" => "long",
            "unsigned long long" => "ulong",
            "float" => "float",
            "unrestricted float" => "float",
            "double" => "double",
            "unrestricted double" => "double",
            "string" => "string",
            "object" => "JSObject",
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