using Iskra.WebIDLGenerator.Models;
using Microsoft.Extensions.Logging;

namespace Iskra.WebIDLGenerator.Generators;

public class IDLInterfaceMemberTypeGenerator(
    ILogger<IDLInterfaceMemberTypeGenerator> logger,
    AttributeMemberTypeGenerator attributeMemberTypeGenerator
)
{
    public string Generate(IDLInterfaceMemberType input)
    {
        if (input is AttributeMemberType attributeMemberType)
        {
            return attributeMemberTypeGenerator.Generate(attributeMemberType);
        }

        logger.LogWarning("Interface Member Type {type} is not handled.", input.GetType());
        return string.Empty;
    }
}