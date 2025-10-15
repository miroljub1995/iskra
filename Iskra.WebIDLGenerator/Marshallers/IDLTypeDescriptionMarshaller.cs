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

            if (singleTypeDescription.IdlType is BuiltinTypes.Byte)
            {
                return $$"""
                         {{outputVar}} = Convert.ToByte({{inputVar}});
                         """;
            }

            if (singleTypeDescription.IdlType is BuiltinTypes.SignedByte)
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

            if (singleTypeDescription.IdlType is BuiltinTypes.UnsignedShort)
            {
                return $$"""
                         {{outputVar}} = Convert.ToUInt16({{inputVar}});
                         """;
            }

            if (singleTypeDescription.IdlType is BuiltinTypes.Int32)
            {
                return $$"""
                         {{outputVar}} = Convert.ToInt32({{inputVar}});
                         """;
            }

            if (singleTypeDescription.IdlType is BuiltinTypes.UnsignedInt32)
            {
                return $$"""
                         {{outputVar}} = Convert.ToUInt32({{inputVar}});
                         """;
            }

            if (singleTypeDescription.IdlType is BuiltinTypes.Int64)
            {
                return $$"""
                         {{outputVar}} = Convert.ToInt64({{inputVar}});
                         """;
            }

            if (singleTypeDescription.IdlType is BuiltinTypes.UnsignedInt64)
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

            if (descriptors.TryGet(singleTypeDescription.IdlType, out var descriptor))
            {
                if (descriptor.RootType is EnumType)
                {
                    return $$"""
                             {{outputVar}} = global::{{descriptor.Namespace}}.{{descriptor.Name}}.Create({{inputVar}});
                             """;
                }

                if (descriptor.RootType is InterfaceType)
                {
                    return $$"""
                             {{outputVar}} = global::Iskra.JSCore.JSObjectProxyFactory.GetProxy<global::{{descriptor.Namespace}}.{{descriptor.Name}}>({{inputVar}});
                             """;
                }

                if (descriptor.RootType is CallbackInterfaceType)
                {
                    return $$"""
                             {{outputVar}} = global::Iskra.JSCore.JSObjectProxyFactory.GetProxy<global::{{descriptor.Namespace}}.{{descriptor.Name}}>({{inputVar}});
                             """;
                }
            }
        }

        return $$"""
                 throw new Exception("Marshaller ToManaged from {{inputType}} to {{outputType}} not supported.");
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

        if (inputType is SingleTypeDescription singleTypeDescription)
        {
            // No marshalling
            if (singleTypeDescription.IdlType is
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


            if (singleTypeDescription.IdlType is
                BuiltinTypes.Byte or
                BuiltinTypes.SignedByte or
                BuiltinTypes.Short or
                BuiltinTypes.UnsignedShort or
                BuiltinTypes.Int32 or
                BuiltinTypes.UnsignedInt32 or
                BuiltinTypes.Int64 or
                BuiltinTypes.UnsignedInt64 or
                BuiltinTypes.Float or
                BuiltinTypes.UnrestrictedFloat
               )
            {
                return $$"""
                         {{outputVar}} = Convert.ToDouble({{inputVar}});
                         """;
            }

            if (descriptors.TryGet(singleTypeDescription.IdlType, out var descriptor))
            {
                if (descriptor.RootType is EnumType)
                {
                    return $$"""
                             {{outputVar}} = {{inputVar}}.ToString();
                             """;
                }

                if (descriptor.RootType is InterfaceType)
                {
                    return $$"""
                             {{outputVar}} = {{inputVar}}.JSObject;
                             """;
                }

                if (descriptor.RootType is CallbackInterfaceType)
                {
                    return $$"""
                             {{outputVar}} = {{inputVar}}.JSObject;
                             """;
                }
            }
        }

        return $$"""
                 throw new Exception("Marshaller ToJS from {{inputType}} to {{outputType}} not supported.");
                 """;
    }
}