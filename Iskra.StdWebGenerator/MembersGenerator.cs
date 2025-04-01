using System.Reflection;
using Iskra.StdWebApi.Attributes;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator;

public static class MembersGenerator
{
    public static string Execute(Type type, GeneratorContext context)
    {
        var members = type.GetMembers()
            .Where(x => x.DeclaringType == type)
            .Where(x => x is not MethodBase { IsPublic: false })
            .Where(x => x is not MethodInfo { IsSpecialName: true })
            .ToList();

        List<string> membersBody = [];

        if (type.GetCustomAttribute<AddToGlobalFactoryAttribute>() is { } addToFactoryAttr)
        {
            var body =
                $"WrapperFactory.AddGlobalFactory(\"{addToFactoryAttr.ConstructorName ?? type.Name}\", obj => new {type.Name}(obj));";

            var deps = AddToGlobalFactoryAttribute.GetDeps(type);
            if (deps.Length > 0)
            {
                body += "\n\n";
                body += string.Join("\n",
                    deps.Select(t =>
                        $"System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof({t.Name}).TypeHandle);"));
            }

            membersBody.Add($$"""
                              static {{type.Name}}()
                              {
                              {{body.IndentLines(4)}}
                              }
                              """);
        }

        foreach (var memberInfo in members)
        {
            var content = MemberGenerator.Execute(memberInfo, context);
            if (content is not null)
            {
                membersBody.Add(content);
            }
        }

        var res = string.Join("\n\n", membersBody);
        return res;
    }
}