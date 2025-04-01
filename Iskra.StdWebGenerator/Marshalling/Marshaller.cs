namespace Iskra.StdWebGenerator.Marshalling;

public abstract class Marshaller
{
    public abstract bool CanMarshall(MyType type, MyType destination);

    public abstract string Marshall(
        MyType inputType,
        string inputVar,
        MyType outputType,
        string outputVar,
        GeneratorContext context
    );

    protected void EnsureCanMarshall(MyType inputType, MyType outputType)
    {
        if (!CanMarshall(inputType, outputType))
        {
            throw new($"Can not marshall type {inputType} to destination {outputType}");
        }
    }
}