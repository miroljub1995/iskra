using System.Reflection;
using Iskra.StdWebApi.Attributes;

namespace Iskra.StdWebGenerator;

public static class ConstructorGenerator
{
    public static string? Execute(ConstructorInfo constructorInfo)
    {
        if (constructorInfo.IsDefined(typeof(ManualBindingAttribute)))
        {
            return null;
        }

        var typeName = TypeNameGenerator.Execute(constructorInfo.DeclaringType);
        var (paramsContent, parameters) = MethodParametersGenerator.Execute(constructorInfo);

        var content = $$"""
                        public {{typeName}}({{paramsContent}})
                            : this(JSConstructor.New("{{typeName}}", [{{string.Join(", ", parameters)}}]))
                        {
                        }
                        """;

        return content;
    }
}