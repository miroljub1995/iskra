using Iskra.StdWebGenerator.Extensions;

namespace Iskra.StdWebGenerator.Marshalling.Concrete;

public class MarshallerOneOfToObjectForJS : Marshaller
{
    public override bool CanMarshall(MyType type, MyType destination)
        => !type.IsNullable
           && !destination.IsNullable
           && type.Type.IsOneOf()
           && destination.Type == typeof(ObjectForJS);

    public override string Marshall(MyType inputType, string inputVar, MyType outputType, string outputVar,
        GeneratorContext context)
    {
        EnsureCanMarshall(inputType, outputType);

        var marshalledArgs = inputType.GenericTypeArguments
            .Select((x, i) =>
            {
                var argTypeName = TypeNameGenerator.Execute(x);
                var valueVar = context.GetNextVariableName();

                var marshalledValue = Marshallers.Instance
                    .GetNext(x, outputType)
                    .Marshall(x, valueVar, outputType, outputVar, context);

                var isElse = i == 0 ? "" : "else ";

                return $$"""
                         {{isElse}}if ({{inputVar}}.Value is {{argTypeName}} {{valueVar}})
                         {
                         {{marshalledValue.IndentLines(4)}}
                         } 
                         """;
            })
            .ToList();

        marshalledArgs.Add($$"""
                             else
                             {
                                 throw new Exception("Value has invalid type.");
                             }
                             """);

        return $$"""
                 {{string.Join("\n", marshalledArgs)}}
                 """;
    }
}