using System.Reflection;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator;

public static class MethodParametersGenerator
{
    public static string Execute(MethodBase method)
        => Execute(method.GetParameters());

    public static string Execute(ParameterInfo[] parameters)
    {
        var content = string.Join(", ",
            parameters.Select((x, i) =>
                $"{AsParams(parameters, i)}{TypeNameGenerator.Execute(MyType.From(x))} {x.Name}{DefaultValue(x)}"));

        return content;
    }

    private static string AsParams(ParameterInfo[] parameters, int index)
    {
        if (index == parameters.Length - 1 && parameters[index].IsDefinedAsParams())
        {
            return "params ";
        }

        return string.Empty;
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