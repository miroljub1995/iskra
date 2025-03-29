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
    public static string Execute(PropertyInfo propertyInfo, GeneratorContext context)
    {
        var nullabilityInfo = new NullabilityInfoContext().Create(propertyInfo);
        var nullabilityState = propertyInfo.CanRead ? nullabilityInfo.ReadState : nullabilityInfo.WriteState;
        var isNullable = nullabilityState == NullabilityState.Nullable;

        MyType propertyType = MyType.From(propertyInfo.PropertyType, nullabilityInfo, propertyInfo.CanRead);

        var jsName = JSPropertyNameGenerator.Execute(propertyInfo);
        var returnType = TypeNameGenerator.Execute(propertyInfo);
        var isJSObjectWrapper = propertyInfo.PropertyType.IsJSObjectWrapper();
        var isArray = propertyInfo.PropertyType.IsArray;

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

            var builder = new StringBuilder("""
                                            set
                                            {

                                            """
            );

            if (isNullable)
            {
                builder.Append($$"""
                      if (value is null)
                      {
                          JSObject.SetProperty("{{jsName}}", null as JSObject);
                          return;
                      }


                      """.IndentLines(4)
                );
            }

            if (isJSObjectWrapper)
            {
                builder.Append($$"""
                      JSObject.SetProperty("{{jsName}}", value{{(isNullable ? "?" : "")}}.JSObject);
                      """.IndentLines(4)
                );
            }
            else if (propertyInfo.PropertyType.IsGenericType &&
                     propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                builder.Append($$"""
                      JSObject.SetProperty("{{jsName}}", value.Value);

                      """.IndentLines(4)
                );
            }
            else
            {
                builder.Append($$"""
                      JSObject.SetProperty("{{jsName}}", value);

                      """.IndentLines(4)
                );
            }

            builder.AppendLine("}");
            return builder.ToString();

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