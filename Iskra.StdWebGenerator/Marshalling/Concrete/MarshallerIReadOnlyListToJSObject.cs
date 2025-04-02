using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebGenerator.Extensions;
using Iskra.StdWebGenerator.JSObjectMarkers;

namespace Iskra.StdWebGenerator.Marshalling.Concrete;

public class MarshallerIReadOnlyListToJSObject : Marshaller
{
    public override bool CanMarshall(MyType type, MyType destination)
        => !type.IsNullable
           && !destination.IsNullable
           && type.Type.IsIReadOnlyList()
           && destination.Type == typeof(JSObjectArray);

    public override string Marshall(
        MyType inputType,
        string inputVar,
        MyType outputType,
        string outputVar,
        GeneratorContext.GeneratorContext context
    )
    {
        EnsureCanMarshall(inputType, outputType);

        var loopVar = context.GetNextVariableName();
        var lengthVar = $"{inputVar}.Count";

        IReadOnlyList<MethodCallParam> setElementParameters =
        [
            new(outputType, outputVar),
            new(new(typeof(int), false, null, []), loopVar),
            new(inputType.GenericTypeArguments[0], $"{inputVar}[{loopVar}]")
        ];

        return $$"""
                 {{GlobalFunctionCallGenerator.Execute(
                     functionName: "globalThis.Array",
                     module: null,
                     parameters: [new(new(typeof(int), false, null, []), lengthVar)],
                     returnParam: new(Type: new(typeof(JSObject), false, null, []), outputVar),
                     context: context
                 )}}
                 for (int {{loopVar}} = 0; {{loopVar}} < {{lengthVar}}; {{loopVar}}++)
                 {
                 {{GlobalFunctionCallGenerator.Execute(
                     functionName: "globalThis.Reflect.set",
                     module: null,
                     parameters: setElementParameters,
                     returnParam: null,
                     context: context
                 ).IndentLines(4)}}
                 }
                 """;
    }
}