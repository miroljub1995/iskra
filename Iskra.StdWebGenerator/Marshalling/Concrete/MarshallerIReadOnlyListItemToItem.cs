using Iskra.StdWebGenerator.Extensions;
using Iskra.StdWebGenerator.GeneratorContexts;

namespace Iskra.StdWebGenerator.Marshalling.Concrete;

public class MarshallerIReadOnlyListItemToItem : Marshaller
{
    public override bool CanMarshall(MyType type, MyType destination)
        => !type.IsNullable
           && !destination.IsNullable
           && type.Type.IsIReadOnlyList()
           && destination.Type.IsIReadOnlyList()
           && type != destination;

    public override string Marshall(MyType inputType, string inputVar, MyType outputType, string outputVar,
        GeneratorContext context)
    {
        EnsureCanMarshall(inputType, outputType);

        var loopVar = context.GetNextVariableName();
        var tmpListVar = context.GetNextVariableName();

        var inputElementType = inputType.GenericTypeArguments[0];
        var outputElementType = outputType.GenericTypeArguments[0];

        var marshallElement = Marshallers.Instance
            .GetNext(inputElementType, outputElementType)
            .Marshall(
                inputElementType,
                $"{inputVar}[{loopVar}]",
                outputElementType,
                $"{tmpListVar}[{loopVar}]",
                context
            );

        return $$"""
                 {{TypeNameGenerator.Execute(outputElementType)}}[] {{tmpListVar}} = new {{TypeNameGenerator.Execute(outputElementType)}}[{{inputVar}}.Count];
                 for (int {{loopVar}} = 0; {{loopVar}} < {{inputVar}}.Count; {{loopVar}}++)
                 {
                 {{marshallElement.IndentLines(4)}}
                 }
                 {{outputVar}} = {{tmpListVar}};
                 """;
    }
}