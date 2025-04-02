using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebGenerator.Extensions;
using Iskra.StdWebGenerator.GeneratorContexts;
using Iskra.StdWebGenerator.JSObjectMarkers;

namespace Iskra.StdWebGenerator.Marshalling.Concrete;

public class MarshallerNoOp : Marshaller
{
    public override bool CanMarshall(MyType type, MyType destination)
        => type.Equals(destination)
           ||
           !type.IsNullable
           && !destination.IsNullable
           && ((type.Type == typeof(bool) || type.Type == typeof(string)) && destination.Type == typeof(ObjectForJS));

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