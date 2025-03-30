using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator.Marshalling.Concrete;

public class MarshallerNoOp : Marshaller
{
    // public override bool CanMarshall(MyType type, MyType destination)
    //     => type switch
    //     {
    //         _ when type.Type == typeof(bool) => false,
    //         // _ when type.Type == typeof(bool?) => false,
    //         _ when type.Type == typeof(int) => false,
    //         // _ when type.Type == typeof(int?) => false,
    //         _ when type.Type == typeof(long) => false,
    //         // _ when type.Type == typeof(long?) => false,
    //         _ when type.Type == typeof(double) => false,
    //         // _ when type.Type == typeof(double?) => false,
    //         _ when type.Type == typeof(string) => false,
    //         _ when type.Type == typeof(JSObject) => false,
    //         _ when type.Type.IsOneOf() => false,
    //         _ => true,
    //     };

    public override bool CanMarshall(MyType type, MyType destination) => type.Equals(destination);

    public override string Marshall(
        MyType inputType,
        string inputVar,
        MyType outputType,
        string outputVar,
        GeneratorContext context
    )
    {
        EnsureCanMarshall(inputType, outputType);

        return $"{outputVar} = {inputVar};";
    }
}