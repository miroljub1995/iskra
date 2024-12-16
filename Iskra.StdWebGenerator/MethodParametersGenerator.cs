using System.Reflection;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator;

public record MethodParametersGeneratorResult(string Content, string?[] ParamNames, string?[] ParamNamesWithDestructuredIfParams);

public static class MethodParametersGenerator
{
    public static MethodParametersGeneratorResult Execute(MethodBase method)
    {
        var parameters = method.GetParameters();

        var content = string.Join(", ",
            parameters.Select(x => $"{TypeNameGenerator.Execute(x.ParameterType, x)} {x.Name}{DefaultValue(x)}"));

        return new MethodParametersGeneratorResult(
            Content: content,
            ParamNames: parameters.Select(x => x.Name).ToArray(),
            ParamNamesWithDestructuredIfParams: parameters.Select(x => x.IsDefinedAsParams() ? $"..{x.Name}" : x.Name).ToArray()
        );
    }

    private static string DefaultValue(ParameterInfo parameter)
    {
        if (parameter.HasDefaultValue)
        {
            var value = parameter.DefaultValue switch
            {
                null => "null",
                _ => throw new Exception($"Default value {parameter.ParameterType} is not supported.")
            };

            return $" = {value}";
        }

        return "";
    }
}