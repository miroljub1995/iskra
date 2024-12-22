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

        if (constructorInfo.DeclaringType is null)
        {
            throw new Exception($"Declaring type {constructorInfo.DeclaringType} is not defined.");
        }

        var typeName = TypeNameGenerator.Execute(constructorInfo.DeclaringType, null);
        var (paramsContent, paramNamesWithDestructuredIfParams) = MethodParametersGenerator.Execute(constructorInfo);

        var content = $$"""
                        public {{typeName}}({{paramsContent}})
                            : this(JSConstructor.New("{{typeName}}", [{{string.Join(", ", paramNamesWithDestructuredIfParams)}}]))
                        {
                        }
                        """;

        return content;
    }
}