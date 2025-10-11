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

        // if (input is OperationMemberType operationMemberType)
        // {
        //     return operationMemberTypeGenerator.Generate(operationMemberType, containingTypeName);
        // }

        logger.LogWarning("Interface Member Type {type} is not handled.", input.GetType());
        return string.Empty;
    }
}