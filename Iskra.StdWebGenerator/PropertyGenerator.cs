using System.Reflection;
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

            var nullableCheck = isNullable
                ? """
                  if(prop is null)
                  {
                      return null;
                  }
                  """
                : $$"""
                    if (prop is null)
                    {
                        throw new Exception("The property {{jsName}} is not defined.");
                    }
                    """;

            return $$"""
                     get
                     {
                         var prop = JSObject.GetPropertyAsJSObject("{{jsName}}");

                     {{nullableCheck.IndentLines(4)}}
                     
                         return new {{returnType}}(prop);
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