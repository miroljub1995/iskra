using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator.Marshalling.Concrete;

public class MarshallerOneOfJSObject : Marshaller
{
    public override bool CanMarshall(MyType type, MyType destination)
        => !type.IsNullable
           && !destination.IsNullable
           && type.Type.IsOneOf()
           && destination.Type == typeof(JSObject);

    public override string Marshall(MyType inputType, string inputVar, MyType outputType, string outputVar,
        GeneratorContext context)
    {
        EnsureCanMarshall(inputType, outputType);

        return $$"""
                 {{outputVar}} = ToJSObject({{inputVar}});
                 """;
    }
}