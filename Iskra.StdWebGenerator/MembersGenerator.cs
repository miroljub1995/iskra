using System.Reflection;
using System.Text;

namespace Iskra.StdWebGenerator;

public static class MembersGenerator
{
    private static readonly HashSet<string> ExcludedMembers =
    [
        "GetType",
        "ToString",
        "Equals",
        "GetHashCode"
    ];

    public static string Execute(Type type)
    {
        List<string> membersBody = [];

        foreach (var memberInfo in type.GetMembers())
        {
            if (memberInfo is MethodInfo { IsSpecialName: true })
            {
                continue;
            }

            if (ExcludedMembers.Contains(memberInfo.Name))
            {
                continue;
            }

            var content = MemberGenerator.Execute(memberInfo);
            if (content is not null)
            {
                membersBody.Add(content);
            }
        }

        var res = string.Join("\n", membersBody);
        return res;
    }
}