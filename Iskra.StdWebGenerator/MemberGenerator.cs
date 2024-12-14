using System.Reflection;

namespace Iskra.StdWebGenerator;

public static class MemberGenerator
{
    public static string? Execute(MemberInfo memberInfo)
    {
        var content = memberInfo switch
        {
            ConstructorInfo constructorInfo => ConstructorGenerator.Execute(constructorInfo),
            _ => throw new NotSupportedException($"Member type {memberInfo.GetType()} is not supported.")
        };

        return content;
    }
}