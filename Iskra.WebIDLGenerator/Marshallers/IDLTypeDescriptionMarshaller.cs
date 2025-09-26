using Iskra.StdWebGenerator.GeneratorContexts;
using Iskra.WebIDLGenerator.Generators;
using Iskra.WebIDLGenerator.Models;

namespace Iskra.WebIDLGenerator.Marshallers;

public partial class IDLTypeDescriptionMarshaller(
    GenTypeDescriptors descriptors,
    GeneratorContext context,
    IServiceProvider provider
)
{
    public string ToManaged(
        IDLTypeDescription inputType,
        string inputVar,
        IDLTypeDescription outputType,
        string outputVar
    )
    {
        if (outputType.Nullable)
        {
            return ToManagedNullable(inputType, inputVar, outputType, outputVar);
        }

        if (outputType is SingleTypeDescription singleTypeDescription)
        {
            // No marshalling
            if (singleTypeDescription.IdlType is
                BuiltinTypes.Any or
                BuiltinTypes.Boolean or
                BuiltinTypes.String or
                BuiltinTypes.Double or
                BuiltinTypes.UnrestrictedDouble or
                BuiltinTypes.Object
               )
            {
                return $$"""
                         {{outputVar}} = {{inputVar}};
                         """;
            }

            if (singleTypeDescription.IdlType is BuiltinTypes.Octet)
            {
                return $$"""
                         {{outputVar}} = Convert.ToByte({{inputVar}});
                         """;
            }

            if (singleTypeDescription.IdlType is BuiltinTypes.Byte)
            {
                return $$"""
                         {{outputVar}} = Convert.ToSByte({{inputVar}});
                         """;
            }

            if (singleTypeDescription.IdlType is BuiltinTypes.Short)
            {
                return $$"""
                         {{outputVar}} = Convert.ToInt16({{inputVar}});
                         """;
            }

            if (singleTypeDescription.IdlType is BuiltinTypes.Long)
            {
                return $$"""
                         {{outputVar}} = Convert.ToInt32({{inputVar}});
                         """;
            }

            if (singleTypeDescription.IdlType is BuiltinTypes.UnsignedLong)
            {
                return $$"""
                         {{outputVar}} = Convert.ToUInt32({{inputVar}});
                         """;
            }

            if (singleTypeDescription.IdlType is BuiltinTypes.LongLong)
            {
                return $$"""
                         {{outputVar}} = Convert.ToInt64({{inputVar}});
                         """;
            }

            if (singleTypeDescription.IdlType is BuiltinTypes.UnsignedLongLong)
            {
                return $$"""
                         {{outputVar}} = Convert.ToUInt64({{inputVar}});
                         """;
            }

            if (singleTypeDescription.IdlType is BuiltinTypes.Float or BuiltinTypes.UnrestrictedFloat)
            {
                return $$"""
                         {{outputVar}} = Convert.ToSingle({{inputVar}});
                         """;
            }
        }

        return $$"""
                 throw new Exception("Marshaller ToManaged from \"{{inputVar}}\" to \"{{outputVar}}\" not supported.");
                 """;
    }

    public string ToJS(
        IDLTypeDescription inputType,
        string inputVar,
        IDLTypeDescription outputType,
        string outputVar
    )
    {
        if (outputType.Nullable)
        {
            return ToJSNullable(inputType, inputVar, outputType, outputVar);
        }

        if (outputType is SingleTypeDescription singleTypeDescription)
        {
            // No marshalling
            if (singleTypeDescription.IdlType is
                BuiltinTypes.Any or
                BuiltinTypes.Boolean or
                BuiltinTypes.String or
                BuiltinTypes.Double or
                BuiltinTypes.UnrestrictedDouble or
                BuiltinTypes.Object
               )
            {
                return $$"""
                         {{outputVar}} = {{inputVar}};
                         """;
            }
        }

        return $$"""
                 throw new Exception("Marshaller ToJS from \"{{inputVar}}\" to \"{{outputVar}}\" not supported.");
                 """;
    }
}