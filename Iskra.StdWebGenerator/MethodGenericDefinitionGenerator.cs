using System.Reflection;

namespace Iskra.StdWebGenerator;

public static class MethodGenericDefinitionGenerator
{
    public static string? Execute(MethodInfo methodInfo)
    {
        if (!methodInfo.IsGenericMethod)
        {
            return null;
        }

        var args = methodInfo.GetGenericArguments();
        var argsList = string.Join(", ", args.Select(x => TypeNameGenerator.Execute(x)));
        var res = $"<{argsList}>";

        return res;
    }
}