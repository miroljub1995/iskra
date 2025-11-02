using Iskra.WebIDLGenerator.Extensions;
using Iskra.WebIDLGenerator.Models;
using Iskra.WebIDLGenerator.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Iskra.WebIDLGenerator.Generators;

public class PropertyAccessorGenerator(
    IServiceProvider provider,
    GenSettings genSettings
)
{
    private readonly List<KeyValuePair<IDLTypeDescription, string>> _accessors = [];

    public string GetOrCreateAccessor(IDLTypeDescription input)
    {
        var value = TryFind(input);
        if (value is not null)
        {
            return value;
        }

        value = input switch
        {
            { Nullable: true } => $"global::{genSettings.Namespace}.PropertyAccessorNullable",
            _ => $"global::{genSettings.Namespace}.PropertyAccessor",
        };

        _accessors.Add(new KeyValuePair<IDLTypeDescription, string>(input, value));

        return value;
    }

    public async Task GenerateAsync(CancellationToken cancellationToken = default)
    {
        await GenerateNullableAsync(cancellationToken);
        await GenerateNonNullableAsync(cancellationToken);
    }

    private async Task GenerateNullableAsync(CancellationToken cancellationToken = default)
    {
        var toTypeDeclarationGenerator =
            provider.GetRequiredService<IDLTypeDescriptionToTypeDeclarationGenerator>();
        var getPropertyValueGenerator =
            provider.GetRequiredService<GetPropertyValueGenerator>();
        var setPropertyValueGenerator =
            provider.GetRequiredService<SetPropertyValueGenerator>();

        List<string> interfaceParts = [];
        List<string> bodyParts = [];

        // Do not convert to foreach, new item could be added during iteration.
        for (var i = 0; i < _accessors.Count; i++)
        {
            var accessor = _accessors[i];
            if (!accessor.Key.Nullable)
            {
                continue;
            }

            var elementVar = VariableName.Current.GetNext("element");

            string getByIndexElementContent;
            using (VariableName.CreateScope())
            {
                getByIndexElementContent = getPropertyValueGenerator.Generate(
                    inputVar: "obj",
                    type: accessor.Key,
                    propertyNameVar: "propertyIndex",
                    outputVar: elementVar
                );
            }

            string getByNameElementContent;
            using (VariableName.CreateScope())
            {
                getByNameElementContent = getPropertyValueGenerator.Generate(
                    inputVar: "obj",
                    type: accessor.Key,
                    propertyNameVar: "propertyName",
                    outputVar: elementVar
                );
            }

            string setElementByIndexContent;
            using (VariableName.CreateScope())
            {
                setElementByIndexContent = setPropertyValueGenerator.Generate(
                    inputVar: "obj",
                    valueVar: "value",
                    type: accessor.Key,
                    propertyNameVar: "propertyIndex"
                );
            }

            string setElementByNameContent;
            using (VariableName.CreateScope())
            {
                setElementByNameContent = setPropertyValueGenerator.Generate(
                    inputVar: "obj",
                    valueVar: "value",
                    type: accessor.Key,
                    propertyNameVar: "propertyName"
                );
            }

            var elementTypeDesc = toTypeDeclarationGenerator.Generate(accessor.Key);

            var interfacePart = $"global::Iskra.JSCore.Generics.IPropertyAccessor<{elementTypeDesc}>";
            interfaceParts.Add(interfacePart);

            var bodyPart = $$"""
                             static {{elementTypeDesc}} {{interfacePart}}.Get(global::System.Runtime.InteropServices.JavaScript.JSObject obj, int propertyIndex)
                             {
                                 {{elementTypeDesc}} {{elementVar}};
                             {{getByIndexElementContent.IndentLines(4)}}
                                 return {{elementVar}};
                             }

                             static {{elementTypeDesc}} {{interfacePart}}.Get(global::System.Runtime.InteropServices.JavaScript.JSObject obj, string propertyName)
                             {
                                 {{elementTypeDesc}} {{elementVar}};
                             {{getByNameElementContent.IndentLines(4)}}
                                 return {{elementVar}};
                             }

                             static void {{interfacePart}}.Set(global::System.Runtime.InteropServices.JavaScript.JSObject obj, int propertyIndex, {{elementTypeDesc}} value)
                             {
                             {{setElementByIndexContent.IndentLines(4)}}
                             }

                             static void {{interfacePart}}.Set(global::System.Runtime.InteropServices.JavaScript.JSObject obj, string propertyName, {{elementTypeDesc}} value)
                             {
                             {{setElementByNameContent.IndentLines(4)}}
                             }
                             """;

            bodyParts.Add(bodyPart);
        }

        var interfaces = string.Join(",\n", interfaceParts);
        var body = string.Join("\n\n", bodyParts);

        var inheritance = interfaceParts.Count > 0
            ? $$"""
                :
                {{interfaces.IndentLines(4)}}
                """
            : string.Empty;

        var content = $$"""
                        // <auto-generated/>

                        namespace {{genSettings.Namespace}};

                        #nullable enable

                        public class PropertyAccessorNullable{{inheritance}}
                        {
                        {{body.IndentLines(4)}}
                        }

                        #nullable disable

                        """;

        var outputFile = Path.GetFullPath(Path.Combine(genSettings.Output, "PropertyAccessorNullable.cs"));
        if (File.Exists(outputFile))
        {
            throw new Exception($"Output file {outputFile} already exists.");
        }

        await File.WriteAllTextAsync(outputFile, content, cancellationToken);
    }

    private async Task GenerateNonNullableAsync(CancellationToken cancellationToken = default)
    {
        var toTypeDeclarationGenerator =
            provider.GetRequiredService<IDLTypeDescriptionToTypeDeclarationGenerator>();
        var getPropertyValueGenerator =
            provider.GetRequiredService<GetPropertyValueGenerator>();
        var setPropertyValueGenerator =
            provider.GetRequiredService<SetPropertyValueGenerator>();

        List<string> interfaceParts = [];
        List<string> bodyParts = [];

        // Do not convert to foreach, new item could be added during iteration.
        for (var i = 0; i < _accessors.Count; i++)
        {
            var accessor = _accessors[i];
            if (accessor.Key.Nullable)
            {
                continue;
            }

            var elementVar = VariableName.Current.GetNext("element");

            string getByIndexElementContent;
            using (VariableName.CreateScope())
            {
                getByIndexElementContent = getPropertyValueGenerator.Generate(
                    inputVar: "obj",
                    type: accessor.Key,
                    propertyNameVar: "propertyIndex",
                    outputVar: elementVar
                );
            }

            string getByNameElementContent;
            using (VariableName.CreateScope())
            {
                getByNameElementContent = getPropertyValueGenerator.Generate(
                    inputVar: "obj",
                    type: accessor.Key,
                    propertyNameVar: "propertyName",
                    outputVar: elementVar
                );
            }

            string setElementByIndexContent;
            using (VariableName.CreateScope())
            {
                setElementByIndexContent = setPropertyValueGenerator.Generate(
                    inputVar: "obj",
                    valueVar: "value",
                    type: accessor.Key,
                    propertyNameVar: "propertyIndex"
                );
            }

            string setElementByNameContent;
            using (VariableName.CreateScope())
            {
                setElementByNameContent = setPropertyValueGenerator.Generate(
                    inputVar: "obj",
                    valueVar: "value",
                    type: accessor.Key,
                    propertyNameVar: "propertyName"
                );
            }

            var elementTypeDesc = toTypeDeclarationGenerator.Generate(accessor.Key);

            var interfacePart = $"global::Iskra.JSCore.Generics.IPropertyAccessor<{elementTypeDesc}>";
            interfaceParts.Add(interfacePart);

            var bodyPart = $$"""
                             static {{elementTypeDesc}} {{interfacePart}}.Get(global::System.Runtime.InteropServices.JavaScript.JSObject obj, int propertyIndex)
                             {
                                 {{elementTypeDesc}} {{elementVar}};
                             {{getByIndexElementContent.IndentLines(4)}}
                                 return {{elementVar}};
                             }

                             static {{elementTypeDesc}} {{interfacePart}}.Get(global::System.Runtime.InteropServices.JavaScript.JSObject obj, string propertyName)
                             {
                                 {{elementTypeDesc}} {{elementVar}};
                             {{getByNameElementContent.IndentLines(4)}}
                                 return {{elementVar}};
                             }

                             static void {{interfacePart}}.Set(global::System.Runtime.InteropServices.JavaScript.JSObject obj, int propertyIndex, {{elementTypeDesc}} value)
                             {
                             {{setElementByIndexContent.IndentLines(4)}}
                             }

                             static void {{interfacePart}}.Set(global::System.Runtime.InteropServices.JavaScript.JSObject obj, string propertyName, {{elementTypeDesc}} value)
                             {
                             {{setElementByNameContent.IndentLines(4)}}
                             }
                             """;

            bodyParts.Add(bodyPart);
        }

        var interfaces = string.Join(",\n", interfaceParts);
        var body = string.Join("\n\n", bodyParts);

        var inheritance = interfaceParts.Count > 0
            ? $$"""
                :
                {{interfaces.IndentLines(4)}}
                """
            : string.Empty;

        var content = $$"""
                        // <auto-generated/>

                        namespace {{genSettings.Namespace}};

                        #nullable enable

                        public class PropertyAccessor{{inheritance}}
                        {
                        {{body.IndentLines(4)}}
                        }

                        #nullable disable

                        """;


        var outputFile = Path.GetFullPath(Path.Combine(genSettings.Output, "PropertyAccessor.cs"));
        if (File.Exists(outputFile))
        {
            throw new Exception($"Output file {outputFile} already exists.");
        }

        await File.WriteAllTextAsync(outputFile, content, cancellationToken);
    }

    private string? TryFind(IDLTypeDescription input)
    {
        foreach (var kvp in _accessors)
        {
            if (IDLTypeDescriptionEqualityComparer.Instance.Equals(input, kvp.Key))
            {
                return kvp.Value;
            }
        }

        return null;
    }
}