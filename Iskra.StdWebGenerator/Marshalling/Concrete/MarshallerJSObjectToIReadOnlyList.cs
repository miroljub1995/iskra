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

        var elementType = outputType.GenericTypeArguments[0];
        var elementTypeName = TypeNameGenerator.Execute(elementType);

        var outputArrayTypeName = TypeNameGenerator.Execute(new MyType(
            Type: elementType.Type.MakeArrayType(),
            IsNullable: outputType.IsNullable,
            ElementType: elementType,
            GenericTypeArguments: []
        ));
        var outputArrayVar = context.GetNextVariableName();

        var loopVar = context.GetNextVariableName();

        return $$"""
                 int {{lengthVar}} = {{inputVar}}.GetPropertyAsInt32("length");
                 {{outputArrayTypeName}} {{outputArrayVar}} = new {{elementTypeName}}[{{lengthVar}}];
                 for (int {{loopVar}} = 0; {{loopVar}} < {{lengthVar}}; {{loopVar}}++)
                 {
                 {{MethodCallGenerator.Execute(
                     objVar: inputVar,
                     functionName: "at",
                     parameters: [new(new(typeof(int), false, null, []), loopVar)],
                     returnParam: new(Type: elementType, $"{outputArrayVar}[{loopVar}]"),
                     options: new(SkipFunctionChecks: true),
                     context: context
                 ).IndentLines(4)}}
                 }
                 {{outputVar}} = {{outputArrayVar}};
                 """;
    }
}