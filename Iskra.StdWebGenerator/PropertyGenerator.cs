using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using Iskra.StdWebApi.Attributes;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator;

public static class PropertyGenerator
{
    public static string Execute(PropertyInfo propertyInfo)
    {
        var nullabilityInfo = new NullabilityInfoContext().Create(propertyInfo);
        var isNullable = (propertyInfo.CanRead ? nullabilityInfo.ReadState : nullabilityInfo.WriteState) ==
                         NullabilityState.Nullable;

        var jsName = JSPropertyNameGenerator.Execute(propertyInfo);
        var returnType = TypeNameGenerator.Execute(propertyInfo);
        var state = new NullabilityInfoContext().Create(propertyInfo); // TODO: remove, use nullabilityInfo
        var isJSObjectWrapper = propertyInfo.PropertyType.IsJSObjectWrapper();

        var indexParameters = propertyInfo.GetIndexParameters();
        MethodParametersGeneratorResult indexParametersRes = MethodParametersGenerator.Execute(indexParameters);

        var builder = new StringBuilder();

        if (indexParameters.Length > 0)
        {
            builder.AppendLine($$"""
                                 [System.Runtime.CompilerServices.IndexerName("Indexer")]
                                 public {{returnType}} this[{{indexParametersRes.Content}}]
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

            var jsObjectMethod = propertyInfo.PropertyType switch
            {
                _ when propertyInfo.PropertyType == typeof(bool) => "GetPropertyAsBoolean",
                _ when propertyInfo.PropertyType == typeof(int) => "GetPropertyAsInt32",
                _ when propertyInfo.PropertyType == typeof(long) => "GetPropertyAsInt64",
                _ when propertyInfo.PropertyType == typeof(double) => "GetPropertyAsDouble",
                _ when propertyInfo.PropertyType == typeof(string) => "GetPropertyAsString",
                _ when propertyInfo.PropertyType == typeof(JSObject) => "GetPropertyAsJSObject",
                _ when isJSObjectWrapper => "GetPropertyAsJSObject",
                _ => throw new NotSupportedException($"Property type {propertyInfo.PropertyType} is not supported.")
            };

            var returnValue = propertyInfo.PropertyType switch
            {
                _ when propertyInfo.PropertyType == typeof(bool) => "prop",
                _ when propertyInfo.PropertyType == typeof(int) => "prop",
                _ when propertyInfo.PropertyType == typeof(long) => "prop",
                _ when propertyInfo.PropertyType == typeof(double) => "prop",
                _ when propertyInfo.PropertyType == typeof(string) => "prop",
                _ when propertyInfo.PropertyType == typeof(JSObject) => "prop",
                _ when isJSObjectWrapper => $"WrapperFactory.GetWrapper<{returnType}>(prop)",
                _ => throw new NotSupportedException($"Property type {propertyInfo.PropertyType} is not supported.")
            };

            var postNullableCheck = propertyInfo.PropertyType.IsValueType
                ? ""
                : $$"""
                    {{"\n"}}if (prop is null)
                    {
                        throw new Exception("This should not happen. It is handled before.");
                    }
                    """;

            var actionOnNull = state.ReadState == NullabilityState.Nullable
                ? "return null;"
                : $"throw new Exception(\"The property {jsName} is null or not defined.\");";

            return $$"""
                     get
                     {
                         bool isNullOrUndefined = JSObject.IsNullOrUndefined("{{jsName}}");
                         if(isNullOrUndefined)
                         {
                            {{actionOnNull}}
                         }
                     
                         var prop = JSObject.{{jsObjectMethod}}("{{jsName}}");
                     {{postNullableCheck.IndentLines(4)}}
                     
                         return {{returnValue}};
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

            var value = isJSObjectWrapper
                ? isNullable
                    ? "value?.JSObject"
                    : "value.JSObject"
                : "value";

            return $$"""
                     set
                     {
                        JSObject.SetProperty("{{jsName}}", {{value}});
                     }
                     """;
        }
    }
}