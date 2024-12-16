using System.Reflection;
using System.Text;

namespace Iskra.StdWebGenerator;

public static class MembersGenerator
{
    public static string Execute(Type type)
    {
        var members = type.GetMembers()
            .Where(x => x.DeclaringType == type)
            .Where(x => x is not MethodBase { IsPublic: false })
            .Where(x => x is not MethodInfo { IsSpecialName: true })
            .ToList();

        List<string> membersBody = [];
        foreach (var memberInfo in members)
        {
            var content = MemberGenerator.Execute(memberInfo);
            if (content is not null)
            {
                membersBody.Add(content);
            }
        }

        var res = string.Join("\n\n", membersBody);
        return res;
    }
}