using Iskra.WebIDLGenerator.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Iskra.WebIDLGenerator.Generators;

public class MemberTypeGenerator(
    IServiceProvider provider,
    ILogger<MemberTypeGenerator> logger
)
{
    public string Generate(IDLCallbackInterfaceMemberType input, string containingTypeName)
    {
        var attributeMemberTypeGenerator = provider.GetRequiredService<AttributeMemberTypeGenerator>();
        var operationMemberTypeGenerator = provider.GetRequiredService<OperationMemberTypeGenerator>();

        if (input is AttributeMemberType attributeMemberType)
        {
            return attributeMemberTypeGenerator.Generate(attributeMemberType, containingTypeName);
        }

        if (input is OperationMemberType operationMemberType)
        {
            List<string> operations =
            [
                operationMemberTypeGenerator.Generate(operationMemberType, containingTypeName)
            ];

            var args = operationMemberType.Arguments;
            while (args.Count > 0 && args[^1].Optional)
            {
                args = args[..^1];
                var newMemberType = operationMemberType with { Arguments = args };
                operations.Insert(0, operationMemberTypeGenerator.Generate(newMemberType, containingTypeName));
            }

            return string.Join("\n\n", operations);
        }

        logger.LogWarning("Interface Member Type {type} is not handled.", input.GetType());
        return string.Empty;
    }
}