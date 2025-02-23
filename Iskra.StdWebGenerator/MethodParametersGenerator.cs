using System.Reflection;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator;

public record MethodParametersGeneratorResult(
    string Content,
    string?[] ParamNamesWithDestructuredIfParams
);

public static class MethodParametersGenerator
{
    public static MethodParametersGeneratorResult Execute(MethodBase method)
        => Execute(method.GetParameters());

    public static MethodParametersGeneratorResult Execute(ParameterInfo[] parameters)
    {
        var content = string.Join(", ",
            parameters.Select(x => $"{TypeNameGenerator.Execute(x)} {x.Name}{DefaultValue(x)}"));

        return new MethodParametersGeneratorResult(
            Content: content,
            ParamNamesWithDestructuredIfParams: parameters.Select(GetParameterUsage).ToArray()
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

    private static string GetParameterUsage(ParameterInfo parameter)
    {
        var isDelegate = parameter.ParameterType.IsJSObjectWrapper() &&
                         parameter.ParameterType.IsSubclassOf(typeof(Delegate));

        if (parameter.IsDefinedAsParams())
        {
            return isDelegate
                ? $"..{parameter.Name}.Select(x => x.ToJSObject())"
                : $"..{parameter.Name}";
        }

        return isDelegate
            ? $"{parameter.Name}.ToJSObject()"
            : $"{parameter.Name}";
    }
}