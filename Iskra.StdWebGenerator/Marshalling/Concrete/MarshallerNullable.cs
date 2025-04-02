using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator.Marshalling.Concrete;

public class MarshallerNullable : Marshaller
{
    public override bool CanMarshall(MyType type, MyType destination)
        => !type.Equals(destination)
           && type.IsNullable
           && destination.IsNullable;

    public override string Marshall(MyType inputType, string inputVar, MyType outputType, string outputVar,
        GeneratorContext.GeneratorContext context)
    {
        EnsureCanMarshall(inputType, outputType);

        var notNullInputType = inputType with { IsNullable = false };
        var notNullOutputType = outputType with { IsNullable = false };

        var notNullInputVar = inputType.Type.IsValueType ? $"{inputVar}.Value" : inputVar;

        var nextRes = Marshallers.Instance
            .GetNext(notNullInputType, notNullOutputType)
            .Marshall(notNullInputType, notNullInputVar, notNullOutputType, outputVar, context);

        return $$"""
                 if ({{inputVar}} is not null)
                 {
                 {{nextRes.IndentLines(4)}}
                 }
                 else
                 {
                    {{outputVar}} = null;
                 }
                 """;
    }
}