using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using Iskra.StdWebApi.Api;
using Iskra.StdWebApi.Attributes;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator;

public static class PropertyGenerator
{
    public static string Execute(PropertyInfo propertyInfo, GeneratorContext context)
    {
        var nullabilityInfo = new NullabilityInfoContext().Create(propertyInfo);
        var nullabilityState = propertyInfo.CanRead ? nullabilityInfo.ReadState : nullabilityInfo.WriteState;
        var isNullable = nullabilityState == NullabilityState.Nullable;

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

            var res = PropertyGetGenerator.Execute(
                new(
                    Type: propertyInfo.PropertyType,
                    NullabilityInfo: nullabilityInfo,
                    IsFromReadState: propertyInfo.CanRead
                ),
                "JSObject",
                jsName,
                context
            );

            return $$"""
                     get
                     {
                     {{res.Output.IndentLines(4)}}
                     
                        return {{res.OutputVar}};
                     }
                     """;

            var marshallerOutRes = MarshallerOutGenerator.Execute(
                new(
                    Type: propertyInfo.PropertyType,
                    NullabilityInfo: nullabilityInfo,
                    IsFromReadState: propertyInfo.CanRead
                ),
                "prop"
            );

            var propertyMethodName = context.ObjectMethods.GetterPropertyMethodName(
                marshallerOutRes.InputType.Type,
                marshallerOutRes.InputType.NullabilityInfo,
                marshallerOutRes.InputType.IsFromReadState
            );

            return $$"""
                     get
                     {
                        var prop = JSObject.{{propertyMethodName}}("{{jsName}}");
                        return {{marshallerOutRes.Output}};
                     }
                     """;


            // var typeForPropertyName = isJSObjectWrapper
            //     ? typeof(JSObject)
            //     : propertyInfo.PropertyType;

            // var typeForPropertyName = propertyInfo.PropertyType switch
            // {
            //     _ when isJSObjectWrapper => typeof(JSObject),
            //     _ when isArray && propertyInfo.PropertyType.GetElementType()?.IsJSObjectWrapper() == true =>
            //         typeof(JSObject),
            //     _ => propertyInfo.PropertyType,
            // };

            // var propertyMethodName =
            //     context.ObjectMethods.GetterPropertyMethodName(typeForPropertyName, nullabilityInfo,
            //         propertyInfo.CanRead);

            var propConversion = isJSObjectWrapper
                ? $"WrapperFactory.GetWrapper<{returnType}>(prop)"
                : "prop";

            return $$"""
                     get
                     {
                        var prop = JSObject.{{propertyMethodName}}("{{jsName}}");
                        return {{propConversion}};
                     }
                     """;

            var jsObjectMethod = propertyInfo.PropertyType switch
            {
                _ when propertyInfo.PropertyType == typeof(bool) => "GetPropertyAsBoolean",
                _ when propertyInfo.PropertyType == typeof(bool?) => "GetPropertyAsBoolean",
                _ when propertyInfo.PropertyType == typeof(int) => "GetPropertyAsInt32",
                _ when propertyInfo.PropertyType == typeof(int?) => "GetPropertyAsInt32",
                _ when propertyInfo.PropertyType == typeof(long) => "GetPropertyAsInt64",
                _ when propertyInfo.PropertyType == typeof(long?) => "GetPropertyAsInt64",
                _ when propertyInfo.PropertyType == typeof(double) => "GetPropertyAsDouble",
                _ when propertyInfo.PropertyType == typeof(double?) => "GetPropertyAsDouble",
                _ when propertyInfo.PropertyType == typeof(string) => "GetPropertyAsString",
                _ when propertyInfo.PropertyType == typeof(JSObject) => "GetPropertyAsJSObject",
                _ when isJSObjectWrapper => "GetPropertyAsJSObject",
                _ when propertyInfo.PropertyType.IsGenericType &&
                       propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(OneOf<,>) => "GetPropertyAsOneOf",
                _ when isArray => "GetPropertyAsJSObject",
                _ => throw new NotSupportedException($"Property type {propertyInfo.PropertyType} is not supported.")
            };

            var returnValue = propertyInfo.PropertyType switch
            {
                _ when propertyInfo.PropertyType == typeof(bool) => "prop",
                _ when propertyInfo.PropertyType == typeof(bool?) => "prop",
                _ when propertyInfo.PropertyType == typeof(int) => "prop",
                _ when propertyInfo.PropertyType == typeof(int?) => "prop",
                _ when propertyInfo.PropertyType == typeof(long) => "prop",
                _ when propertyInfo.PropertyType == typeof(long?) => "prop",
                _ when propertyInfo.PropertyType == typeof(double) => "prop",
                _ when propertyInfo.PropertyType == typeof(double?) => "prop",
                _ when propertyInfo.PropertyType == typeof(string) => "prop",
                _ when propertyInfo.PropertyType == typeof(JSObject) => "prop",
                _ when isJSObjectWrapper => $"WrapperFactory.GetWrapper<{returnType}>(prop)",
                _ when propertyInfo.PropertyType.IsGenericType &&
                       propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(OneOf<,>) => "GetOneOf(prop)",
                _ when isArray => "GetDotnetArray(prop)",
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

            var actionOnNull = nullabilityInfo.ReadState == NullabilityState.Nullable
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