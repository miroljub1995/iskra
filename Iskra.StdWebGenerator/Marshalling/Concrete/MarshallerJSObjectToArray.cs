using System.Runtime.InteropServices.JavaScript;

namespace Iskra.StdWebGenerator.Marshalling.Concrete;

public class MarshallerJSObjectToArray : Marshaller
{
    public override bool CanMarshall(MyType type, MyType destination)
        => !type.IsNullable
           && !destination.IsNullable
           && type.Type == typeof(JSObject)
           && destination.Type.IsArray;

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
                 {{outputVar}} = ToArray({{inputVar}});
                 """;
    }
}