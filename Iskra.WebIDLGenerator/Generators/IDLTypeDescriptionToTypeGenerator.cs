using Iskra.WebIDLGenerator.Models;
using Microsoft.Extensions.Logging;

namespace Iskra.WebIDLGenerator.Generators;

public class IDLTypeDescriptionToTypeGenerator(
    ILogger<IDLTypeDescriptionToTypeGenerator> logger,
    GenSettings genSettings
)
{
    public string Generate(IDLTypeDescription input)
    {
        if (input is SingleTypeDescription singleTypeDescription)
        {
            var rewriteTypeIfNeeded = RewriteTypeIfNeeded(singleTypeDescription.IdlType);
            var mapped = MapToDotnetType(rewriteTypeIfNeeded);
            return MakeNullableIfNeeded(mapped, input.Nullable);
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

    private static string MapToDotnetType(string input)
        => input switch
        {
            "any" => "object",
            "boolean" => "bool",
            "octet" => "byte",
            "unsigned short" => "ushort",
            "long" => "int",
            "unsigned long" => "uint",
            "long long" => "long",
            "unsigned long long" => "ulong",
            "unrestricted float"  => "float",
            "unrestricted double" => "double",
            _ => input
        };
}