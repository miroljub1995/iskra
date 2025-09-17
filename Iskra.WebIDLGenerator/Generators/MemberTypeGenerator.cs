using Iskra.WebIDLGenerator.Models;
using Microsoft.Extensions.Logging;

namespace Iskra.WebIDLGenerator.Generators;

public class MemberTypeGenerator(
    ILogger<MemberTypeGenerator> logger,
    AttributeMemberTypeGenerator attributeMemberTypeGenerator
)
{
    public string Generate(IDLCallbackInterfaceMemberType input, string containingTypeName)
    {
        if (input is AttributeMemberType attributeMemberType)
        {
            return attributeMemberTypeGenerator.Generate(attributeMemberType, containingTypeName);
        }

        logger.LogWarning("Interface Member Type {type} is not handled.", input.GetType());
        return string.Empty;
    }
}