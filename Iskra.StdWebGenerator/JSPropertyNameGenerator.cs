using System.Reflection;

namespace Iskra.StdWebGenerator;

public static class JSPropertyNameGenerator
{
    public static string Execute(MemberInfo memberInfo)
    {
        var res = char.ToLower(memberInfo.Name[0]) + memberInfo.Name[1..];

        return res;
    }
}