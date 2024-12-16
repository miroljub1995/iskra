using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator;

public static class PropertyGenerator
{
    public static string Execute(PropertyInfo propertyInfo)
    {
        var jsName = JSPropertyNameGenerator.Execute(propertyInfo);
        var returnType = TypeNameGenerator.Execute(propertyInfo.PropertyType, propertyInfo);
        var isNullable = propertyInfo.PropertyType.IsNullable(propertyInfo);
        var isJSObjectWrapper = propertyInfo.PropertyType.IsJSObjectWrapper();

        var builder = new StringBuilder();
        builder.AppendLine($$"""
                             public {{returnType}} {{propertyInfo.Name}}
                             {
                             """);

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
                _ when isJSObjectWrapper => $"new {returnType}(prop)",
                _ => throw new NotSupportedException($"Property type {propertyInfo.PropertyType} is not supported.")
            };

            var nullableCheck = isNullable
                ? """
                  if(prop is null)
                  {
                      return null;
                  }
                  """
                : propertyInfo.PropertyType.IsValueType
                    ? ""
                    : $$"""
                        if (prop is null)
                        {
                            throw new Exception("The property {{jsName}} is not defined.");
                        }
                        """;

            return $$"""
                     get
                     {
                         var prop = JSObject.{{jsObjectMethod}}("{{jsName}}");

                     {{nullableCheck.IndentLines(4)}}
                     
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