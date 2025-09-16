using Iskra.WebIDLGenerator.Models;

namespace Iskra.WebIDLGenerator.Generators;

public class TypedefTypeFlattener
{
    private static HashSet<string> _terminalTypes =
    [
        "any",
        "boolean",
        "octet",
        "byte",
        "short",
        "unsigned short",
        "long",
        "unsigned long",
        "long long",
        "unsigned long long",
        "float",
        "unrestricted float",
        "double",
        "unrestricted double",
        "string",
        "object",
    ];

    public static IDLTypeDescription Flatten(IDLTypeDescription input, GenTypeDescriptors descriptors)
    {
        if (input is SingleTypeDescription singleTypeDescription)
        {
            if (_terminalTypes.Contains(singleTypeDescription.IdlType))
            {
                return input;
            }

            var des = descriptors.TryGet(singleTypeDescription.IdlType);
            if (des?.RootType is not TypedefType typedefType)
            {
                return input;
            }

            var flattenedIdlType = Flatten(typedefType.IdlType, descriptors);
            // TODO: preserve nullable to true
            return flattenedIdlType;
        }

        // TODO: handle more cases
        return input;
    }
}