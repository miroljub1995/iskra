using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator.Marshalling.Concrete;

public class MarshallerJSObjectToIReadOnlyList : Marshaller
{
    public override bool CanMarshall(MyType type, MyType destination)
        => !type.IsNullable
           && !destination.IsNullable
           && type.Type == typeof(JSObject)
           && destination.Type.IsIReadOnlyList();

    public override string Marshall(MyType inputType, string inputVar, MyType outputType, string outputVar,
        GeneratorContext context)
    {
        EnsureCanMarshall(inputType, outputType);

        var lengthVar = context.GetNextVariableName();

        return $$"""
                 int {{lengthVar}} = {{inputVar}}.GetPropertyAsInt32("length");
                 {{outputVar}} = ToList({{inputVar}});
                 """;
    }
}