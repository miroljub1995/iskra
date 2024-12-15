using System.Reflection;

namespace Iskra.StdWebGenerator;

public record MethodParametersGeneratorResult(string Content, string?[] ParamNames);

public static class MethodParametersGenerator
{
    public static MethodParametersGeneratorResult Execute(MethodBase method)
    {
        var parameters = method.GetParameters();

        var content = string.Join(", ",
            parameters.Select(x => $"{TypeNameGenerator.Execute(x.ParameterType, x)} {x.Name}"));

        return new MethodParametersGeneratorResult(
            Content: content,
            ParamNames: parameters.Select(x => x.Name).ToArray()
        );
    }
}