namespace Iskra.StdWebGenerator.Marshalling.Concrete;

public class MarshallerObjectToObjectForJS : Marshaller
{
    public override bool CanMarshall(MyType type, MyType destination)
        => !type.IsNullable
           && !destination.IsNullable
           && type.Type == typeof(object)
           && destination.Type == typeof(ObjectForJS);

    public override string Marshall(MyType inputType, string inputVar, MyType outputType, string outputVar,
        GeneratorContext context)
    {
        EnsureCanMarshall(inputType, outputType);

        return $$"""
                 convert();
                 {{outputVar}} = {{inputVar}};
                 """;
    }
}