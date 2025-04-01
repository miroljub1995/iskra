using System.Runtime.InteropServices.JavaScript;
using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator.Marshalling.Concrete;

public class MarshallerIReadOnlyListToJSObject : Marshaller
{
    public override bool CanMarshall(MyType type, MyType destination)
        => !type.IsNullable
           && !destination.IsNullable
           && type.Type.IsIReadOnlyList()
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

        var loopVar = context.GetNextVariableName();
        var lengthVar = $"{inputVar}.Count";

        IReadOnlyList<MethodCallParam> setElementParameters =
        [
            new(new(typeof(int), false, null, []), loopVar),
            new(new(typeof(int), false, null, []), "1"),
            new(inputType.GenericTypeArguments[0], $"{inputVar}[{loopVar}]")
        ];

        return $$"""
                 {{MethodCallGenerator.Execute(
                     objVar: "JSHost.GlobalThis",
                     functionName: "Array",
                     parameters: [new(new(typeof(int), false, null, []), lengthVar)],
                     returnParam: new(Type: new(typeof(JSObject), false, null, []), outputVar),
                     options: new(SkipFunctionChecks: true),
                     context: context
                 )}}
                 for (int {{loopVar}} = 0; {{loopVar}} < {{lengthVar}}; {{loopVar}}++)
                 {
                 {{MethodCallGenerator.Execute(
                     objVar: outputVar,
                     functionName: "splice",
                     parameters: setElementParameters,
                     returnParam: null,
                     options: new(SkipFunctionChecks: true),
                     context: context
                 ).IndentLines(4)}}
                 }
                 """;
    }
}