using Iskra.WebIDLGenerator.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Iskra.WebIDLGenerator.Generators;

public class MemberTypeGenerator(
    IServiceProvider provider
)
{
    public string Generate(IDLCallbackInterfaceMemberType input, AbstractContainer container)
    {
        var attributeMemberTypeGenerator = provider.GetRequiredService<AttributeMemberTypeGenerator>();
        var constantMemberTypeGenerator = provider.GetRequiredService<ConstantMemberTypeGenerator>();
        var constructorMemberTypeGenerator = provider.GetRequiredService<ConstructorMemberTypeGenerator>();
        var operationMemberTypeGenerator = provider.GetRequiredService<OperationMemberTypeGenerator>();

        if (input is AttributeMemberType attributeMemberType)
        {
            return attributeMemberTypeGenerator.Generate(attributeMemberType, container);
        }

        if (input is ConstantMemberType constantMemberType)
        {
            return constantMemberTypeGenerator.Generate(constantMemberType);
        }

        if (input is ConstructorMemberType constructorMemberType)
        {
            List<string> constructors =
            [
                constructorMemberTypeGenerator.Generate(constructorMemberType, container)
            ];

            var args = constructorMemberType.Arguments;
            while (args.Count > 0 && args[^1].Optional)
            {
                args = args[..^1];
                var newMemberType = constructorMemberType with { Arguments = args };
                constructors.Insert(0, constructorMemberTypeGenerator.Generate(newMemberType, container));
            }

            return string.Join("\n\n", constructors);
        }

        if (input is IterableDeclarationMemberType iterableDeclarationMemberType)
        {
            return string.Empty;
        }

        if (input is AsyncIterableMemberType asyncIterableMemberType)
        {
            return string.Empty;
        }

        if (input is MaplikeDeclarationMemberType maplikeDeclarationMemberType)
        {
            return string.Empty;
        }

        if (input is SetlikeDeclarationMemberType setlikeDeclarationMemberType)
        {
            return string.Empty;
        }

        if (input is OperationMemberType operationMemberType)
        {
            List<string> operations =
            [
                operationMemberTypeGenerator.Generate(operationMemberType, container)
            ];

            var args = operationMemberType.Arguments;
            while (args.Count > 0 && args[^1].Optional)
            {
                args = args[..^1];
                var newMemberType = operationMemberType with { Arguments = args };
                operations.Insert(0, operationMemberTypeGenerator.Generate(newMemberType, container));
            }

            return string.Join("\n\n", operations);
        }

        throw new NotSupportedException($"Member Type {input.GetType()} is not handled.");
    }
}