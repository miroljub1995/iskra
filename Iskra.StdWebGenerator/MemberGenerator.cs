using System.Reflection;
using Iskra.StdWebGenerator.GeneratorContexts;

namespace Iskra.StdWebGenerator;

public static class MemberGenerator
{
    public static string? Execute(MemberInfo memberInfo, GeneratorContext context)
    {
        var content = memberInfo switch
        {
            ConstructorInfo constructorInfo => ConstructorGenerator.Execute(constructorInfo, context),
            MethodInfo methodInfo => MethodGenerator.Execute(methodInfo, context),
            PropertyInfo propertyInfo => PropertyGenerator.Execute(propertyInfo, context),
            _ => throw new NotSupportedException($"Member type {memberInfo.GetType()} is not supported.")
        };

        return content;
    }
}