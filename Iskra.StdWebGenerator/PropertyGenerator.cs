using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using Iskra.StdWebApi.Api;
using Iskra.StdWebApi.Attributes;
using Iskra.StdWebGenerator.Extensions;
using Iskra.StdWebGenerator.Marshalling;

namespace Iskra.StdWebGenerator;

public static class PropertyGenerator
{
    public static string Execute(PropertyInfo propertyInfo, GeneratorContext.GeneratorContext context)
    {
        MyType propertyType = MyType.From(propertyInfo);

        var jsName = JSPropertyNameGenerator.Execute(propertyInfo);
        var returnType = TypeNameGenerator.Execute(propertyType);

        var indexParameters = propertyInfo.GetIndexParameters();
        var indexParametersRes = MethodParametersGenerator.Execute(indexParameters);

        var builder = new StringBuilder();

        if (indexParameters.Length > 0)
        {
            builder.AppendLine($$"""
                                 [System.Runtime.CompilerServices.IndexerName("Indexer")]
                                 public {{returnType}} this[{{indexParametersRes}}]
                                 {
                                 """);
        }
        else
        {
            builder.AppendLine($$"""
                                 public {{returnType}} {{propertyInfo.Name}}
                                 {
                                 """);
        }

        if (DefineGetter() is { } getter)
        {
            builder.AppendLine(getter.IndentLines(4));
        }

        if (DefineSetter() is { } setter)
        {
            builder.AppendLine(setter.IndentLines(4));
        }

        builder.AppendLine("}");

        return builder.ToString();

        string? DefineGetter()
        {
            if (!propertyInfo.CanRead)
            {
                return null;
            }

            if (indexParameters.Length > 0)
            {
                var indexerAliasMethods = propertyInfo.GetCustomAttribute<IndexerAliasMethods>();
                if (indexerAliasMethods is null)
                {
                    throw new($"Currently only indexer alias methods are supported in property {propertyInfo}.");
                }

                return $"get => {indexerAliasMethods.Get}({string.Join(", ", indexParameters.Select(x => x.Name))});";
            }

            var resVar = context.GetNextVariableName();

            return $$"""
                     get
                     {
                         {{returnType}} {{resVar}};
                     {{PropertyGetGenerator.Execute(propertyType, "JSObject", resVar, jsName, context).IndentLines(4)}}
                         return {{resVar}};
                     }
                     """;
        }

        string? DefineSetter()
        {
            if (!propertyInfo.CanWrite)
            {
                return null;
            }

            if (indexParameters.Length > 0)
            {
                var indexerAliasMethods = propertyInfo.GetCustomAttribute<IndexerAliasMethods>();
                if (indexerAliasMethods is null)
                {
                    throw new($"Currently only indexer alias methods are supported in property {propertyInfo}.");
                }

                return $"set => {indexerAliasMethods.Set}({string.Join(", ", indexParameters.Select(x => x.Name))});";
            }

            return $$"""
                     set
                     {
                     {{PropertySetGenerator.Execute(propertyType, "JSObject", "value", jsName, context).IndentLines(4)}}
                     }
                     """;
        }
    }
}