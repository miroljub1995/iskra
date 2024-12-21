using System.Reflection;

namespace Iskra.StdWebGenerator.Extensions;

public static class MethodInfoExtensions
{
    public static bool IsVoid(this MethodInfo methodInfo) => methodInfo.ReturnType == typeof(void);
}