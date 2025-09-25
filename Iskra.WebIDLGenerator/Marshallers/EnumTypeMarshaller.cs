using Iskra.WebIDLGenerator.Models;

namespace Iskra.WebIDLGenerator.Marshallers;

public class EnumTypeMarshaller(
    GenTypeDescriptors descriptors
)
{
    public string ToManaged(EnumType input, string inputVar, string outputVar)
    {
        var descriptor = descriptors.GetRequired(input.Name);

        return $$"""
                 {{outputVar}} = {{descriptor.Namespace}}.{{descriptor.Name}}.Create({{inputVar}});
                 """;
    }
}