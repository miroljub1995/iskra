using System.Text.Json.Serialization;

namespace Iskra.WebIDLGenerator.Models;

public record Argument : AbstractBase
{
    [JsonPropertyName("default")] public required ValueDescription? Default { get; set; }

    [JsonPropertyName("optional")] public required bool Optional { get; set; }

    [JsonPropertyName("variadic")] public required bool Variadic { get; set; }

    [JsonPropertyName("idlType")] public required IDLTypeDescription IdlType { get; set; }

    [JsonPropertyName("name")] public required string Name { get; set; }

    public string ValidCSharpName => Name switch
    {
        "abstract" => "@abstract",
        "as" => "@as",
        "base" => "@base",
        "bool" => "@bool",
        "break" => "@break",
        "byte" => "@byte",
        "case" => "@case",
        "catch" => "@catch",
        "char" => "@char",
        "checked" => "@checked",
        "class" => "@class",
        "const" => "@const",
        "continue" => "@continue",
        "decimal" => "@decimal",
        "default" => "@default",
        "delegate" => "@delegate",
        "do" => "@do",
        "double" => "@double",
        "else" => "@else",
        "enum" => "@enum",
        "event" => "@event",
        "explicit" => "@explicit",
        "extern" => "@extern",
        "false" => "@false",
        "finally" => "@finally",
        "fixed" => "@fixed",
        "float" => "@float",
        "for" => "@for",
        "foreach" => "@foreach",
        "goto" => "@goto",
        "if" => "@if",
        "implicit" => "@implicit",
        "in" => "@in",
        "int" => "@int",
        "interface" => "@interface",
        "internal" => "@internal",
        "is" => "@is",
        "lock" => "@lock",
        "long" => "@long",
        "namespace" => "@namespace",
        "new" => "@new",
        "null" => "@null",
        "object" => "@object",
        "operator" => "@operator",
        "out" => "@out",
        "override" => "@override",
        "params" => "@params",
        "private" => "@private",
        "protected" => "@protected",
        "public" => "@public",
        "readonly" => "@readonly",
        "ref" => "@ref",
        "return" => "@return",
        "sbyte" => "@sbyte",
        "sealed" => "@sealed",
        "short" => "@short",
        "sizeof" => "@sizeof",
        "stackalloc" => "@stackalloc",
        "static" => "@static",
        "string" => "@string",
        "struct" => "@struct",
        "switch" => "@switch",
        "this" => "@this",
        "throw" => "@throw",
        "true" => "@true",
        "try" => "@try",
        "typeof" => "@typeof",
        "uint" => "@uint",
        "ulong" => "@ulong",
        "unchecked" => "@unchecked",
        "unsafe" => "@unsafe",
        "ushort" => "@ushort",
        "using" => "@using",
        "virtual" => "@virtual",
        "void" => "@void",
        "volatile" => "@volatile",
        "while" => "@while",
        _ => Name
    };
}