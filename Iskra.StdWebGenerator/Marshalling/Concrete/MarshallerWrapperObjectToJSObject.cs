using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebGenerator.Extensions;
using Iskra.StdWebGenerator.GeneratorContexts;

namespace Iskra.StdWebGenerator.Marshalling.Concrete;

public class MarshallerWrapperObjectToJSObject : Marshaller
{
    public override bool CanMarshall(MyType type, MyType destination)
        => !type.IsNullable
           && !destination.IsNullable
           && type.Type.IsJSObjectWrapper()
           && destination.Type == typeof(JSObject);

    public override string Marshall(
        MyType inputType,
        string inputVar,
        MyType outputType,
        string outputVar,
        GeneratorContext context
    )
    {
        EnsureCanMarshall(inputType, outputType);

        return $$"""
                 {{outputVar}} = {{inputVar}}.JSObject;
                 """;
    }
}