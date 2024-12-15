using System.Reflection;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator;

public static class PropertyGenerator
{
    public static string Execute(PropertyInfo propertyInfo)
    {
        var jsName = JSPropertyNameGenerator.Execute(propertyInfo);
        var returnType = TypeNameGenerator.Execute(propertyInfo.PropertyType, propertyInfo);
        var isNullable = propertyInfo.PropertyType.IsNullable(propertyInfo);

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

        var res = $$"""
                    public {{returnType}} {{propertyInfo.Name}}
                    {
                        get
                        {
                            var prop = JSObject.GetPropertyAsJSObject("{{jsName}}");

                    {{nullableCheck.IndentLines(8)}}
                    
                            return new {{returnType}}(prop);
                        }
                    
                        set
                        {
                        }
                    } 
                    """;

        return res;
    }
}